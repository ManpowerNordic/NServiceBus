namespace NServiceBus.Unicast.Transport
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class OnTransportMessageReceivedException : Exception
    {
        protected OnTransportMessageReceivedException(SerializationInfo info, StreamingContext context) { }
        public OnTransportMessageReceivedException(Exception innerException)
            : base("Exception thrown while invoking event handlers for OnTransportMessageReceived", innerException)
        {

        }
    }
}