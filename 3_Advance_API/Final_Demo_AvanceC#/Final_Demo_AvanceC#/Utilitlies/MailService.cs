
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;


namespace Final_Demo_AvanceCSharp.Utilitlies
{
    internal class MailService
    {
        // Sender email and password (Gmail in this case)
        public string SenderEmail { get; set; }
        public string SenderPassword { get; set; }
        
        public MailService(string email, string password)
        {
            SenderEmail = email;
            SenderPassword = password;
            Console.WriteLine("Email : " + SenderEmail);
        }

        public bool VarifyEmail(string receiverEmail)
        {
            //Generating OTP
            int OTP = new Random().Next(100000,1000000);
            
            // Create a new MailMessage object
            MailMessage mail = new MailMessage();

            // Set up the sender and recipient
            mail.From = new MailAddress(this.SenderEmail);
            mail.To.Add(receiverEmail);

            // Set the subject and body of the email
            mail.Subject = "OTP for Book Loans";
            mail.IsBodyHtml = true;
            mail.Body = $@"
            <html>
                <body>
                    <p>Hello,</p>
                    <p>Your <b>OTP</b> for password reset on <b> Book Loans </b> application is : </p>
                    <p style='color: green;'> <span style='font-weight: bold;'><h1> {OTP} </h1></span></p>
                    <p> Your sincerly,</p>
                    <p> Navneetkumar Thakor </p>
                </body>
            </html>";
            

            // Create SMTP client and configure it to use Gmail's SMTP server
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587, // TLS port
                Credentials = new NetworkCredential(SenderEmail, SenderPassword),
                EnableSsl = true // Use SSL to encrypt the connection
            };

            try
            {
                // Send the email
                smtpClient.Send(mail);
                Console.WriteLine("Email sent successfully!");
                Console.Write("Enter OTP : ");
                int OTP2 = Convert.ToInt32( Console.ReadLine());

                if (OTP2 == OTP)
                {
                    Console.WriteLine("OTP is verifed, Now you can change your password!!");
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
                return false;
            }
        }
    }
}
