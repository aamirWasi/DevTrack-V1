using System;
using DevTrack.DataAccessLayer;
using DevTrack.Membership.Entities;

namespace DevTrack.Foundation.Entities
{
    public class Project : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public ApplicationUser User { get; set; }
        public bool IsAdmin { get; set; }
        public Settings Settings { get; set; }
        public TeamMember TeamMember { get; set; }
    }
}