using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Framework.Builder.Witai;
using Microsoft.Bot.Framework.Builder.Witai.Dialogs;
using Microsoft.Bot.Framework.Builder.Witai.Models;

namespace AdaBot.Dialogs
{
    [Serializable]
    [WitModel("")]
    public class DialogWit : WitDialog<object>
    {
        
        [WitIntent("")]
        public async System.Threading.Tasks.Task DoNotUnderstand(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result));
        }

        [WitIntent("greeting")]
        public async System.Threading.Tasks.Task Greeting(IDialogContext context, WitResult result)
        {
            
            await context.PostAsync(IntentXAMLRead.Reading(result));
        }

        [WitIntent("can_program")]
        public async System.Threading.Tasks.Task CanProgram(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result));
        }

        [WitIntent("math")]
        public async System.Threading.Tasks.Task Math(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result));
        }

        [WitIntent("what")]
        public async System.Threading.Tasks.Task What(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result));
        }

        [WitIntent("get_age")]
        public async System.Threading.Tasks.Task GetAge(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result));
        }

        [WitIntent("getplace")]
        public async System.Threading.Tasks.Task GetPlace(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result));
        }

        [WitIntent("getperson")]
        public async System.Threading.Tasks.Task GetPerson(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result));
        }

        [WitIntent("getdate")]
        public async System.Threading.Tasks.Task GetDate(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result));
        }

        [WitIntent("when")]
        public async System.Threading.Tasks.Task When(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result));
        }

        [WitIntent("getname")]
        public async System.Threading.Tasks.Task GetName(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result));
        }
        [WitIntent("gethowprog")]
        public async System.Threading.Tasks.Task GetHowProg(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result));
        }
        [WitIntent("you_father")]
        public async System.Threading.Tasks.Task YourFather(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result));
        }
        [WitIntent("you_and_father")]
        public async System.Threading.Tasks.Task YouAndFather(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result));
        }
        [WitIntent("you_family")]
        public async System.Threading.Tasks.Task YouFamily(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result));
        }
        [WitIntent("who_i_am")]
        public async System.Threading.Tasks.Task WhoIAm(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result));
        }
        [WitIntent("mind")]
        public async System.Threading.Tasks.Task Mind(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result));
        }
        [WitIntent("can")]
        public async System.Threading.Tasks.Task Can(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result));
        }
        [WitIntent("parting")]
        public async System.Threading.Tasks.Task Parting(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result));
        }
        [WitIntent("who_created_you")]
        public async System.Threading.Tasks.Task WhoCreatedYou(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result));
        }
        [WitIntent("how_are_you")]
        public async System.Threading.Tasks.Task HowAreYou(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result));
        }
        [WitIntent("ok_good")]
        public async System.Threading.Tasks.Task OkGood(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result));
        }
        [WitIntent("ok")]
        public async System.Threading.Tasks.Task Ok(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result));
        }
        [WitIntent("yes")]
        public async System.Threading.Tasks.Task Yes(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result));
        }
        [WitIntent("why")]
        public async System.Threading.Tasks.Task Why(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result));
        }
        [WitIntent("no")]
        public async System.Threading.Tasks.Task No(IDialogContext context, WitResult result)
        {
            await context.PostAsync(IntentXAMLRead.Reading(result));
        }

    }
}
