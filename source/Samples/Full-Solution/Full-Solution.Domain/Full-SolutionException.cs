namespace Full_Solution.Domain
{
    using System;

    public class Full_SolutionException : Exception
    {
        internal Full_SolutionException()
        { }

        internal Full_SolutionException(string message)
            : base(message)
        { }

        internal Full_SolutionException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
