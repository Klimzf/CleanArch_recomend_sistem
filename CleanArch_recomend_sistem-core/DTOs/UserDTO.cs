
namespace CleanArch_recomend_sistem.Core.DTOs
{
    public class UserDTO
    {
        public Id Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Number { get; set; }

        public static implicit operator UserDTO(User other) =>
            new()
            {
                Id = other.Id,
                Name = other.Name,
                Email = other.Email,
                Number = other.Number,  
            };
    }
}
