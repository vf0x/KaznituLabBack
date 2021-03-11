using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using KaznituLab.Services.Interfaces;
using KaznituLab.Services.Interfaces.Email;

namespace KaznituLab.Configs
{
    public static class HangFireJobs
    {
        public static void AddJobs()
        {
            RecurringJob.AddOrUpdate(() => Console.Write("Easy!"), Cron.Daily);
            RecurringJob.AddOrUpdate<IEmailSendService>(e=> e.SendEquipmentTechnicalMaintenance(), Cron.Daily);
        }
    }
}
