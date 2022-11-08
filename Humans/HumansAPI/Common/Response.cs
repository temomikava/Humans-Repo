using HumansAPI.DTOs;

namespace HumansAPI.Common
{
    public class Response
    {
        public IEnumerable<ReadHumanDTO>? Items { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
    }
}
