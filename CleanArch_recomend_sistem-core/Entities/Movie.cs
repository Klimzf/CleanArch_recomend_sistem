
namespace CleanArch_recomend_sistem.Core.Entities
{
    public class Movie : IEntity
    {
        public Id Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public double Rating { get; set; }
    }
}
