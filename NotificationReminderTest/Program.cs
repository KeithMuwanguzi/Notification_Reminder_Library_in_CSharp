using System;
using NotificationReminderLibrary;
using System.Threading;

namespace NotificationReminderTest
{
    internal abstract class Program
    {
        private const string SmtpHost = "smtp.gmail.com";
        private const int SmtpPort = 587;
        private const string SenderEmail = "your-email@gmail.com";
        private const string SenderPassword = "replace with your password {app password from google settings}";

        private static void Main(string[] args)
        {
            
            var api = new LibraryApi(
                smtpServer: SmtpHost, 
                smtpPort: SmtpPort,                              
                smtpUsername: SenderEmail,      
                smtpPassword: SenderPassword,              
                senderEmail: SenderEmail   
            );
            
            var reminderId = api.ScheduleMedication("Paracetamol", "100mg", DateTime.Now.AddSeconds(5), "Shanita","shanitadith@gmail.com");
            
            Thread.Sleep(5000);
            
            api.TriggerReminder(reminderId);
            
            api.ShowLogs();
            
        }
    }
}