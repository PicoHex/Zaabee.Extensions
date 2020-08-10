using System;

namespace Zaabee.Extensions
{
    public static class ExceptionExtension
    {
        public static Exception GetInmostException(this Exception ex)
        {
            if (ex.InnerException is null) return ex;
            var inmostException = ex.InnerException;
            while (inmostException.InnerException != null)
                inmostException = inmostException.InnerException;
            return inmostException;
        }
    }
}