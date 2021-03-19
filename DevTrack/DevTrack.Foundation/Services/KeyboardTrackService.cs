using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using DevTrack.Foundation.BusinessObjects;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.UnitOfWorks;
using DevTrack.Foundation.UnitOfWorks.Interfaces;
using DevTrack.Foundation.Services.Interfaces;
using Newtonsoft.Json;

namespace DevTrack.Foundation.Services
{
    public class KeyboardTrackService : IKeyboardTrackService
    {
        private readonly IKeyboardTrackUnitOfWork _keyboardTrackUnitOfWork;
        private readonly IKeyboardTrackStartService _keyboardTrackAdapter;
        public KeyboardTrackService(
            IKeyboardTrackUnitOfWork keyboardTrackUnitOfWork,
            IKeyboardTrackStartService keyboardTrackAdapter)
        {
            _keyboardTrackUnitOfWork = keyboardTrackUnitOfWork;
            _keyboardTrackAdapter = keyboardTrackAdapter;
        }
        
        public void KeyboardTrackSaveToLocal()
        {
            var keyboardEntity = _keyboardTrackAdapter.KeyboardEntity();
            if (keyboardEntity == null) return;
            _keyboardTrackUnitOfWork.KeyboardTrackRepository.Add(keyboardEntity);
            _keyboardTrackUnitOfWork.Save();
        }

        public void SyncKeyboardDataFromLocal()
        {
            var keyboards = _keyboardTrackUnitOfWork.KeyboardTrackRepository.GetAll();
            foreach (var keyboard in keyboards)
            {
                SaveDataToWebDb(keyboard);
            }
        }

        private void SaveDataToWebDb(Keyboard keyboard)
        {
            using var client = new HttpClient { BaseAddress = new Uri("https://localhost:44332/") };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var businessObject = new KeyboardBusinessObject().ConvertToBusinessObject(keyboard);
            var response = client.PostAsJsonAsync("api/Keyboard", businessObject).Result;

            if (!response.IsSuccessStatusCode) return;
            using var content = response.Content;
            var result = content.ReadAsStringAsync();
            var final = result.Result;
            if (final != "true") return;
            _keyboardTrackUnitOfWork.KeyboardTrackRepository.Remove(keyboard);
            _keyboardTrackUnitOfWork.Save();
        }
    }
}
