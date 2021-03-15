using PagedList.Core;

namespace Framework.Core.ListManagment
{
    public abstract class PagingDto
    {
       

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public bool IsExport { get; set; }
        public bool IsDescending { get; set; } = true;

        public string ReturnUrl { get; set; }

    }
}
