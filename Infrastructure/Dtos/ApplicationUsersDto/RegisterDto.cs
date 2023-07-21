using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.ApplicationUsersDto
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "البريد الالكترونى مطلوب*")]
        public string Email { get; set; }

        [Required(ErrorMessage = "اسم المستخدم مطلوب *")]
        public string UserName { get; set; }

        public IFormFile? image { set; get; }

        [Required(ErrorMessage = "كلمه المرور مطلوبه *"), MinLength(8, ErrorMessage = "كلمه المرور قصيره اقل عدد من الحروف 3 *")]
        public string Password { get; set; }

        [Required, Compare("Password",ErrorMessage ="not the same")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "رقم الهاتف مطلوب"), StringLength(11, ErrorMessage = "رقم الهاتف ينبغى ان يكون 11 رقم *")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "الاسم الاول مطلوب *"), MinLength(3, ErrorMessage = "اقل حدد من الحروف فى الاسم الاول 3*"), MaxLength(20, ErrorMessage = "اكبر عدد من الحروف فى الاسم الاول 20 حرف *")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "الاسم الاخير مطلوب *"), MinLength(3, ErrorMessage = " اقل عدد من الحروف الاخير 3 حروف"), MaxLength(20, ErrorMessage = "اكبر عدد من الحروف فى الاسم الاخير 20 حرف *")]
        public string LastName { get; set; }
    }
}
