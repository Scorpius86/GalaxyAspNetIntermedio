using AutoMapper;
using Galaxy.Web.API.Postman.Data;
using Galaxy.Web.API.Postman.Entities;
using Galaxy.Web.API.Postman.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.Web.API.Postman.Services
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
            List<Author> authors = new List<Author>();
            // var table = _libraryContext.Database.ExecuteSqlCommand("usp_ListAuthors");
            using (var command = _libraryContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "usp_ListAuthors";
                _libraryContext.Database.OpenConnection();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {                       
                        while (reader.Read())
                        {
                            Author author = new Author();
                            author.Id = reader.GetGuid(0);
                            author.Name = reader.GetString(1);
                            author.Age = reader.GetInt32(2);
                            author.Genre = reader.GetString(3);

                            authors.Add(author);
                        }
                    }
                }
            }

            return authors;
            //return _libraryContext.Authors.FromSql("usp_ListAuthors").ToList();

            //return _libraryContext.Authors.ToList();
        }

        public Author GetAuthor(Guid id)
        {
            //return _libraryContext.Authors.FirstOrDefault(author => author.Id == id);
            return _libraryContext.Authors.FromSql($"usp_GetAuthor {id}").FirstOrDefault();
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
