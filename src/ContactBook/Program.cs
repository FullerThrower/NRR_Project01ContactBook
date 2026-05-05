namespace ContactBook
{
    class Program
    {
        static void Main()
        {
            var cb = new ContactBook(ContactSeed.Contacts);
            cb.Start();
        }
    }
}