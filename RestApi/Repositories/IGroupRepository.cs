using RestApi.Models;

namespace RestApi.Repositories;

public interface IGroupRepository{
    Task<GroupModel> GetByIdAsync(string Id, CancellationToken cancellationToken);
    Task<IEnumerable<GroupModel>> GetByNameAsync(string name, CancellationToken cancellationToken);
    Task<GroupModel> GetByNameSpecAsync(string name, CancellationToken cancellationToken);
    Task DeleteByIdAsync(string id, CancellationToken cancellationToken);

    Task<GroupModel> CreateGroupAsync(string name, Guid[] users, CancellationToken cancellationToken);
}