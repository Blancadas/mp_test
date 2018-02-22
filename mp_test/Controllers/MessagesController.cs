using mp_test.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mp_test.Models;
using Microsoft.AspNet.Identity;

namespace mp_test.Controllers
{
    public class MessagesController : Controller
    {
        // GET: Messages
        public ActionResult Index()
        {
          ThreadModel myThreads = new ThreadModel();

          using (var ctx = new MPContext())
          {
            var currentUserId = User.Identity.GetUserId();
            var threadList = from th in ctx.Thread
              orderby th.CreatedDateTime descending
              where th.AuthorId == currentUserId || th.RecepientId == currentUserId
              select th;

            foreach (Thread thread in threadList)
            {
              ThreadEntity newThread = new ThreadEntity();

              var executorVal = (from executor in ctx.Executor
                where executor.UserId == currentUserId
                select executor).FirstOrDefault();

              var customerVal = (from customer in ctx.Customer
                where customer.UserId == currentUserId
                select customer).FirstOrDefault();

              var userTitle = executorVal != null ? executorVal.Title : customerVal.Title;

              var lastMessage = (from message in ctx.Message
                orderby message.CreatedDateTime descending
                where message.Thread.Id == thread.Id
                select message).FirstOrDefault();

              newThread.AuthorTitle = userTitle;
              newThread.LastMessageDateTime = lastMessage.CreatedDateTime;
              newThread.LastMessageText = lastMessage.MessageText;

              myThreads.ThreadList.Add(newThread);

            }

          }

          return View("ThreadList", myThreads);
        }

        public ActionResult Conversation(string executorId, int offerId)
        {
            ThreadEntity currentThread;

            using (var ctx = new MPContext())
            {
                var currentUserId = User.Identity.GetUserId();
                var currentUserName = User.Identity.Name;

                var executorVal = (from executor in ctx.Executor
                    where executor.UserId == currentUserId
                    select executor).FirstOrDefault();

                var customerVal = (from customer in ctx.Customer
                    where customer.UserId == currentUserId
                    select customer).FirstOrDefault();

                var userId = executorVal != null ? executorVal.Id : customerVal.Id;

                currentThread = new ThreadEntity(ctx , executorId, offerId, userId, currentUserName);
            }

            return View("Conversation", currentThread);
        }

        public JsonResult GetMessages(string executorId, int offerId)
        {
            var result = new LinkedList<object>();

            using (var ctx = new MPContext())
            {
                List<Message> messages = ctx.Message.Where(m => m.Thread.RecepientId == executorId && m.Thread.Offer.Id == offerId).OrderBy(m => m.CreatedDateTime).ToList();

                foreach (var message in messages)
                {
                    result.AddLast(new
                    {
                        Username = message.AuthorId,
                        PostDateTime = message.CreatedDateTime.ToString("dd MMMM yyyy hh:mm"),
                        MessageBody = message.MessageText,
                        ThreadId = message.Thread.Id
                    });
                }

            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddMessage(Message message, int offerId, int? threadId)
        {
            var result = new { message = string.Empty }; 
            using (var ctx = new MPContext())
            {
                if (threadId == null)
                {
                    var curOffer = ctx.Offer.First(offer => offer.Id == offerId);

                    Thread newThread = new Thread();
                    newThread.CreatedDateTime = DateTime.Now;
                    newThread.AuthorId = message.AuthorId;
                    newThread.RecepientId = message.RecepientId;
                    newThread.Offer = curOffer;

                    ctx.Thread.Add(newThread);
                    ctx.SaveChanges();

                    message.Thread = newThread;
                }

                message.CreatedDateTime = DateTime.Now;
                ctx.Message.Add(message);
                ctx.SaveChanges();
                result = new { message = "Success" };
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}