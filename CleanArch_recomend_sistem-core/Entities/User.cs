
namespace CleanArch_recomend_sistem.Core.Entities
{
    public class User : IEntity
    {
        public Id Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Number { get; set; }
    }
}
