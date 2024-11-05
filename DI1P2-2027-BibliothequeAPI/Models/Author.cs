namespace DI1P2_2027_BibliothequeAPI.Models
{
    using DI1P2_2027_BibliothequeAPI.Models.Contracts;

    public class Author : IAuthorModel
    {
        public uint id { get; set; } = 0;
        public string name { get; set; } = "No name";
        public string firstname { get; set; } = "No firstname";
        public string description { get; set; } = "No description";

        public void SetAuthorName(string name)
        {
            this.name = name;
        }

        public string GetAuthorName()
        {
            return this.name;
        }
        public void SetAuthorFirstname(string firstName)
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
