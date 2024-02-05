using AwesomeNetwork.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeNetwork.Data.Repository
{
    public class MessageRepository : Repository<Message>
    {
        public MessageRepository(ApplicationDbContext db)
        : base(db)
        {

        }
        public List<Message> GetMessages(User sender, User recipient) 
        {
            Set.Include(x => x.RecipientId);
            Set.Include(x => x.SenderId);

            var from = Set.AsEnumerable().Where(x => x.SenderId == sender.Id && x.RecipientId == recipient.Id);
            var to = Set.AsEnumerable().Where(x => x.SenderId == recipient.Id && x.RecipientId == sender.Id);

            var chatMessages = new List<Message>();
            chatMessages.AddRange(from);
            chatMessages.AddRange(to);
            chatMessages.OrderBy(x => x.Id);

            return chatMessages;
        }
    }
}
