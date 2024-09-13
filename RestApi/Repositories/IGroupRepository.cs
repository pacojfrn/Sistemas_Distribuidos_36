using RestApi.Models;

namespace RestApi.Repositories;

public interface IGroupRepository{
    Task<GroupModel> GetByIdAsync(String id, CancellationToken cancellationToken);
}