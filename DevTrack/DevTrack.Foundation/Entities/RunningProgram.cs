using DevTrack.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevTrack.Foundation.Entities
{
    public class RunningProgram : IEntity<int>
    {
        public int Id { get; set; }
        public IList<String> RunningApplications { get; set; }
        public DateTime DateTime { get; set; }
    }
}
