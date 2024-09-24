using RestApi.Models;

namespace RestApi.Services;

public interface IGroupService{
<<<<<<< HEAD
    Task<GroupUserModel> GetGroupByIdAsync(string id, CancellationToken cancellationToken);
    Task<List<GroupUserModel>> GetGroupByNameAsync(string name, CancellationToken cancellationToken);
=======
    Task<GroupUserModel> GetGroupByIdAync(string id, CancellationToken cancellationToken);
>>>>>>> d65eae242f824823ad62e338375cdadfff41386a
}