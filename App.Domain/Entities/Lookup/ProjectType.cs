using Domain.App.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.App.Entities.Lookup
{
    public class ProjectType
    {
        public int Id { get; set; }

        public string NameAr { get; set; }

        public string NameEn { get; set; }

        public ICollection<Project> Projects { get; set; }

    }
}