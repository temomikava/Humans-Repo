namespace HumansAPI.Requests
{
    public class GetAllHumanRequest
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? PersonalNo { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
