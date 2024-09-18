
namespace CleanArch_recomend_sistem.Core.DTOs
{
    public class UserDTO
    {
        public Id Id { get; set; }
        public string Name { get; set; }

        public static implicit operator UserDTO(User other) =>
            new()
            {
                Id = other.Id,
                Name = other.Name,
            };
    }
}
