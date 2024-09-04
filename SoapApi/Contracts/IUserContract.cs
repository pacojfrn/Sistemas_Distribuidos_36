using System.ServiceModel;
using SoapApi.Dtos;
using SoapApi.Models;

namespace SoapApi.Contracts;

[ServiceContract]

public interface IUserContract{
    [OperationContract]
    public Task<UserResponseDto> GetUserById(Guid userId, CancellationToken cancellationToken); 

    [OperationContract]
    public Task<IList<UserResponseDto>> GetAll(CancellationToken cancellationToken);


    [OperationContract]
    public Task <IList<UserResponseDto>> GetAllByEmail(string email, CancellationToken cancellationToken);

    [OperationContract]

    public Task<bool> DeleteUserById(Guid userId, CancellationToken cancellationToken);

    [OperationContract]

    public Task<UserResponseDto> CreateUser(UserCreateRequestDto user, CancellationToken cancellationToken);

    [OperationContract]

    public Task<bool> UpdateUser(Guid userId, string firstName, string lastName, DateTime birthday, CancellationToken cancellationToken);
}