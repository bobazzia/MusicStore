using System.ComponentModel.DataAnnotations;
using System.Linq;
using MusicStore.Data;

namespace MusicStore.CustomDataAnnotations
{
    public class MailNotExist : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var db = new MusicStoreDbContext();

            var user = db.Users.FirstOrDefault(u => u.Email == (string)value);

            if (user == null)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Mail already exists");
            }
        }
    }
}