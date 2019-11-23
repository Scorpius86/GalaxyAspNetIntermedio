using Galaxy.RealTime.API.Data;
using Galaxy.RealTime.API.Entities;
using Galaxy.RealTime.API.Models;
using System;
using System.Collections.Generic;

namespace Galaxy.RealTime.API.Services
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