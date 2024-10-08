
namespace CleanArch_recomend_sistem.application.Users;

public class UserService(IRepository<User> repository) : IService
{
    private IRepository<User> Repository { get; init; } = repository;

    public Task<IEnumerable<User>> GetUserServiceAsync(CancellationToken cancellationToken = default) =>
        Repository.Get(cancellationToken);

    public async Task RegisterOrUpdateUsersAsync(UserDTO user, CancellationToken cancellationToken = default)
    {
        User localProj;
        if (user.Id is not null)
        {
            localProj = (await Repository.Get(x => x.Id.Value == user.Id.Value, cancellationToken)).FirstOrDefault() ??
                throw new Core.Exceptions.UserNotFoundException(user.Id.Value);
            localProj.Name = user.Name;
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
    }
}
