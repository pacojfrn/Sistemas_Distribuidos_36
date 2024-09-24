using RestApi.Models;

namespace RestApi.Repositories;

public interface IGroupRepository{
    Task<GroupModel> GetByIdAsync(String id, CancellationToken cancellationToken);
<<<<<<< HEAD

    Task<List<GroupModel>> GetByNameAsync(String name, CancellationToken cancellationToken);
 }
=======
}
>>>>>>> d65eae242f824823ad62e338375cdadfff41386a
