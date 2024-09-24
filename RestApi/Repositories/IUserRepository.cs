using System.ServiceModel;
using RestApi.Infrastructure.Soap.SoapContracts;
using RestApi.Models;

namespace RestApi.Repositories;

public interface IUserRepository{
    Task<UserModel> GetByIdAsync(Guid userId, CancellationToken cancellationToken);
}