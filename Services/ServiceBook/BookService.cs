﻿using BeamX_Task.Context;
using BeamX_Task.Models;
using BeamX_Task.ViewModels;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Net;

namespace BeamX_Task.Services.ServiceBook
{
    public class BookService : IBook
    {
        private MyDbContext ctx;

        public BookService(MyDbContext ctx)
        {
            this.ctx = ctx;
        }
        public string Delete(int id)
        {
            Book deletebook = ctx.Books.Where(val => val.BookId == id).FirstOrDefault(); 
            if(deletebook!=null)
            {
                ctx.Books.Remove(deletebook);
                int rowsupdated = ctx.SaveChanges();
                if (rowsupdated > 0)
                {
                    return "Data Deleted Successfully!!!";
                }
            }
            return "Something went Wrong!!!";


        }

        public List<Book> GetAllBooks()
        {
            List<Book> BooksList = ctx.Books.Include(b => b.BookAuthors).ThenInclude(b => b.Author).ToList();
            return BooksList;
        }

        public Book GetBookById(int id)
        {
            Book book = ctx.Books.Include(b => b.BookAuthors).ThenInclude(b => b.Author).Where(b => b.BookId == id).FirstOrDefault();
            return book;
        }

        public string Save(Book book,int AuthorId)
        {
            Author author = ctx.Authors.Where(val=>val.AuthorId==AuthorId).FirstOrDefault();
            if(author!=null)
            {
                book.BookAuthors = new List<BookAuthor>
                {
                    new BookAuthor
                    {
                        AuthorId=author.AuthorId,
                        Author=author,
                        BookId=book.BookId,
                        Book=book,
                    }
                };
            }
            ctx.Books.Add(book);
            int rowsupdated=ctx.SaveChanges();
            if(rowsupdated>0)
            {
                return "Data Saved Successfully!!!";
            }
            return "Something went Wrong!!!";
        }

        public string Update(Book updatedbook, int AuthorId)
        {
            // get the existing book from database
            Book existingbook = ctx.Books.Include(val => val.BookAuthors).Where(val => val.BookId == updatedbook.BookId).FirstOrDefault();
            if(existingbook!=null)
            {
                existingbook.Title=updatedbook.Title;
                existingbook.Description=updatedbook.Description;
                existingbook.BookAuthors.Clear();
                // get author from db

                Author author = ctx.Authors.Where(val => val.AuthorId == AuthorId).FirstOrDefault();
                if(author!=null)
                {
                    BookAuthor bookAuthor = new BookAuthor
                    {
                        AuthorId = author.AuthorId,
                        Author = author,
                        BookId = updatedbook.BookId,
                        Book = updatedbook

                    };
                    existingbook.BookAuthors.Add(bookAuthor);
                }
                int rowsupdated=ctx.SaveChanges();  
                if(rowsupdated>0)
                {
                    return "Data Updated Successfully!!!";
                }
                else
                {
                    return "Something went wrong!!!";
                }
            }
            else
            {
                return "Book no Found";
            }
        }
    }
}




