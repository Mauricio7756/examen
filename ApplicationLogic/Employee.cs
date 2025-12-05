namespace ApplicationLogic
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string? Title { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? HomePhone { get; set; }
        public string? Extension { get; set; }
    }
}
