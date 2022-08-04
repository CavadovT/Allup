using System.Collections.Generic;
using System.Threading.Tasks;

namespace Allup.Interfaces
{
    public interface IEmailService
    {
       bool SendEmail(List<string> email, string subject, string message);
    }
}
