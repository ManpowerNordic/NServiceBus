namespace NServiceBus.Unicast.Transport
{
    using System;

    public class OnFinishedMessageProcessingException : Exception
    {
        public OnFinishedMessageProcessingException(Exception innerException)
            : base("Exception thrown while invoking event handlers for OnFinishedMessageProcessing", innerException)
        {

        }
    }
}