using System.ServiceModel;
using System.Xml.Schema;
using SoapApi.Contracts;
using SoapApi.Dtos;
using SoapApi.Mappers;
using SoapApi.Models;
using SoapApi.Repositories;

namespace SoapApi.Services;

public class BookService : IBookContract{


    private readonly IBookRepository _bookRepository;



    public BookService(IBookRepository bookRepository){
        _bookRepository = bookRepository;
    }

    public async Task<List<BookResponseDto>> GetBookByName(String bookName, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(bookName))
    {
        return new List<BookResponseDto>();
    }

    var book = await _bookRepository.GetByNameAsync(bookName, cancellationToken);
    
    if (book is not null)
    {
        var bookDtos = book.Select(b => b.ToDto()).ToList();
        return bookDtos;
    }
    else
    {
        throw new FaultException("Book not found");

    }

    }

}

