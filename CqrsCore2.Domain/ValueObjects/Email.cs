namespace CqrsCore2.Domain.ValueObjects
{
    public class Email
    {
        public Email(string emailAdress)
        {
            EmailAdress = emailAdress;
        }
        public string EmailAdress { get; private set; }
    }
}
