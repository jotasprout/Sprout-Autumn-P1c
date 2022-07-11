namespace Models
{

    public enum userRole
    {
        Employee,Manager
    }

    public class User
    {
        public int userID { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public userRole userRole { get; set; }

        // for retrieving objects from database
        public User(
            int userID,
            string userName,
            string password,
            userRole userRole)
        {
            this.userID = userID;
            this.userName = userName;
            this.password = password;
            this.userRole = userRole;
        }

        // for putting objects into database
        public User(
            string userName,
            string password,
            userRole userRole)
        {
            this.userName = userName;
            this.password = password;
            this.userRole = (userRole) userRole;
        }

        // for logging in
        public User(
            string userName,
            string password)
        {
            this.userName = userName;
            this.password = password;
        }

        public User (){}

        public override string ToString()
        {
            return "ID: " + this.userID +
            ", username: " + this.userName +
            ", Password: " + this.password +
            ", Role: " + this.userRole;
        }

    }
}