namespace DI1P2_2027_BibliothequeAPI.Models.Contracts
{
    public interface IAuthorModel
    {
        public uint id { get; set; }
        public string name { get; set; }
        public string firstname {  get; set; }
        public string description { get; set; }

        public void SetAuthorName(string name);

        public string GetAuthorName();
        public void SetAuthorFirstname(string firstName);
        public string GetAuthorFirstname();

        public void SetDescription(string description);

        public string GetDescription();

        public void SetId(uint id);
        public uint GetId();
    }
}
