namespace HumansAPI.Models.Domain
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public List<Human>? Humans { get; set; }

    }
}
