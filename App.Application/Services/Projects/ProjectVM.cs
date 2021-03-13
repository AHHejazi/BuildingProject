using Domain.App.Entities;
using Framework.Core.ListManagment;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.App.Services.Projects
{
    public class ProjectVM : PagingDto
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public Boolean? IsActive { get; set; }
        public StaticPagedList<Project> Items { get; set; }

    }
}
