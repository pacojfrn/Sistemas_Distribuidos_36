<<<<<<< HEAD
using System.Text.RegularExpressions;
=======
>>>>>>> d65eae242f824823ad62e338375cdadfff41386a
using RestApi.Dtos;
using RestApi.Infrastructure.Mongo;
using RestApi.Models;

namespace RestApi.Mappers;

public static class GroupMapper{
    public static GroupResponse ToDto(this GroupUserModel group){
        return new GroupResponse{
            Id = group.Id,
            Name = group.Name,
            CreationDate = group.CreationDate
        };
    }
    public static GroupModel ToModel(this GroupEntity group){
        if (group is null)
        {
            return null;
        }

        return new GroupModel{
            Id = group.Id,
            Name = group.Name,
            Users = group.Users,
            CreationDate = group.CreatedAt
        };
    }
<<<<<<< HEAD
    
=======
>>>>>>> d65eae242f824823ad62e338375cdadfff41386a
}