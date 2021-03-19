using System;
using System.Net.Http;
using System.Net.Http.Headers;
using DevTrack.Foundation.BusinessObjects;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.UnitOfWorks;
using DevTrack.Foundation.UnitOfWorks.Interfaces;
using DevTrack.Foundation.Services.Interfaces;

namespace DevTrack.Foundation.Services
{
    public class MouseTrackService : IMouseTrackService
    {
        private readonly IMouseTrackUnitOfWork _mouseTrackUnitOfWork;
        private readonly IMouseTrackStartService _mouseTrackAdapter;

        public MouseTrackService(
            IMouseTrackUnitOfWork mouseTrackUnitOfWork,
            IMouseTrackStartService mouseTrackAdapter)
        {
            _mouseTrackUnitOfWork = mouseTrackUnitOfWork;
            _mouseTrackAdapter = mouseTrackAdapter;
        }

        public void MouseTrackSaveToLocal()
        {
            var mouseEntity = _mouseTrackAdapter.MouseEntity();
            if (mouseEntity == null) return;
            _mouseTrackUnitOfWork.MouseTrackRepository.Add(mouseEntity);
            _mouseTrackUnitOfWork.Save();
        }

        public void SyncMouseDataFromLocal()
        {
            var mouseList = _mouseTrackUnitOfWork.MouseTrackRepository.GetAll();
            foreach (var mouse in mouseList)
            {
                SaveDataToWebDb(mouse);
            }
        }
        private void SaveDataToWebDb(Mouse mouse)
        {
            using var client = new HttpClient {BaseAddress = new Uri("https://localhost:44332/")};
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var businessObject = new MouseBusinessObject().ConvertToBusinessObject(mouse);
            var response = client.PostAsJsonAsync("api/Mouse", businessObject).Result;

            if (!response.IsSuccessStatusCode) return;
            using var content = response.Content;
            var result = content.ReadAsStringAsync();
            var final = result.Result;
            if (final != "true") return;
            _mouseTrackUnitOfWork.MouseTrackRepository.Remove(mouse);
            _mouseTrackUnitOfWork.Save();
        }
    }
}
