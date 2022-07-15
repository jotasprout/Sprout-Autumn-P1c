using Models;
using Sensitive;
using CustomExceptions;
// using Services;
using System.Data.SqlClient;

namespace DataAccess;

// The only purpose of DAO or DataAccess layer is to talk to the database

public class TicketRepository
{
    public static string connectionString = "Server=tcp:autumn-server.database.windows.net,1433;Initial Catalog=AutumnDB;Persist Security Info=False;User ID=supremeadmin;Password=" + SensitiveVariables.dbpassword + ";MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    public string thoseAll = "select * from AutumnERS.tickets;";

    public List<Ticket> GetTickets(string those)
    {

        List<Ticket> tickets = new List<Ticket>();
        SqlConnection makeConnection = new SqlConnection(connectionString);
        SqlCommand getEveryTicket = new SqlCommand(those, makeConnection);

        try
        {
            makeConnection.Open();
            SqlDataReader reader = getEveryTicket.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                tickets.Add(new Ticket((int)reader[0], (int)reader[1], (int)reader[2], (string)reader[3], (string)reader[4], (decimal)reader[5]));
            }
            reader.Close();
            makeConnection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return tickets;
    }


    public List<Ticket> GetAllTickets()
    {
        List<Ticket> allTickets = new List<Ticket>();
        GetTickets(thoseAll);
        return allTickets;
    }

    public List<Ticket> GetTicketsByUserName(string userIWantTicketsFor)
    {
        User userInQuestion = new UserRepository().GetUserByUserName(userIWantTicketsFor);
        int userID = userInQuestion.userID;
        string byUserQueryWithID = "select * from AutumnERS.tickets where author_fk = " + userID + ";";
        List<Ticket> TicketsFromPeepIWant = new List<Ticket>(); 
        GetTickets(byUserQueryWithID);
        return TicketsFromPeepIWant;
    }

    public List<Ticket> GetTicketsByUserID(string userIWantTicketsFor)
    {
        string byUserQueryWithID = "select * from AutumnERS.tickets where author_fk = " + userIWantTicketsFor + ";";
        List<Ticket> TicketsFromPeepIWant = new List<Ticket>(); 
        GetTickets(byUserQueryWithID);
        return TicketsFromPeepIWant;
    }

    public List<Ticket> GetTicketsByStatus()
    {
        Console.WriteLine("Choose a status.");
        Console.WriteLine("[1] Approved");
        Console.WriteLine("[2] Denied");
        Console.WriteLine("[3] Pending");            
        string thisStatus = Console.ReadLine();
        switch (thisStatus)
        {
            case "1": // Approved
                thisStatus = "Approved";
                break;
            case "2": // Denied
                thisStatus = "Denied";                   
                break;  
            case "3": // Pending
                thisStatus = "Pending";                    
                break;                    
            default:
                Console.WriteLine("What kind of nonsense was that?");
                break;
        }         
        string thoseStatusTickets = "select * from AutumnERS.tickets where status = '" + thisStatus + "';";
        List<Ticket> statusTickets = new List<Ticket>();
        GetTickets(thoseStatusTickets);
        return statusTickets;
    }  

    public List<Ticket> GrabTicketByTicketID(string ticketID)
    {
        string byTicketID = "select * from AutumnERS.tickets where ticketID = " + ticketID + ";";
        List<Ticket> ticketIWant = new List<Ticket>(); 
        GetTickets(byTicketID);
        return ticketIWant;  
        // Console.WriteLine("What do you want to do?");
        // Console.WriteLine("[1] Resolve this ticket.");
        // Console.WriteLine("[2] Exit.");
        // string input = Console.ReadLine();
        // switch (input)
        // {
        //     case "1": // Resolve
        //         ResolveThisTicket(ticketID);
        //         break;
        //     case "2": // Exit
        //         Console.WriteLine("Goodbye.");
        //         Environment.Exit(0);
        //         break;
        //     default:
        //         Console.WriteLine("What kind of nonsense was that?");
        //         break;
        // }        
    }

    public List<Ticket> ResolveThisTicket(string ticketID)
    {
        List<Ticket> ticketToUpdate = new List<Ticket>();

        Console.WriteLine("Approve or Deny?");
        Console.WriteLine("[1] Approve");
        Console.WriteLine("[2] Deny");
        string newStatus = Console.ReadLine();
        switch (newStatus)
        {
            case "1": // Approve
                newStatus = "Approved";
                break;
            case "2": // Deny
                newStatus = "Denied";                   
                break;                   
            default:
                Console.WriteLine("What kind of nonsense was that?");
                break;
        } 

        string updateTicketStatement = "UPDATE AutumnERS.tickets SET status = '@status' WHERE ticketID = @ticketID;";
        // UPDATE AutumnERS.tickets SET status = 'Approved' WHERE ticketID = 16;
        SqlConnection makeConnection = new SqlConnection(connectionString);
        SqlCommand updateTicket = new SqlCommand(updateTicketStatement, makeConnection);
        
        updateTicket.Parameters.AddWithValue("@ticketID", ticketID);
        updateTicket.Parameters.AddWithValue("@status", newStatus);

        try
        {
            makeConnection.Open();
            int itWorked = updateTicket.ExecuteNonQuery();
            makeConnection.Close();
            if (itWorked != 0)
            {
                Console.WriteLine("Ticket updated.");
                List<Ticket> updatedTicket = GrabTicketByTicketID(ticketID);
                return updatedTicket;
            }
            else
            {
                Console.WriteLine("Sorry, that didn't seem to work.");
                throw new ResourceNotFound();
            }
        }
        catch (ResourceNotFound e)
        {
            Console.WriteLine(e.Message);
        }

        return ticketToUpdate;
    }

    // public List<Ticket> CreateTicket(newTicket)
    // {
    //     string createTicketSQL = "insert into AutumnERS.tickets (author_fk, description, amount) values (@author, @description, @amount);";

    //     SqlConnection makeConnection = new SqlConnection(connectionString);
    //     User ticketAuthor;
    //     ticketAuthor = new UserRepository().GetUserByUserName
    //     SqlCommand createThisTicket = new SqlCommand(createTicketSQL, makeConnection);

    //     createThisTicket.Parameters.AddWithValue("@author", newTicket.)

    //     // List<Ticket> allTicketsByUserName = new List<Ticket>();
    //     // GetTickets(TicketsByUserName);
    //     // return allTicketsByUserName;
    //     throw new ResourceNotFound();
    // }

    // GET TICKET BY STATUS

}
