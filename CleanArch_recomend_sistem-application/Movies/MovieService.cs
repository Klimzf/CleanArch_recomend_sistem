
using CleanArch_recomend_sistem.Core.Entities;

namespace CleanArch_recomend_sistem.application.Movies;

public class MovieService(IRepository<Movie> repository) : IService
{
    private IRepository<Movie> Repository { get; init; } = repository;

    public Task<IEnumerable<Movie>> GetUserServiceAsync(CancellationToken cancellationToken = default) =>
        Repository.Get(cancellationToken);

    /*public async Task RegisterOrUpdateMoviesAsync(MovieDTO movie, CancellationToken cancellationToken = default)
    {
        User localProj;
        if (movie.Id is not null)
        {
            localProj = (await Repository.Get(x => x.Id.Value == movie.Id.Value, cancellationToken)).FirstOrDefault() ??
                throw new Core.Exceptions.MovieNotFoundException(movie.Id.Value);
            localProj.Title = movie.Name;
            localProj.Email = user.Email;
            localProj.Number = user.Number;
        }
        else
            localProj = new()
            {
                Name = user.Name,
                Email = user.Email,
                Number = user.Number,
            };

        if (localProj.Id is null)
            await Repository.Add(localProj, cancellationToken);
        else
            await Repository.Update(localProj, cancellationToken);
    }*/
}
