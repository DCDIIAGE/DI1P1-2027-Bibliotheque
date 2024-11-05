namespace DI1P2_2027_BibliothequeAPI.Models.Contracts
{
    public interface IStatusModel
    {
        public uint id { get; set; }
        public string name { get; set; }
        public uint maxBooks { get; set; }

        public void SetId(uint id);

        public uint GetId();
        public void SetName(string name);
        public string GetName();
        public void SetMaxBooks(uint maxBooks);
        public uint GetMaxBooks();
    }
}
