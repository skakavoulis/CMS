using System;

namespace CMS.WCF.Services.Exceptions
{
    public class NotAuthorizedException : Exception
    {
        public NotAuthorizedException(string message)
            : base(message)
        {
        }
    }
}
