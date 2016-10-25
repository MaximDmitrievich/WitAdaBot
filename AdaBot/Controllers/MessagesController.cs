using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using com.valgut.libs.bots.Wit;
using System.Text;
using System.Xml.Linq;

namespace AdaBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                var wit = new WitClient("G6AM4AHSKKP4EQYJ35ZWJ723H5DDHTAX");
                var msg = wit.Converse(activity.From.Id, activity.Text);
                var intent = string.Empty; double conf = 0;
                if (msg.entities["intent"]!=null)
                {
                    foreach(var z in msg.entities["intent"])
                    {
                        if (z.confidence>conf)
                        {
                            conf = z.confidence;
                            intent = z.value.ToString();
                        }
                    }
                }
                var doc = XDocument.Load(System.Web.HttpContext.Current.Request.MapPath("~/Responses.xml"));
                var r = (from x in doc.Descendants("Response")
                         where x.Attribute("intent").Value == intent
                         select x).FirstOrDefault();
                string res = "Я вас не понимаю...";
                if (r!=null)
                {
                    var arr = (from x in r.Descendants("Text")
                               select x.Value).ToArray();
                    if (arr!=null && arr.Length>0)
                    {
                        var rnd = new Random();
                        res = arr[rnd.Next(0, arr.Length)];
                    }
                } 
                Activity reply = activity.CreateReply(res);
                await connector.Conversations.ReplyToActivityAsync(reply);
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
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}