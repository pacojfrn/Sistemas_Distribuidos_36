using RestApi.Models;

namespace RestApi.Services;

public interface IGroupService{
    Task<GroupUserModel> GetGroupByIdAsync (string Id, CancellationToken cancellationToken);
    Task<IEnumerable<GroupUserModel>> GetGroupsByNameAsync(string name, int pageIndex, int pageSize, string orderBy, CancellationToken cancellationToken); 

}