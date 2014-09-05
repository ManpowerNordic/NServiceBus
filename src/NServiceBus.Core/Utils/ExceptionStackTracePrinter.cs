namespace NServiceBus.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ExceptionStackTracePrinter
    {
        public static string CreateFullStackTrace(this Exception exception)
        {
            var stackTraces =
                GetNestedExceptionsList(exception)
                .Reverse()
                .Select(currentException => string.Format("Exception:{1}{0}Message:{2}{0}{0}{3}",
                                                          Environment.NewLine,
                                                          currentException.GetType().FullName,
                                                          currentException.Message, currentException.StackTrace))
                .ToList();

            return string.Join(string.Format("{0}   ---End of inner stack trace---{0}{0}", Environment.NewLine),
                               stackTraces);
        }

        private static IEnumerable<Exception> GetNestedExceptionsList(Exception exception)
        {
            yield return exception;
            while (exception.InnerException != null)
            {
                yield return exception.InnerException;
                exception = exception.InnerException;
            }
        }
 
    }
}