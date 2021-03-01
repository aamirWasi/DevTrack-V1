using DevTrack.DataAccessLayer;

namespace DevTrack.Foundation.BusinessObjects
{
    public class TeamMember
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int HourlyRate { get; set; }
        public string MemberRole { get; set; }
    }
}
