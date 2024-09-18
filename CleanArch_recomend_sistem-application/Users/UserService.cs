
namespace CleanArch_recomend_sistem.application.Users;

internal class MovieService(IRepository<MovieService> repository) : IService
{
    private IRepository<MovieService> Repository { get; init; } = repository;

    public Task<IEnumerable<MovieService>> GetUserServiceAsync(CancellationToken cancellationToken = default) =>
        Repository.Get(cancellationToken);

    public async Task RegisterOrUpdateUsersAsync(IEnumerable<MovieService> users, CancellationToken cancellationToken = default)
    {
        var newUsers = from user in users
                         where user.Id is null
                         select new User()
                         {
                             Email = user.Email,
                             Number = user.Number,
                             Name = user.Name,
                         };

        var repo = await Repository.Get(cancellationToken);
        var newOldUserCouples = from user in (from user in users where user.Id is not null select user)
                                  join repUser in repo on user.Id equals repUser.Id
                                  select (user, repUser);

        foreach (var (updatedUser, oldUser) in newOldUserCouples)
        {
            oldUser.Name = updatedUser.Name;
            oldUser.Email = updatedUser.Email;
            oldUser.Number = updatedUser.Number;
        }

        // todo: validation object
        await Repository.AddRange(newUsers, cancellationToken);
        await Repository.UpdateRange(repo, cancellationToken);
    }
}
