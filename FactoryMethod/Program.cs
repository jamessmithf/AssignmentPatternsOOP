namespace FactoryMethod
{
    // Client
    class FactoryMethod
    {
        static void Main(string[] args)
        {
            // Factory for Email
            SenderFactory emailFactory = new EmailSenderFactory();
            ISender emailSender = emailFactory.CreateSender();
            emailSender.Send("Hello via Email!");

            // Factory for SMS
            SenderFactory smsFactory = new SmsSenderFactory();
            ISender smsSender = smsFactory.CreateSender();
            smsSender.Send("Hello via SMS!");

            // Wait for user
            Console.ReadLine();
        }
    }

    // Product interface
    interface ISender
    {
        void Send(string message);
    }

    // Concrete Product 1
    class EmailSender : ISender
    {
        public void Send(string message)
        {
            Console.WriteLine($"EmailSender: Sending email with message: {message}");
        }
    }

    // Concrete Product 2
    class SmsSender : ISender
    {
        public void Send(string message)
        {
            Console.WriteLine($"SmsSender: Sending SMS with message: {message}");
        }
    }

    // Creator (abstract class)
    abstract class SenderFactory
    {
        public abstract ISender CreateSender();
    }

    // Concrete Creator 1
    class EmailSenderFactory : SenderFactory
    {
        public override ISender CreateSender()
        {
            return new EmailSender();
        }
    }

    // Concrete Creator 2
    class SmsSenderFactory : SenderFactory
    {
        public override ISender CreateSender()
        {
            return new SmsSender();
        }
    }
}
