// using customExceptions;
namespace Models
{

    public enum ticketStatus {
    Pending,    // 0
    Approved,   // 1
    Denied      // 2
    }

    public class Ticket
    {
        public int ticketID { get; set; }
        public int author_fk { get; set; }
        public int resolver_fk { get; set; }
        public string description { get; set; }
        public ticketStatus status { get; set; }
        public decimal amount { get; set; }




        // for retrieving objects from database
        public Ticket(
            int ticketID,
            int author_fk,
            int resolver_fk,
            string description,
            string status,
            decimal amount)
        {
            this.ticketID = ticketID;
            this.author_fk = author_fk;
            this.resolver_fk = resolver_fk;
            this.description = description;
            this.status = (ticketStatus) ticketStatus;
            this.amount = amount;
        }

        // for putting objects into database
        public Ticket(
            int author_fk,
            int resolver_fk,
            string description,
            ticketStatus ticketStatus,
            decimal amount
            )
        {
            this.author_fk = author_fk;
            this.resolver_fk = resolver_fk;
            this.status = (ticketStatus) ticketStatus;
            this.description = description;
            this.amount = amount;
        }

        public Ticket(){}

        public int ticketStatusToInt(string ticketStatusNotInt)
        {
           if(ticketStatusNotInt == "Pending")
            {
                return 0;
            }
            elseif(ticketStatusNotInt == "Approved") 
            {
                return 1
            } 
            else (ticketStatusNotInt == "Denied")
            { 
                return 2; 
            }
        } 

        public string ticketStatusToString(ticketStatus ticketStatusNotString)
        {
            if(ticketStatusNotString == ticketStatus.Pending)
            {
                return "Pending";
            }
            elseif(ticketStatusNotString == ticketStatus.Approved) 
            {
                return "Approved";
            } 
            else (ticketStatusNotString == ticketStatus.Denied)
            { 
                return "Denied"; 
            }
        }

        public override string ToString()
        {
            return $"ID: " + this.ticketID +
            ", Author: " + this.author_fk +
            ", Manager: " + this.resolver_fk +
            ", Status: " + this.ticketStatus +
            ", Description: " + this.description +
            ", Amount: " + this.amount;
        }

    }

}