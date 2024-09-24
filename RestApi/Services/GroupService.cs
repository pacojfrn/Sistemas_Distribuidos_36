using RestApi.Models;
using RestApi.Repositories;

namespace RestApi.Services;

public class GroupService : IGroupService
{
    private readonly IGroupRepository _groupRepository;
    public GroupService(IGroupRepository groupRepository){
        _groupRepository = groupRepository;
    }
<<<<<<< HEAD
    public async Task<GroupUserModel> GetGroupByIdAsync(string id, CancellationToken cancellationToken)
=======
    public async Task<GroupUserModel> GetGroupByIdAync(string id, CancellationToken cancellationToken)
>>>>>>> d65eae242f824823ad62e338375cdadfff41386a
    {
        var group = await _groupRepository.GetByIdAsync(id,cancellationToken);
        if (group is null)
        {
            return null;
        }
        return new GroupUserModel{
            Id = group.Id,
            Name = group.Name,
            CreationDate = group.CreationDate
        };
        
    }
<<<<<<< HEAD

    public async Task<List<GroupUserModel>> GetGroupByNameAsync(string name, CancellationToken cancellationToken)
    {
        var group = await _groupRepository.GetByNameAsync(name,cancellationToken);
        return group.Select(x => new GroupUserModel{
            Id = x.Id,
            Name = x.Name,
            CreationDate = x.CreationDate
        }).ToList();
    }

=======
>>>>>>> d65eae242f824823ad62e338375cdadfff41386a
}