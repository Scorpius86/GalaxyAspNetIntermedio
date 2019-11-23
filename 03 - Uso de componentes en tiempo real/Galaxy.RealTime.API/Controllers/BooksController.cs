using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Galaxy.RealTime.API.Data;
using Galaxy.RealTime.API.Entities;
using Galaxy.RealTime.API.Models;
using Galaxy.RealTime.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Galaxy.RealTime.API.Controllers
{
    [Route("api/authors/{authorId}/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private ILibraryRepository _libraryRepository;
        public BooksController(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        public List<BookDto> GetBooksForAuthor(Guid authorId)
        {
            List<Book> booksRepo = _libraryRepository.GetBooksForAuthor(authorId);
            List<BookDto> books = Mapper.Map<List<BookDto>>(booksRepo);

            return books;
        }
    }
}