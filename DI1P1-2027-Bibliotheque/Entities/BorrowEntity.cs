using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI1P1_2027_Bibliotheque.Entities
{
    public class BorrowEntity
    {
        private uint id = 0;
        private BookEntity book = new BookEntity();
        private UserEntity user = new UserEntity();
        private DateTime date = DateTime.Now;

        public void SetId(uint id)
        {
            this.id = id;
        }
        public uint GetId()
        {
            return this.id;
        }
        public void SetBook(BookEntity book)
        {
            this.book = book;
        }
        public BookEntity GetBook()
        {
            return this.book;
        }
        public void SetUser(UserEntity user)
        {
            this.user = user;
        }
        public UserEntity GetUser()
        {
            return this.user;
        }
    }
}
