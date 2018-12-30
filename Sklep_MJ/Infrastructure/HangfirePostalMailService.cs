using System;
using System.Web;
using Sklep_MJ.Models;
using Hangfire;
using System.Web.Mvc;

namespace Sklep_MJ.Infrastructure
{
    public class HangfirePostalMailService : IMailService
    {
        public void SendConfirmOrderEmail(Order order)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            string url = urlHelper.Action("SendConfirmOrderEmail", "Manage", new { orderId = order.OrderId, secondName = order.SecondName }, HttpContext.Current.Request.Url.Scheme);

            BackgroundJob.Enqueue(() => Helpers.CallUrl(url));
        }

        public void SendFinishedOrderEmail(Order order)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            string url = urlHelper.Action("SendFinishedOrderEmail", "Manage", new { orderId = order.OrderId, secondName = order.SecondName }, HttpContext.Current.Request.Url.Scheme);

            BackgroundJob.Enqueue(() => Helpers.CallUrl(url));
        }
    }
}