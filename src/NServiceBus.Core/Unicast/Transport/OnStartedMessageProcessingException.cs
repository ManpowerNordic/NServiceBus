namespace NServiceBus.Unicast.Transport
{
    using System;

    public class OnStartedMessageProcessingException : Exception
    {
        public OnStartedMessageProcessingException(Exception innerException)
            : base("Exception thrown while invoking event handlers for OnStartedMessageProcessing", innerException)
        {

        }
    }
}