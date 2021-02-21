using System.IO;
using System.Net;
using System.Text;
using DevTrack.Foundation.BusinessObjects;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.UnitOfWorks;
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
        
        public void KeyboardTrackSave()
        {
            var keyboardEntity = _keyboardTrackAdapter.KeyboardEntity();
            if (keyboardEntity == null) return;
            _keyboardTrackUnitOfWork.KeyboardTrackRepository.Add(keyboardEntity);
            _keyboardTrackUnitOfWork.Save();
        }

        public void SyncKeyboardData()
        {
            var keyboards = _keyboardTrackUnitOfWork.KeyboardTrackRepository.GetAll();
            foreach (var keyboard in keyboards)
            {
                var data = ConvertWithoutId(keyboard);
                SaveDataToWebDb(data);
                DeleteFromLocalDb(keyboard);
            }
        }

        private void DeleteFromLocalDb(Keyboard keyboard)
        {
            _keyboardTrackUnitOfWork.KeyboardTrackRepository.Remove(keyboard);
            _keyboardTrackUnitOfWork.Save();
        }

        private static Keyboard ConvertWithoutId(Keyboard keyboard)
        {
            var model = new KeyboardBusinessObject();
            var businessObject = model.ConvertToBusinessObject(keyboard);
            return model.ConvertToEntity(businessObject);
        }
        private static void SaveDataToWebDb(Keyboard keyboard)
        {
            const string url = "https://localhost:44332/api/Keyboard";
            var request = WebRequest.Create(url);

            request.Method = "POST";
            request.ContentType = "application/json";
            var requestContent = JsonConvert.SerializeObject(keyboard);
            var data = Encoding.UTF8.GetBytes(requestContent);
            request.ContentLength = data.Length;


            using var requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            requestStream.Flush();
            using var response = request.GetResponse();
            using var streamItem = response.GetResponseStream();
            using var reader = new StreamReader(streamItem);
            var result = reader.ReadToEnd();
        }
    }
}
