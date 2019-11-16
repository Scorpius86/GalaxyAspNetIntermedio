using Galaxy.Web.API.Postman.Data;
using Galaxy.Web.API.Postman.Entities;
using Galaxy.Web.API.Postman.Models;
using System;
using System.Collections.Generic;

namespace Galaxy.Web.API.Postman.Services
{
    public interface ILibraryRepository
    {
        List<Author> GetAuthors();
        Author GetAuthor(Guid id);
        void AddAuthor(AuthorDto author);
        Author UpdateAuthor(AuthorDto authorDto);
        Author DeleteAuthor(Guid authorId);
        List<Book> GetBooksForAuthor(Guid authorId);
    }
}