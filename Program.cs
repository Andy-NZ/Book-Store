using Microsoft.Extensions.DependencyInjection;
using BookStore;
using BookStore.Tests;
using BookStore.Services;
using BookStore.Interfaces;
using BookStore.Repositories;

// Register Services 
IServiceCollection services = new ServiceCollection();
services.AddAutoMapper(typeof(MapperProfile));

services.AddScoped<IBookService, BookService>();
services.AddScoped<IBookRepository, BookRepoistory>();
services.AddScoped<IMockUserBehavior, MockUserBehavior>();
services.AddTransient<AppRunner>();

// Run Application
IServiceProvider serviceProvider = services.BuildServiceProvider();
var runner = serviceProvider.GetService<AppRunner>();
runner?.Run();