using DevTrack.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevTrack.Foundation.Entities
{
    public class ActiveProgram : IEntity<int>
    {
        public int Id { get; set; }
        public string ProgramName { get; set; }
        public DateTime ProgramTime { get; set; }
    }
}
