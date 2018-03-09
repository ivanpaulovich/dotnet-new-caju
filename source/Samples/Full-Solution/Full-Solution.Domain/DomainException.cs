namespace Full_Solution.Domain
{
    public class DomainException : Full_SolutionException
    {
        public string BusinessMessage { get; private set; }

        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
    }
}
