using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sklep_MJ.Models;
using Sklep_MJ.ViewModels;

namespace Sklep_MJ.Infrastructure
{
    public class PostalMailService : IMailService
    {
        public void SendConfirmOrderEmail(Order order)
        {
            OrderConfirmationEmail email = new OrderConfirmationEmail();
            email.To = order.Email;
            email.From = "szczurek922@gmail.com";
            email.Price = order.Price;
            email.OrderId = order.OrderId;
            email.OrderPositions = order.OrderPositions;
            email.ImagePath = AppConfig.ImagePath;
            email.Send();
        }

        public void SendFinishedOrderEmail(Order order)
        {
            OrderFinishedEmail email = new OrderFinishedEmail();
            email.To = order.Email;
            email.From = "szczurek922@gmail.com";
            email.OrderId = order.OrderId;
            email.Send();
        }
    }
}