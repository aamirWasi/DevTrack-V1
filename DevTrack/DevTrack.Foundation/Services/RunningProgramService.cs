using DevTrack.Foundation.UnitOfWorks;
using System;
using DevTrack.Foundation.Adapters;
using EO = DevTrack.Foundation.Entities;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System.IO;

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
            var programs = _runningProgramUnitOfWork.RunningProgramRepository.GetAll();
            if(programs.Count > 0 && programs != null)
            {
                foreach (var program in programs)
                {
                    var runningAppsEntity = new EO.RunningProgram
                    {
                        RunningApplications = program.RunningApplications,
                        RunningApplicationsDateTime = program.RunningApplicationsDateTime,
                    };

                    AddRunningProgramsWeb(runningAppsEntity);
                }
            }
        }

        private void AddRunningProgramsWeb(EO.RunningProgram runningAppsEntity)
        {
            const string url = "https://localhost:44332/api/RunningProgram";
            var request = WebRequest.Create(url);

            request.Method = "POST";
            request.ContentType = "application/json";
            var requestContent = JsonConvert.SerializeObject(runningAppsEntity);
            var data = Encoding.UTF8.GetBytes(requestContent);
            request.ContentLength = data.Length;
            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(data, 0, data.Length);
                requestStream.Flush();
                using (var response = request.GetResponse())
                {
                    using (var streamItem = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(streamItem))
                        {
                            var result = reader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
