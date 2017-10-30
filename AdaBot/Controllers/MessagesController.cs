using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Connector;
using AdaBot.Cognitive;
using AdaBot.Dialogs;
using AdaBot.Task;
using Microsoft.Bot.Builder.Dialogs;

namespace AdaBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        private AdaEmo ae = new AdaEmo();
        private AdaVis av = new AdaVis();
        private Random rnd;
        private int num = 0;

        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                num = (rnd = new Random()).Next(0, 2);
                ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                if (activity.Attachments?.Any() == true)
                {
                    if (activity.Attachments[0].ContentType[0] == 'i')
                    {
                        using (HttpClient client = new HttpClient())
                        {
                            string resume = "";
                            MemoryStream memtmp = new MemoryStream();
                            Stream photo = await client.GetStreamAsync(activity.Attachments[0].ContentUrl);
                            photo.CopyTo(memtmp);
                            memtmp.Position = 0;
                            string describe = await av.MakeSomeSummary(memtmp.NewStream());
                            memtmp.Position = 0;
                            string emotion = await ae.MakeAboveEmotion(memtmp.NewStream());
                            if (emotion != "ничего не")
                            {
                                resume = "Хорошая картина! \n\n\u200CИнтересно. На ней я вижу как " + describe +
                                         "\n\n\u200CЕще я тут вижу " + emotion;
                            }
                            else
                            {
                                resume = "Хорошая картина! \n\n\u200CИнтересно. Я здесь вижу " + describe;
                            }
                            Activity reply = activity.CreateReply(resume);
                            await connector.Conversations.ReplyToActivityAsync(reply);
                        }
                    }
                } else if (num == 1)
                {
                    await Conversation.SendAsync(activity, () => new DialogTask());
                } else
                {
                    await Conversation.SendAsync(activity, () => new DialogWit());
                }
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
            }
            else if (message.Type == ActivityTypes.Typing)
            {
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}