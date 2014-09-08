namespace NServiceBus.Unicast.Transport
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class OnStartedMessageProcessingException : Exception
    {
        protected OnStartedMessageProcessingException(SerializationInfo info, StreamingContext context) { }
        public OnStartedMessageProcessingException(Exception innerException)
            : base("Exception thrown while invoking event handlers for OnStartedMessageProcessing", innerException)
        {

        }
    }
}