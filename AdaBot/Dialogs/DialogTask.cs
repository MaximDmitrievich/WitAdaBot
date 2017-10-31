using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdaBot.Task;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace AdaBot.Dialogs
{
    [Serializable]
    public class DialogTask : IDialog
    {
        private AdaTasks tasks;

        public DialogTask()
        {
            tasks = new AdaTasks();
        }

        public async System.Threading.Tasks.Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageRecieveAsync);
        }

        public async System.Threading.Tasks.Task MessageRecieveAsync(IDialogContext context, IAwaitable<IActivity> result)
        {
            if (tasks.Tasking == false)
            {
                context.Done(result);

            }
            IActivity message = await result;
            string reply = "";
            if (tasks.Unreaded)
            {
                reply = "Я знаю несколько интересных задач и предлагаю вам решить парочку из них";
                await context.PostAsync(reply);
                reply = tasks.Tasks[tasks.Number].Condition;
                await context.PostAsync(reply);
                tasks.Unreaded = false;
                context.Wait(MessageRecieveAsync);
            }
            else if (Helpers.NumParser(message.AsMessageActivity().Text) == tasks.Tasks[tasks.Number].Answer)
            {
                reply = "Это верный ответ!";
                await context.PostAsync(reply);
                tasks.Tasking = false;
            }
            else
            {
                reply = "Неверно. Но я могу подсказать. \n\n\u200C" + tasks.Tasks[tasks.Number].Explanation + "\n\n\u200CВ следующий раз будь внимательнее";
                await context.PostAsync(reply);
                tasks.Tasking = false;
            }
        }
    }
}