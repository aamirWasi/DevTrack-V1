using DevTrack.Foundation.Entities;
using DevTrack.Foundation.Services.Adapters;
using DevTrack.Foundation.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using DevTrack.Foundation.Adapters;
using EO = DevTrack.Foundation.Entities;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace DevTrack.Foundation.Services
{
    public class ActiveProgramService : IActiveProgramService
    {

        private readonly IActiveProgramUnitOfWork _activeProgramUnitOfWork;
        private readonly IActiveProgramAdapter _activeProgramAdapter;

        public ActiveProgramService(IActiveProgramUnitOfWork activeProgramUnitOfWork, IActiveProgramAdapter activeProgramAdapter)
        {
            _activeProgramUnitOfWork = activeProgramUnitOfWork;
            _activeProgramAdapter = activeProgramAdapter;
        }

        public void SaveActiveProgramLocalDb()
        {
            var programName = _activeProgramAdapter.GetActiveProgramName();

            if (string.IsNullOrWhiteSpace(programName))
                throw new InvalidOperationException("Program name is missing");

            var activeProgram = new ActiveProgram
            {
                ProgramName = programName,
                ProgramTime = DateTime.Now
            };

            _activeProgramUnitOfWork.ActiveProgramRepository.Add(activeProgram);
            _activeProgramUnitOfWork.Save();
        }


        public void SyncActivePrograms()
        {
            var programs = _activeProgramUnitOfWork.ActiveProgramRepository.GetAll();
            if (programs.Count > 0 && programs != null)
            {
                foreach (var program in programs)
                {
                    SaveActiveProgramWeb(program);
                }
            }
        }

        private void SaveActiveProgramWeb(ActiveProgram activeProgram)
        {
            var webProgram = PrepareProgramForWeb(activeProgram);

            const string url = "https://localhost:44332/api/ActiveProgram";
            var request = WebRequest.Create(url);

            request.Method = "POST";
            request.ContentType = "application/json";
            var requestContent = JsonConvert.SerializeObject(webProgram);
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
                            if (result == "true")
                            {
                                _activeProgramUnitOfWork.ActiveProgramRepository.Remove(activeProgram);
                                _activeProgramUnitOfWork.Save();
                            }
                        }
                    }
                }
            }
        }


        private ActiveProgram PrepareProgramForWeb(ActiveProgram activeProgram)
        {
            var activeProgramEntity = new EO.ActiveProgram
            {
                ProgramName = activeProgram.ProgramName,
                ProgramTime = activeProgram.ProgramTime
            };

            return activeProgramEntity;
        }
    }
}
