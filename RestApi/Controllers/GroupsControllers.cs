using Microsoft.AspNetCore.Mvc;
using RestApi.Dtos;
using RestApi.Services;
using RestApi.Mappers;

namespace RestApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GroupsControllers : ControllerBase{
    private readonly IGroupService _groupService;
    public GroupsControllers(IGroupService groupService){
        _groupService = groupService;
    }


    //localhost:port/groups/17401274913
    [HttpGet("{id}")]
    public async Task<ActionResult<GroupResponse>> GetGroupById(string id, CancellationToken cancellationToken){
        var group = await _groupService.GetGroupByIdAsync(id, cancellationToken);
        if (group is null){
            return NotFound();
        }
        return Ok(group.ToDto());
    }
    [HttpGet]
    public async Task<ActionResult<List<GroupResponse>>> GetGroupsByName([FromQuery]string name, CancellationToken cancellationToken){
    var groups = await _groupService.GetGroupByNameAsync(name, cancellationToken);
    return Ok(groups.Select(g => g.ToDto()).ToList());
    }
}   