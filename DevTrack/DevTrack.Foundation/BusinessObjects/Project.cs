using System;
using System.Collections.Generic;
using System.Text;
using EO = DevTrack.Foundation.Entities;
using BO = DevTrack.Foundation.BusinessObjects;

namespace DevTrack.Foundation.BusinessObjects
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public ApplicationUser User { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime CreationTime;
        public BO.Settings Settings { get; set; }
    }
}
