namespace DI1P2_2027_BibliothequeAPI.Models
{
    using DI1P2_2027_BibliothequeAPI.Models.Contracts;
    public class Status:IStatusModel
    {
        public uint id { get; set; } = 0;
        public string name { get; set; } = "No name";
        public uint maxBooks { get; set; } = 0;
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
