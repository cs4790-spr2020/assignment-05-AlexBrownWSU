using System;
using BlabberApp.Domain.Interfaces;

namespace BlabberApp.Domain.Entities
{
    public class Blab : IEntity
    {
        public Blab()
        {
            this.User = new User();
            this.Message = "";
        }
        public Blab(string Message)
        {
            this.User = new User();
            this.Message = Message;
        }
        public Blab(User user)
        {
            this.User = user;
            this.Message = "";
        }
        public Blab(string Message, User user)
        {
            this.User = user;
            this.Message = Message;
        }
        public Guid Id {get; set;}
        public string Message { get; set; }
        public User User { get; set; }
        public bool IsValid()
        {
            // Add code to validate class data.
            return true;
        }
    }
}