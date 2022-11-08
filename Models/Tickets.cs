namespace test_csharp.Models
{
    public class Tickets
    {
        public int Id {get;set;}
        public string Ticket_name {get;set;}
        public string Description {get;set;}
        public double Price {get;set;}
        public DateTime Created => DateTime.Now;
        public int Serie {get;set;}
    }
}