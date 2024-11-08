﻿namespace DI1P2_2027_BibliothequeAPI.Models
{
    using DI1P2_2027_BibliothequeAPI.Models.Contracts;
    public class User:IUserModel
    {
        public uint id { get; set; } = 0;
        public string name { get; set; } = "No name";
        public string firstname { get; set; } = "No firstname";
        public uint statusId { get; set; }
        public Status statusCast { get; set; } = new Status();
        public string password {  get; set; } = string.Empty;
        IStatusModel IUserModel.status { get => statusCast; set => statusCast = (Status)value; }

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

        public void SetStatus(IStatusModel status)
        {
            this.statusCast = (Status)status;
        }
        public IStatusModel GetStatus()
        {
            return this.statusCast;
        }
    }
}
