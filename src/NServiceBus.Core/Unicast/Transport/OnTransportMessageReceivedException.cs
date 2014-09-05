namespace NServiceBus.Unicast.Transport
{
    using System;

    public class OnTransportMessageReceivedException : Exception
    {
        public OnTransportMessageReceivedException(Exception innerException)
            : base("Exception thrown while invoking event handlers for OnTransportMessageReceived", innerException)
        {

        }
    }
}