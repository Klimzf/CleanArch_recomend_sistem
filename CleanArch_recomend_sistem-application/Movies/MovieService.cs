
using CleanArch_recomend_sistem.Core.Entities;

namespace CleanArch_recomend_sistem.application.Movies;

internal class MovieService(IRepository<MovieService> repository) : IService
{
    private IRepository<MovieService> Repository { get; init; } = repository;

    public Task<IEnumerable<MovieService>> GetUserServiceAsync(CancellationToken cancellationToken = default) =>
        Repository.Get(cancellationToken);

    public async Task RegisterOrUpdateMoviesAsync(IEnumerable<MovieService> movies, CancellationToken cancellationToken = default)
    {
        var newMovies = from movie in movies
                        where movie.Id is null
                         select new Movie()
                         {
                             Title = movie.Title,
                             Genre = movie.Genre,
                             Rating = movie.Rating,
                         };

        var repo = await Repository.Get(cancellationToken);
        var newOldMovieCouples = from movie in (from movie in movies where movie.Id is not null select movie)
                                  join repMovie in repo on movie.Id equals repMovie.Id
                                  select (movie, repMovie);

        foreach (var (updatedMovie, oldMovie) in newOldMovieCouples)
        {
            oldMovie.Title = updatedMovie.Title;
            oldMovie.Genre = updatedMovie.Genre;
            oldMovie.Rating = updatedMovie.Rating;
        }

        // todo: validation object
        await Repository.AddRange(newMovies, cancellationToken);
        await Repository.UpdateRange(repo, cancellationToken);
    }
}
