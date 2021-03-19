using DevTrack.Foundation.UnitOfWorks;
using System;
using DevTrack.Foundation.Adapters;
using EO = DevTrack.Foundation.Entities;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BO = DevTrack.Foundation.BusinessObjects;
using DevTrack.Foundation.UnitOfWorks.Interfaces;
using DevTrack.Foundation.Services.Interfaces;

namespace DevTrack.Foundation.Services
{
    public class RunningProgramService : IRunningProgramService
    {
        private readonly IRunningProgramUnitOfWork _runningProgramUnitOfWork;
        private readonly IRunningProgramAdapter _runningProgramAdpater;

        public RunningProgramService(IRunningProgramUnitOfWork runningProgramUnitOfWork,IRunningProgramAdapter runningProgramAdapter)
        {
            _runningProgramUnitOfWork = runningProgramUnitOfWork;
            _runningProgramAdpater = runningProgramAdapter;
        }

        public void AddRunningProgramsLocalDb()
        {
            var runningApps = _runningProgramAdpater.GetRunningPrograms();

            if (string.IsNullOrWhiteSpace(runningApps))
                throw new InvalidOperationException("Program name is not found");

            var runningAppsEntity = new EO.RunningProgram
            {
                RunningApplications = runningApps,
                RunningApplicationsDateTime = DateTime.Now,
            };

            _runningProgramUnitOfWork.RunningProgramRepository.Add(runningAppsEntity);
            _runningProgramUnitOfWork.Save();
        }

        public void SyncRunningPrograms()
        {
            var runningAppsList = _runningProgramUnitOfWork.RunningProgramRepository.GetAll();
            if(runningAppsList.Count > 0 && runningAppsList != null)
            {
                foreach (var runningApps in runningAppsList)
                {
                    AddRunningProgramsWeb(runningApps);
                }
            }
        }

        private void AddRunningProgramsWeb(EO.RunningProgram runningAppsEntity)
        {
            using var client = new HttpClient { BaseAddress = new Uri("https://localhost:44332/") };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var businessObject = new BO.RunningProgram().ConvertToBusinessObject(runningAppsEntity);
            var response = client.PostAsJsonAsync("api/RunningProgram", businessObject).Result;

            if (response.IsSuccessStatusCode)
            {
                using HttpContent content = response.Content;
                Task<string> result = content.ReadAsStringAsync();
                string final = result.Result;
                if (final == "true")
                {
                    _runningProgramUnitOfWork.RunningProgramRepository.Remove(runningAppsEntity);
                    _runningProgramUnitOfWork.Save();
                }
            }
        }
    }
}
