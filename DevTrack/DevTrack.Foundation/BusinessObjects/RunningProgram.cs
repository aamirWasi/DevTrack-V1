using System;
using EO = DevTrack.Foundation.Entities;
using BO = DevTrack.Foundation.BusinessObjects;

namespace DevTrack.Foundation.BusinessObjects
{
    public class RunningProgram
    {
        public string RunningApplications { get; set; }
        public DateTime RunningApplicationsDateTime { get; set; }

        public BO.RunningProgram ConvertToBusinessObject(EO.RunningProgram runningProgram)
        {
            return new BO.RunningProgram
            {
                RunningApplications = runningProgram.RunningApplications,
                RunningApplicationsDateTime = runningProgram.RunningApplicationsDateTime,
            };
        }
    }
}
