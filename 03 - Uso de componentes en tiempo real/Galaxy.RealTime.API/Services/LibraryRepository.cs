using AutoMapper;
using Galaxy.RealTime.API.Data;
using Galaxy.RealTime.API.Entities;
using Galaxy.RealTime.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.RealTime.API.Services
{
    public class LibraryRepository: ILibraryRepository
    {
        public LibraryContext _libraryContext { get; set; }

        public LibraryRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public List<Author> GetAuthors()
        {
            return _libraryContext.Authors.ToList();
        }

        public Author GetAuthor(Guid id)
        {
            return _libraryContext.Authors.FirstOrDefault(author => author.Id == id);
        }

        public void AddAuthor(AuthorDto authorDto)
        {
            authorDto.Id = Guid.NewGuid();
            Author author = new Author();
            Mapper.Map(authorDto, author);
            _libraryContext.Authors.Add(author);
            _libraryContext.SaveChanges();
        }

        public List<Book> GetBooksForAuthor(Guid authorId)
        {
            var query = from b in _libraryContext.Books
                        where b.AuthorId == authorId
                        select b; 

            return query.ToList();
        }

        public Author UpdateAuthor(AuthorDto authorDto)
        {
            Author author = GetAuthor(authorDto.Id);
            Mapper.Map(authorDto, author);

            _libraryContext.Update(author);
            _libraryContext.SaveChanges();
            return author;
        }

        public Author DeleteAuthor(Guid authorId)
        {
            Author author = GetAuthor(authorId);
            _libraryContext.Authors.Remove(author);
            _libraryContext.SaveChanges();

            return author;
        }
    }
}
