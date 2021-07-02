using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using Util.TratamentoErros;

namespace Util
{
    public class EmailNotificationService
    {
        public EmailNotificationService()
        {}

        #region Metodos
        public static void EnviarEmail(string toEmailAddress, string ccEmailAddress, string bccEmailAddress, 
                                             string fromEmailAddress, string fromDisplayName, string senha, string subject,
                                             string body, string attachment, string portServer, string host, bool enableSsl) 
        {
            MailMessage email = new MailMessage();
            SmtpClient client = new SmtpClient();
            try
            {
                email.To.Add(new MailAddress(toEmailAddress));
                if (!string.IsNullOrEmpty(ccEmailAddress))
                {
                    email.CC.Add(ccEmailAddress);
                }
                if (!string.IsNullOrEmpty(bccEmailAddress))
                {
                    email.Bcc.Add(bccEmailAddress);
                }
                email.From = new MailAddress(fromEmailAddress, fromDisplayName);
                email.Subject = subject;
                email.IsBodyHtml = true;
                email.Priority = MailPriority.High;
                email.Body = body;
                if (!string.IsNullOrEmpty(attachment))
                {
                    email.Attachments.Add(new Attachment(attachment));
                }
                    
                if(!string.IsNullOrEmpty(portServer))
                {
                    int outInt = 0;
                    int.TryParse(portServer, out outInt);
                    if(outInt > 0)
                    {
                        client.Port = outInt;
                    }   
                }
                client.Host = host;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.EnableSsl = false;//enableSsl;
                client.Credentials = new NetworkCredential(email.From.Address, senha);

                //client.SendCompleted += new SendCompletedEventHandler(ClientSendCompleted);
                //string tmp = subject;
                client.Send(email);
            }
            catch (Exception exception)
            {
                string mensagemErro = TratamentoExcecoes.CriarArquivoLog(exception);
                throw new Exception(mensagemErro);
            }
            finally
            {
                email.Dispose();
            }
        }

        private static void ClientSendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;
            if (e.Cancelled)
            {
                throw new Exception(string.Format("[{0}] Mensagem cancelada.", token));
            }
            if (e.Error != null)
            {
                throw new Exception(string.Format("[{0}] {1}", token, e.Error.ToString()));
            }
        }
        #endregion
    }
}