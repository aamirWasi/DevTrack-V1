using System.IO;
using System.Net;
using System.Text;
using DevTrack.Foundation.BusinessObjects;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.UnitOfWorks;
using Newtonsoft.Json;

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
                var data = ConvertToEntity(mouse);
                SaveDataToWebDb(data);
                DeleteFromLocalDb(mouse);
            }
        }

        private void DeleteFromLocalDb(Mouse mouse)
        {
            _mouseTrackUnitOfWork.MouseTrackRepository.Remove(mouse);
            _mouseTrackUnitOfWork.Save();
        }

        private static Mouse ConvertToEntity(Mouse mouse)
        {
            var businessModel = new MouseBusinessObject();
            var businessObject = businessModel.ConvertToBusinessObject(mouse);
            return businessModel.ConvertToEntity(businessObject);
        }

        private static void SaveDataToWebDb(Mouse mouse)
        {
            const string url = "https://localhost:44332/api/Mouse";
            var request = WebRequest.Create(url);

            request.Method = "POST";
            request.ContentType = "application/json";
            var requestContent = JsonConvert.SerializeObject(mouse);
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
