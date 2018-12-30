using Sklep_MJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_MJ.Infrastructure
{
    public interface IMailService
    {
        void SendConfirmOrderEmail(Order order);
        void SendFinishedOrderEmail(Order order);
    }
}
