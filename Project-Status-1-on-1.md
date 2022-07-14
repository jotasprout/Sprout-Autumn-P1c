# Project Status
- 0 errors
- 1 bug 

**Bug:** While an incorrect password (with existing userName) kicks a user out, a non-existent userName let's them in regardless.
**Cause:** The way I built the menus and/or incomplete try/throw/catch blocks
**Solution(s):** 
- Move the displayEmployeeMenu and displayManagerMenu bits somewhere more appropriate
- Working on this helped me understand throw/Catch so use that insight to build them properly here and elsewhere

## Working Functionality
- Initial menu offers: Login, Register, Exit
- Depending on userRole (Manager or Employee), logging in displays a menu with their respective choices
    - AuthServices saves current user's info long enough to display the Employee Menu but then loses it

    - **EmployeeMenu:** Can view their own tickets, or create new ticket
        - getTicketsByUserName works but I can't get the app to remember the user's information long enough to use it here. OMG I just figured out how! DisplayEmployeeMenu and DisplayManagerMenu will both take arguments that include userRole!

    - **ManagerMenu:** Choices:
        - Create a New Ticket IN PROGRESS
        - View My Tickets (uses getTicketsByUserName see above)
        - View Ticket by TicketID - To Do ... easy
        - View Tickets by UserName (for some reason, doing it from here says invalid column name)
        - View Tickets by Status - To Do ... easy
        - View Entire User List = YES
        - View Entire Ticket  = YES
- Create User
- Login

## Major To Do
- Finish CreateTicket method
- Figure out how to keep current user's creds in memory across classes (just did!)
- Finish Ticket creation
- Build updateTicket method
- WebAPI
- Controllers
- Endpoint mapping

## Minor To Do
- Implement DRY by breaking up several existing methods into smaller chunks and put those where they belong.
- ConnectionFactory
- Filter tickets by 
    - status
    - userID (author_fk)
    - ticketID

## Wish List
- Total amount for all requests by author_fk
