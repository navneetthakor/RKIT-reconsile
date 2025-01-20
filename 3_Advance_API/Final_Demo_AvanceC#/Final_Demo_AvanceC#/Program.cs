using System;
using System.Net;
using System.Net.Mail;

class Program
{
    static void Main(string[] args)
    {
        // Sender email and password (Gmail in this case)
        string senderEmail = "tnavneet8628@gmail.com";
        string senderPassword = "";  // or use App password if 2FA is enabled

        // Receiver email
        string receiverEmail = "shahshaurya11@gmail.com";

        // Create a new MailMessage object
        MailMessage mail = new MailMessage();

        // Set up the sender and recipient
        mail.From = new MailAddress(senderEmail);
        mail.To.Add(receiverEmail);

        // Set the subject and body of the email
        mail.Subject = "OTP for Book Loans";
        mail.IsBodyHtml = true;
        mail.Body = @"
            <html>
                <body>
                    <p>Hello,</p>
                    <p>Your <b>OTP</b> for password reset on <b> Book Loans </b> application is : </p>
                    <p style='color: green;'> <span style='font-weight: bold;'><h1> 512634 </h1></span></p>
                    <p> Your sincerly,</p>
                    <p> Navneetkumar Thakor </p>
                </body>
            </html>";
        //mail.Body = "Your OTP for password reset on Book Loans application is : \b <h1> 512634 </h1> \b your sincerly, \b Navneetkumar Thakor ";

        // Create SMTP client and configure it to use Gmail's SMTP server
        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587, // TLS port
            Credentials = new NetworkCredential(senderEmail, senderPassword),
            EnableSsl = true // Use SSL to encrypt the connection
        };

        try
        {
            // Send the email
            smtpClient.Send(mail);
            Console.WriteLine("Email sent successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error sending email: " + ex.Message);
        }
    }
}
