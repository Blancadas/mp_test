using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mp_test.DAL;

namespace mp_test.Models
{
    public class ThreadEntity
    {
        public ThreadEntity()
        {
            Messages = new List<Message>();
        }

        public ThreadEntity(MPContext mpContext, string executorId, int offerId, int userId, string userName)
        {
            ExecutorId = executorId;
            OfferId = offerId;
            AuthorId = userId;
            AuthorTitle = userName;

            Messages = new List<Message>();

            Messages = GetMessages(mpContext, executorId, offerId);

        }

        public string ExecutorId { get; set; }
        public int OfferId { get; set; }
        public int AuthorId { get; set; }
        public string AuthorTitle { get; set; }
        public DateTime LastMessageDateTime { get; set; }
        public string LastMessageText { get; set; }
        public List<Message> Messages { get; set; }

        public List<Message> GetMessages(MPContext mpContext, string executorId, int offerId)
        {
            return mpContext.Message.Where(m => m.Thread.RecepientId == executorId && m.Thread.Offer.Id == offerId).OrderBy(m => m.CreatedDateTime).ToList();
        }
    }

    public class ThreadModel
    {
        public ThreadModel()
        {
            ThreadList = new List<ThreadEntity>();
        }

        public List<ThreadEntity> ThreadList { get; set; }
    }
}