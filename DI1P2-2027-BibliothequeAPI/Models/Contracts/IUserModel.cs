namespace DI1P2_2027_BibliothequeAPI.Models.Contracts
{
    public interface IUserModel
    {
        public uint id { get; set; }
        public string name { get; set; }
        public string firstname { get; set; }
        public IStatusModel status { get; set; }

        public void SetId(uint id)
        {
            this.id = id;
        }

        public uint GetId();
        public void SetName(string name);

        public string GetName();
        public void SetFirstname(string firstname);

        public string GetFirstname();

        public void SetStatus(IStatusModel status);
        public IStatusModel GetStatus();
    }
}