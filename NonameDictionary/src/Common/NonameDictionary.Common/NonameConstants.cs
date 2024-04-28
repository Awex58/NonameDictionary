using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonameDictionary.Common
{
    public class NonameConstants
    {
        public const string RabbitMQHost = "localhost";
        public const string DefaultExchangeType = "direct";

        public const string UserExchangeName = "UserExchange";
        public const string VoteExchangeName = "VoteExchange";
        public const string FavExchangeName = "FavExchange";


        public const string UserEmailChangedQueueName = "UserEmailChangedQueue";

       
        
        public const string CreateEntryFavQueueName = "CreateEntryFavQueue";

        public const string CreateEntryVoteQueueName = "CreateEntryVoteQueue";

        public const string DeleteEntryFavQueueName = "DeleteEntryFavQueue";

        public const string DeleteEntryVoteQueueName = "DeleteEntryVoteQueue";




        public const string DeleteEntryCommentVoteQueueName = "DeleteEntryCommentVoteQueue";

        public const string DeleteEntryCommentFavQueueName = "DeleteEntryCommentFavQueue";
        
        public const string CreateEntryCommentVoteQueueName = "CreateEntryCommentVoteQueue";

        public const string CreateEntryCommentFavQueueName = "CreateEntryCommentFavQueue";




    }
}
