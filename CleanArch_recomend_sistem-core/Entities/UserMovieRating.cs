
namespace CleanArch_recomend_sistem.Core.Entities
{
    public class UserMovieRating: IEntity
    {
        public Id Id { get; set; } 

        public Id UserId { get; set; } 
        public virtual User User { get; set; } 

        public Id MovieId { get; set; } 
        public virtual Movie Movie { get; set; } 

        public int Rating { get; set; }

    }
}
