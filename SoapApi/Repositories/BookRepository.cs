using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SoapApi.Infrastructure;
using SoapApi.Infrastructure.Entities;
using SoapApi.Mappers;
using SoapApi.Models;

namespace SoapApi.Repositories;

public class BookRespository : IBookRepository{

    private readonly RelationalDbContext _dbContext;
    public BookRespository(RelationalDbContext dbContext){


        _dbContext = dbContext;

    }


    public async Task<List<BookModel>> GetByNameAsync(string Title, CancellationToken cancellationToken)
{
    var books = await _dbContext.Books.AsNoTracking()
                .Where(book => book.Title.Contains(Title))
                .ToListAsync(cancellationToken);

    return books.Select(book => book.ToModel()).ToList();
}
}