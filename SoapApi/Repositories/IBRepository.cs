using SoapApi.Models;

namespace SoapApi.Repositories;

public interface IBookRepository {
    public Task<List<BookModel>> GetByNameAsync(string Title, CancellationToken cancellationToken) ;

}

