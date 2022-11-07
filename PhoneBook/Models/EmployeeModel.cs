using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Models
{
    public class EmployeeModel
    {
        [Key]
        public int EmployeeId { get; set; }
        [DisplayName("Imię i nazwisko")]
        public string Name { get; set; }
        [DisplayName("Telefon")]
        public string Phone { get; set; }
        public string Email { get; set; }
        [DisplayName("Dział")]
        public string Department { get; set; }
        [DisplayName("Stanowisko")]
        public string? Title { get; set; }
        public string LastName { get; set; }
    }
}
