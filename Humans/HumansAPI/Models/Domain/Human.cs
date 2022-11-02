using HumansAPI.Enums;

namespace HumansAPI.Models.Domain
{
    public class Human : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderType Gender { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? CityId { get; set; }
        /// <summary>
        /// Navigation property
        /// </summary>
        public City? City { get; set; }
        /// <summary>
        /// Navigation property
        /// </summary>
        public List<Phone>? Phones { get; set; }
        public string? PhotoPath { get; set; }
        /// <summary>
        /// Navigation property
        /// </summary>
        public List<HumanConnection>? Connections { get; set; }
    }
}
