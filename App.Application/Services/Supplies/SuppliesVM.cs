using Domain.App.Entities.Lookup;
using Framework.Core.ListManagment;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.App.Services.Supplies
{
    public class SuppliesVM : PagingDto
    {
        public Guid Id { get; set; }

        public string NameAr { get; set; }

        public string NameEn { get; set; }
        public StaticPagedList<Supplement> SuppliesList { get; set; }

    }
}
