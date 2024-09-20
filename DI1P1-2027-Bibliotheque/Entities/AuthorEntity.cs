using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI1P1_2027_Bibliotheque.Entities
{
    public class AuthorEntity
    {
        private uint id = 0;
        private string name = "No name";
        private string firstname = "No firstname";
        private string description = "No description";

        public void SetAuthorName(string name)
        {
            this.name = name;
        }

        public string GetAuthorName()
        {
            return this.name;
        }
        public void SetAuthorFirstName(string firstName)
        {
            this.firstname = firstName;
        }
        public string GetAuthorFirstname()
        {
            return this.firstname;
        }

        public void SetDescription(string description)
        {
            this.description = description;
        }
        public string GetDescription()
        {
            return this.description;
        }

        public void SetId(uint id)
        {
            this.id = id;
        }
        public uint GetId()
        {
            return this.id;
        }
    }
}
