using Microsoft.EntityFrameworkCore;
using SoapApi.Contracts;
using SoapApi.Infrastructure;
using SoapApi.Repositories;
using SoapApi.Services;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSoapCore();
builder.Services.AddScoped<IUserRepository, UserRespository>();
builder.Services.AddScoped<IUserContract, UserService>();
builder.Services.AddScoped<IBookRepository, BookRespository>();
builder.Services.AddScoped<IBookContract, BookService>();


builder.Services.AddDbContext<RelationalDbContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
app.UseSoapEndpoint<IUserContract>("/UserService.svc", new SoapEncoderOptions());
app.UseSoapEndpoint<IBookContract>("/BookService.svc", new SoapEncoderOptions());



app.Run();