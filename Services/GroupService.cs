using RestApi.Models;
using RestApi.Repositories;
using RestApi.Exceptions;

namespace RestApi.Services;

public class GroupService : IGroupService
{
    private readonly IGroupRepository _groupRepository;
    private readonly IUserRepository _userRepository;
    public GroupService(IGroupRepository groupRepository, IUserRepository userRepository){
        _groupRepository = groupRepository;
        _userRepository = userRepository;
    }
    public async Task<GroupUserModel> GetGroupByIdAsync(string Id, CancellationToken cancellationToken)
    {
        var group = await _groupRepository.GetByIdAsync(Id, cancellationToken);
        if(group is null){
            return null;
        }
        return new GroupUserModel{
            Id = group.Id,
            Name = group.Name,
            CreationDate = group.CreationDate,
            Users = (await Task.WhenAll(group.Users.Select(userId => _userRepository.GetByIdAsync(userId, cancellationToken)))).Where(user => user !=null).ToList()
        };
    }
    public async Task<IEnumerable<GroupUserModel>> GetGroupsByNameAsync(string name, int pageIndex, int pageSize, string orderBy, CancellationToken cancellationToken)
    {
        var groups = await _groupRepository.GetByNameAsync(name, pageIndex, pageSize, orderBy, cancellationToken);

        var groupUserModels = await Task.WhenAll(groups.Select(async group => 
        {
            var users = await Task.WhenAll(group.Users.Select(userId => _userRepository.GetByIdAsync(userId, cancellationToken)));
            return new GroupUserModel
            {
                Id = group.Id,
                Name = group.Name,
                CreationDate = group.CreationDate,
                Users = users.Where(user => user != null).ToList()
            };
        }));

        return groupUserModels.ToList();
    }
    public async Task DeleteGroupByIdAsync(string Id, CancellationToken cancellationToken){
        var group = await _groupRepository.GetByIdAsync(Id,cancellationToken);
        if (group is null)
        {
            throw new GroupNotFoundException();
        }
        await _groupRepository.DeleteByIdAsync(Id,cancellationToken);
    }


    public async Task<GroupUserModel> CreateGroupAsync(string name, int pageIndex, int pageSize, string orderBy, Guid[] users, CancellationToken cancellationToken){

        if (users.Length == 0)
        {
            throw new InvalidGroupRequestFormatException();
        }

        var groups = await _groupRepository.GetByNameAsync(name,pageIndex,pageSize,orderBy, cancellationToken);
        if(groups.Any()){
            throw new GroupAlreadyExistsException();
        }
        var group = await _groupRepository.CreateGroupAsync(name,users,cancellationToken);
        return new GroupUserModel{
            Id = group.Id,
            Name = group.Name,
            CreationDate = group.CreationDate,
            Users = (await Task.WhenAll(group.Users.Select(userId => _userRepository.GetByIdAsync(userId, cancellationToken)))).Where(user => user !=null).ToList()

        };
    }
    
    public async Task<GroupUserModel> GetByNameSpecifiedAsync(string name, CancellationToken cancellationToken){
        var group = await _groupRepository.GetByNameSpecAsync(name, cancellationToken);
        if(group is null){
            return null;
        }
        return new GroupUserModel{
            Id = group.Id,
            Name = group.Name,
            CreationDate = group.CreationDate,
            Users = (await Task.WhenAll(group.Users.Select(userId => _userRepository.GetByIdAsync(userId, cancellationToken)))).Where(user => user !=null).ToList()
        };
    }

    public async Task UpdateGroupAsync(string id, string name, Guid[] users,CancellationToken cancellationToken){
        if (users.Length == 0)
        {
            throw new InvalidGroupRequestFormatException();
        }
        var groups = await _groupRepository.GetByIdAsync(id, cancellationToken);
        if (groups is null)
        {
            throw new GroupNotFoundException();
        }
        
        groups = await _groupRepository.GetByNameSpecAsync(name,cancellationToken);
        if(groups is not null){
            throw new GroupAlreadyExistsException();
        }

        await _groupRepository.UpdateGroupAsync(id,name,users,cancellationToken);
    }
    
}