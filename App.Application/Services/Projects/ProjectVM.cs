using Domain.App.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.App.Services.Projects
{
    public class ProjectVM
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public Boolean IsActive { get; set; }

        public IReadOnlyList<Project> ProjectList { get; set; }

    }
}
