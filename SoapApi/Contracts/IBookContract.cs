using System.ServiceModel;
using SoapApi.Dtos;
using SoapApi.Models;

namespace SoapApi.Contracts;

[ServiceContract]

public interface IBookContract{
    [OperationContract]
    public Task<List<BookResponseDto>> GetBookByName(string bookName, CancellationToken cancellationToken); 

}
