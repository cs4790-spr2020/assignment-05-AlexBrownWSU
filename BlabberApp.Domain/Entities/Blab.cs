using System;
namespace BlabberApp.Domain.Entities
{
    public class Blab : BaseEntity
    {
        public DateTime DTTM { get; set; }
        public string Message { get; set; }
        public string UserID { get; set;}

        public Blab()
        {
            DTTM = DateTime.Now;
        }
    }
}