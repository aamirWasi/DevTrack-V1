using DevTrack.Foundation.Entities;
using DevTrack.Foundation.Adapters;
using DevTrack.Foundation.UnitOfWorks;
using DevTrack.Foundation.UnitOfWorks.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using EO = DevTrack.Foundation.Entities;
using BO = DevTrack.Foundation.BusinessObjects;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DevTrack.Foundation.Services.Interfaces;

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

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44332/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.PostAsJsonAsync("api/ActiveProgram", webProgram).Result;

                if (response.IsSuccessStatusCode)
                {
                    using (HttpContent content = response.Content)
                    {
                        Task<string> result = content.ReadAsStringAsync();
                        string final = result.Result;
                        if (final == "true")
                        {
                            _activeProgramUnitOfWork.ActiveProgramRepository.Remove(activeProgram);
                            _activeProgramUnitOfWork.Save();
                        }
                    }
                }
            }
        }


        private BO.ActiveProgram PrepareProgramForWeb(ActiveProgram activeProgram)
        {
            var activeProgramModel = new BO.ActiveProgram
            {
                ProgramName = activeProgram.ProgramName,
                ProgramTime = activeProgram.ProgramTime
            };

            return activeProgramModel;
        }
    }
}
