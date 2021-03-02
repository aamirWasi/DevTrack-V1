using DevTrack.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevTrack.Foundation.Entities
{
    public class TeamMember : IEntity<int>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int HourlyRate { get; set; }
        public string MemberRole { get; set; }
    }
}
