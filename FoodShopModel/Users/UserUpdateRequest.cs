using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopModel.Users
{
    public class UserUpdateRequest
    {
        public Guid Id { get; set; }

        [Display(Name = "Họ và tên")]
        public string Name { get; set; }

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime DayOfBirth { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Tên")]
        public string LastName { get; set; }

        [Display(Name = "Họ")]
        public string FirstName { get; set; }
    }
}
