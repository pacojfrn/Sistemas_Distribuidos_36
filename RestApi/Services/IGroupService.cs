using RestApi.Models;

namespace RestApi.Services;

public interface IGroupService{
    Task<GroupUserModel> GetGroupByIdAync(string id, CancellationToken cancellationToken);
}