namespace NServiceBus.Unicast.Transport
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class OnFinishedMessageProcessingException : Exception
    {
        protected OnFinishedMessageProcessingException(SerializationInfo info, StreamingContext context) { }
        public OnFinishedMessageProcessingException(Exception innerException)
            : base("Exception thrown while invoking event handlers for OnFinishedMessageProcessing", innerException)
        {

        }
    }
}