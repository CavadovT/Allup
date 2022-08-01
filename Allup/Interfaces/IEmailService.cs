using System.Collections.Generic;
using System.Threading.Tasks;

namespace Allup.Interfaces
{
    public interface IEmailService
    {
       bool SendEmail(string email, string subject, string message);
    }
}
