namespace CleanArch_recomend_sistem.application.Recommendation;

public class RecommendationService(IRepository<User> userRepository, IRepository<Movie> movieRepository, IRepository<UserMovieRating> ratingRepository) : IService
{
    private IRepository<User> UserRepository { get; init; } = userRepository;
    private IRepository<Movie> MovieRepository { get; init; } = movieRepository;
    private IRepository<UserMovieRating> RatingRepository { get; init; } = ratingRepository;

    public async Task<IEnumerable<Movie>> GetRecommendedMoviesAsync(Id userId, CancellationToken cancellationToken = default)
    {
        // Получаем оценки текущего пользователя
        var currentUserRatings = await RatingRepository.Get(r => r.UserId == userId, cancellationToken);

        // Получаем всех других пользователей
        var otherUsers = await UserRepository.Get(u => u.Id != userId, cancellationToken);

        // Словарь для хранения похожести пользователей
        var userSimilarities = new Dictionary<User, double>();

        foreach (var otherUser in otherUsers)
        {
            var otherUserRatings = await RatingRepository.Get(r => r.UserId == otherUser.Id, cancellationToken);

            // Рассчитываем схожесть между текущим пользователем и другим пользователем
            var similarity = CalculateSimilarity(currentUserRatings, otherUserRatings);

            // Если схожесть больше 0, сохраняем в словарь
            if (similarity > 0)
            {
                userSimilarities[otherUser] = similarity;
            }
        }

        // Сортируем пользователей по убыванию схожести
        var mostSimilarUsers = userSimilarities.OrderByDescending(kv => kv.Value).Select(kv => kv.Key);

        // Собираем фильмы, которые рекомендованы на основе схожих пользователей
        var recommendedMovies = new List<Movie>();

        foreach (var similarUser in mostSimilarUsers)
        {
            var similarUserRatings = await RatingRepository.Get(r => r.UserId == similarUser.Id && r.Rating >= 4, cancellationToken);
            var movieIds = similarUserRatings.Select(r => r.MovieId);

            foreach (var movieId in movieIds)
            {
                var movie = await MovieRepository.Get(m => m.Id == movieId, cancellationToken);
                if (movie.Any())
                {
                    recommendedMovies.Add(movie.First());
                }
            }
        }

        // Возвращаем уникальные фильмы
        return recommendedMovies.Distinct();
    }

    // Алгоритм расчета схожести (например, по коэффициенту Пирсона)
    private double CalculateSimilarity(IEnumerable<UserMovieRating> userRatings, IEnumerable<UserMovieRating> otherUserRatings)
    {
        var commonRatings = userRatings.Join(otherUserRatings, ur => ur.MovieId, our => our.MovieId,
            (ur, our) => new { UserRating = ur.Rating, OtherUserRating = our.Rating }).ToList();


        if (!commonRatings.Any())
        {
            return 0; // Нет общих оценок, значит схожесть 0
        }

        var userAvgRating = userRatings.Average(r => r.Rating);
        var otherUserAvgRating = otherUserRatings.Average(r => r.Rating);

        var numerator = commonRatings.Sum(r => (r.UserRating - userAvgRating) * (r.OtherUserRating - otherUserAvgRating));

        var denominator = Math.Sqrt(commonRatings.Sum(r => Math.Pow(r.UserRating - userAvgRating, 2)))
                        * Math.Sqrt(commonRatings.Sum(r => Math.Pow(r.OtherUserRating - otherUserAvgRating, 2)));


        return denominator == 0 ? 0 : numerator / denominator;
    }
}
