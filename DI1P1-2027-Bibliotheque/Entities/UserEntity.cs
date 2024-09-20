using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI1P1_2027_Bibliotheque.Entities
{
    public class UserEntity
    {
        private uint id = 0;
        private string name = "No name";
        private string firstname = "No firstname";
        private StatusEntity status = new();
        
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
        public void SetFirstname(string firstname)
        {
            this.firstname = firstname;
        }

        public string GetFirstname()
        {
            return this.firstname;
        }

        public void SetStatus(StatusEntity status)
        {
            this.status = status;
        }
        public StatusEntity GetStatus()
        {
            return this.status;
        }
    }
}
