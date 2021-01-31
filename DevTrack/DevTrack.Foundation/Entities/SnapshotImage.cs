using DevTrack.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTrack.Foundation.Entities
{
    public class SnapshotImage : IEntity<int>
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public DateTimeOffset CaptureTime { get; set; }
    }
}
