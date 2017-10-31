using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Framework.Builder.Witai;
using Microsoft.Bot.Framework.Builder.Witai.Dialogs;
using Microsoft.Bot.Framework.Builder.Witai.Models;

namespace AdaBot.Dialogs
{
    [Serializable]
    [WitModel("JN5CDHK5BWJYRJMII7P3K4ZLKVYKD4CK")]
    public class DialogWit : WitDialog<object>
    {
        [WitIntent("")]
        public async System.Threading.Tasks.Task DoNotUnderstand(IDialogContext context, WitResult result)
        {
            XDocument doc = XDocument.Load(System.Web.HttpContext.Current.Request.MapPath("~/Responses.xml"));
            XElement r = (from x in doc.Descendants("Response")
                          where x.Attribute("intent")?.Value == ""
                          select x).FirstOrDefault();
            string res = "Я вас не понимаю...";
            if (r != null)
            {
                var arr = (from x in r.Descendants("Text")
                           select x.Value).ToArray();
                if (arr.Length > 0)
                {
                    Random rnd = new Random();
                    res = arr[rnd.Next(0, arr.Length)];
                }
            }
            await context.PostAsync(res);
            if ((new Random()).Next(0, 2) == 1)
            {
                await context.Forward(new DialogTask(), this.Over, context.Activity, CancellationToken.None);

            }
        }

        [WitIntent("greeting")]
        public async System.Threading.Tasks.Task Greeting(IDialogContext context, WitResult result)
        {
            
            await context.PostAsync(IntentXAMLRead.Reading(result, "greeting"));
        }

        [WitIntent("can_program")]
        public async System.Threading.Tasks.Task CanProgram(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result, "can_program"));
            if ((new Random()).Next(0, 2) == 1)
            {
                await context.Forward(new DialogTask(), this.Over, context.Activity, CancellationToken.None);

            }
        }

        [WitIntent("math")]
        public async System.Threading.Tasks.Task Math(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result, "math"));
            if ((new Random()).Next(0, 2) == 1)
            {
                await context.Forward(new DialogTask(), this.Over , context.Activity, CancellationToken.None);

            }
        }

        public async System.Threading.Tasks.Task Over(IDialogContext context, IAwaitable<object> result)
        {
            context.Done(result);
        }

        [WitIntent("what")]
        public async System.Threading.Tasks.Task What(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result, "what"));
        }

        [WitIntent("get_age")]
        public async System.Threading.Tasks.Task GetAge(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result, "get_age"));
        }

        [WitIntent("getplace")]
        public async System.Threading.Tasks.Task GetPlace(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result, "getplace"));
        }

        [WitIntent("getperson")]
        public async System.Threading.Tasks.Task GetPerson(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result, "getperson"));
        }

        [WitIntent("getdate")]
        public async System.Threading.Tasks.Task GetDate(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result, "getdate"));
        }

        [WitIntent("when")]
        public async System.Threading.Tasks.Task When(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result, "when"));
        }

        [WitIntent("getname")]
        public async System.Threading.Tasks.Task GetName(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result, "getname"));
        }
        [WitIntent("gethowprog")]
        public async System.Threading.Tasks.Task GetHowProg(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result, "gethowprog"));
        }
        [WitIntent("you_father")]
        public async System.Threading.Tasks.Task YourFather(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result, "you_father"));
        }
        [WitIntent("you_and_father")]
        public async System.Threading.Tasks.Task YouAndFather(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result, "you_and_father"));
        }
        [WitIntent("you_family")]
        public async System.Threading.Tasks.Task YouFamily(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result, "you_family"));
        }
        [WitIntent("who_i_am")]
        public async System.Threading.Tasks.Task WhoIAm(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result, "who_i_am"));
        }
        [WitIntent("mind")]
        public async System.Threading.Tasks.Task Mind(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result, "mind"));
        }
        [WitIntent("can")]
        public async System.Threading.Tasks.Task Can(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result, "can"));
        }
        [WitIntent("parting")]
        public async System.Threading.Tasks.Task Parting(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result, "parting"));
        }
        [WitIntent("who_created_you")]
        public async System.Threading.Tasks.Task WhoCreatedYou(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result, "who_created_you"));
        }
        [WitIntent("how_are_you")]
        public async System.Threading.Tasks.Task HowAreYou(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result, "how_are_you"));
        }
        [WitIntent("ok_good")]
        public async System.Threading.Tasks.Task OkGood(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result, "ok_good"));
        }
        [WitIntent("ok")]
        public async System.Threading.Tasks.Task Ok(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result, "ok"));
        }
        [WitIntent("yes")]
        public async System.Threading.Tasks.Task Yes(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result, "yes"));
        }
        [WitIntent("why")]
        public async System.Threading.Tasks.Task Why(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result, "why"));
        }
        [WitIntent("no")]
        public async System.Threading.Tasks.Task No(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result, "no"));
        }

    }
}
