namespace Webapi_01.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
