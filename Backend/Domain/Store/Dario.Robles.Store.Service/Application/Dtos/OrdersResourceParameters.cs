namespace Dario.Robles.Store.Service.Application.Dtos
{
    public class OrdersResourceParameters
    {
        const int maxPageSize = 20;
        const int defaultPageSize = 10;
        const int defaultPageNumber = 1;

        private int? _pageSize = defaultPageSize;
        private int? _pageNumber = defaultPageNumber;
        public string? State { get; set; } = "";
        public string? SearchQuery { get; set; } = "";
        public string? OrderBy { get; set; } = "Code";
        public string? Fields { get; set; } = "";

        public int? PageNumber
        {
            get
            {
                return _pageNumber;
            }
            set
            {
                _pageNumber = value == null ? defaultPageNumber : value;
            }
        }
        public int? PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                if (value == null)
                {
                    _pageSize = defaultPageSize;
                }
                else
                {
                    _pageSize = value > maxPageSize ? maxPageSize : value;
                }
            }
        }
    }
}
