using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI1P1_2027_Bibliotheque.Entities
{
    public class StatusEntity
    {
        private uint id = 0;
        private string name = "No name";
        private uint maxBooks = 0;

        public void SetId(uint id)
        {
            this.id = id;
        }
        
        public uint GetId()
        {
            return this.id;
        }

        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetName()
        {
            return this.name;
        }

        public void SetMaxBooks(uint maxBooks)
        {
            this.maxBooks = maxBooks;
        }
        public uint GetMaxBooks()
        {
            return this.maxBooks;
        }
    }
}
