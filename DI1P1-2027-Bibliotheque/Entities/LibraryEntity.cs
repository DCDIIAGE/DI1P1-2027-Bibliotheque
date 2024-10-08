﻿using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI1P1_2027_Bibliotheque.Entities
{
    public class LibraryEntity
    {
        private readonly List<BookEntity> books = [];
        private readonly List<BorrowEntity> borrows = [];
        private readonly List<AuthorEntity> authors = [];
        private readonly List<StatusEntity> statuses = [];
        private readonly List<UserEntity> users = [];

        public void SetBook(BookEntity book)
        {
            if(this.books.FindIndex(b => b.GetIsbn() == book.GetIsbn()) > -1)
            {
                this.books[this.books.FindIndex(b => b.GetIsbn == book.GetIsbn)] = book;
            }
        }
        public void SetBorrow(BorrowEntity borrow)
        {
            if (this.borrows.FindIndex(b => b.GetId() == borrow.GetId()) > -1)
            {
                this.borrows[this.borrows.FindIndex(b => b.GetId() == borrow.GetId())] = borrow;
            }
        }
        public void SetAuthor(AuthorEntity author)
        {
            if (this.authors.FindIndex(b => b.GetId() == author.GetId()) > -1)
            {
                this.authors[this.borrows.FindIndex(b => b.GetId() == author.GetId())] = author;
            }
        }
        public List<BookEntity> GetAllBooks()
        {
            return this.books;
        }

        public List<BookEntity> GetAllBooksByAuthors(AuthorEntity author)
        {
            return this.books.Where(b => b.GetAuthor() == author).ToList();
        }
        public List<BookEntity> GetAllBooksByAuthorId(uint authorid)
        {
            return this.books.Where(b => b.GetAuthor().GetId() == authorid).ToList();
        }
        public List<BookEntity> GetAllBooksByAuthorName(string authorname)
        {
            return this.books.Where(b => b.GetAuthor().GetAuthorName() == authorname).ToList();
        }

        public List<BookEntity> GetAllBooksByAuthorFirstname(string authorfirstname)
        {
            return this.books.Where(b => b.GetAuthor().GetAuthorFirstname() == authorfirstname).ToList();
        }

        public List<BookEntity> GetAllBooksByPublishDate(string publishdate)
        {
            return this.books.Where(b => b.GetPublishDate() == publishdate).ToList();
        }

        public BookEntity GetBookByIsbn(uint isbn)
        {
            return this.books.FirstOrDefault(b => b.GetIsbn() == isbn) ?? new();
        }
        public List<BorrowEntity> GetAllBorrows()
        {
            return this.borrows;
        }
        public List<BorrowEntity> GetAllBorrowsByUser(UserEntity user)
        {
            return this.borrows.Where(b => b.GetUser() == user).ToList();
        }
        public List<BorrowEntity> GetAllBorrowsByUserName(string username)
        {
            return this.borrows.Where(b => b.GetUser().GetName() == username).ToList();
        }
        public List<BorrowEntity> GetAllBorrowsByUserFirstname(string userfirstname)
        {
            return this.borrows.Where(b => b.GetUser().GetFirstname() == userfirstname).ToList();
        }
        public List<BorrowEntity> GetAllBorrowsByUserId(uint userid)
        {
            return this.borrows.Where(b => b.GetUser().GetId() == userid).ToList();
        }
        public List<BorrowEntity> GetAllBorrowsByUserStatus(StatusEntity userstatus)
        {
            return this.borrows.Where(b => b.GetUser().GetStatus() == userstatus).ToList();
        }
        public List<BorrowEntity> GetAllBorrowsByUserStatusId(uint userstatusid)
        {
            return this.borrows.Where(b => b.GetUser().GetStatus().GetId() == userstatusid).ToList();
        }
        public List<BorrowEntity> GetAllBorrowByStatusName(string userstatusname)
        {
            return this.borrows.Where(b => b.GetUser().GetStatus().GetName() == userstatusname).ToList();
        }
        public List<BorrowEntity> GetAllBorrowByStatusMaxBook(uint userstatusmaxbook)
        {
            return this.borrows.Where(b => b.GetUser().GetStatus().GetMaxBooks() == userstatusmaxbook).ToList();
        }

        public BorrowEntity GetBorrowById(uint id)
        {
            return this.borrows.Find(b => b.GetId() == id) ?? new BorrowEntity();
        }
        public List<AuthorEntity> GetAllAuthors()
        {
            return this.authors;
        }
        public List<AuthorEntity> GetAllAuthorsByName(string authorname)
        {
            return this.authors.Where(author => author.GetAuthorName() == authorname).ToList();
        }

        public List<AuthorEntity> GetAllAuthorsByFirstname(string authorfirstname)
        {
            return this.authors.Where(author => author.GetAuthorFirstname() == authorfirstname).ToList();
        }
        public AuthorEntity GetAuthorById(uint id)
        {
            return this.authors.FirstOrDefault(author => author.GetId() == id) ?? new();
        }

        public List<UserEntity> GetAllUsers()
        {
            return this.users;
        }
        public List<UserEntity> GetAllUsersByName(string username)
        {
            return this.users.Where(user => user.GetName() == username).ToList();
        }
        public List<UserEntity> GetAllUsersByFirstname(string userfirstname)
        {
            return this.users.Where(user => user.GetFirstname() == userfirstname).ToList();
        }
        public UserEntity GetUserById(uint id)
        {
            return this.users.FirstOrDefault(user => user.GetId() == id) ?? new();
        }
        public List<StatusEntity> GetAllStatuses()
        {
            return this.statuses;
        }
        public List<StatusEntity> GetAllStatusesByName(string statusname)
        {
            return this.statuses.Where(status =>  status.GetName() == statusname).ToList();
        }
        public List<StatusEntity> GetAllStatusesByMaxBook(uint maxbook)
        {
            return this.statuses.Where(status => status.GetMaxBooks() == maxbook).ToList();
        }
        public List<StatusEntity> GetAllStatusesWhereMaxBookIsGreaterThan(uint maxbook)
        {
            return this.statuses.Where(status => status.GetMaxBooks() > maxbook).ToList();
        }
        public List<StatusEntity> GetAllStatusesWhereMaxBookIsLessThan(uint minbook)
        {
            return this.statuses.Where(status => status.GetMaxBooks() < minbook).ToList();
        }
        public StatusEntity GetStatusById(uint id)
        {
            return this.statuses.FirstOrDefault(status => status.GetId() == id) ?? new();
        }
        public void AddBook(BookEntity book)
        {
            this.books.Add(book);
        }
        public void AddBorrow(BorrowEntity borrow)
        {
            this.borrows.Add(borrow);
        }
        public void AddAuthor(AuthorEntity author)
        {
            this.authors.Add(author);
        }
        public void AddUser(UserEntity user)
        {
            this.users.Add(user);
        }
        public void AddStatus(StatusEntity status)
        {
            this.statuses.Add(status);
        }
        public void RemoveBookByIsbn(uint isbn)
        {

        }
        public void RemoveAllBooksByAuthor(AuthorEntity author)
        {

        }
        public void RemoveAllBooksByAuthorId(string authorid)
        {

        }
        public void RemoveAllBooksByAuthorName(string authorname)
        {

        }
        public void RemoveAllBooksByAuthorFirstname(string authorfirstname)
        {

        }
        public void RemoveBorrowById(uint borrowid)
        {

        }
        public void RemoveAllBorrowsByBook(BookEntity book)
        {

        }
        public void RemoveAllBorrowsByBookIsbn(uint isbn)
        {

        }
        public void RemoveAllBorrowsByBookPublishDate(string publishdate)
        {

        }
        public void RemoveAllBorrowsByBookAuthor(AuthorEntity bookauthor)
        {

        }
        public void RemoveAllBorrowsByBookAuthorId(uint bookauthorid)
        {

        }
        public void RemoveAllBorrowsByBookAuthorName(string bookauthorname)
        {

        }
        public void RemoveAllBorrowsByBookAuthorFirstname(string bookauthorfirstname)
        {

        }

        public void RemoveAllBorrowsByUser(UserEntity user)
        {

        }
        public void RemoveAllBorrowsByUserId(uint userid)
        {

        }
        public void RemoveAllBorrowsByUserName(string username)
        {

        }
        public void RemoveAllBorrowsByUserFirstname(string userfirstname)
        {

        }
        public void RemoveAllBorrowsByUserStatus(StatusEntity userstatus)
        {

        }
        public void RemoveAllBorrowsByUserStatusId(uint userstatusid)
        {

        }
        public void RemoveAllBorrowsByUserStatusName(string userstatusname)
        {

        }

        public bool IsIsbnExist(uint isbn)
        {
            return this.books.Any(book => book.GetIsbn() == isbn);
        }
    }
}
