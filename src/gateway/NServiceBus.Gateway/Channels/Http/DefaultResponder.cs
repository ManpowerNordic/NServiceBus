namespace NServiceBus.Gateway.Channels.Http
{
    using System.Net;
    using NServiceBus.Config;

    public class DefaultResponder : IHttpResponder
    {
        public void Handle(HttpListenerContext ctx)
        {
            ctx.Response.StatusCode = 200;
            
            var response = string.Format("<html><body>EndpointName:{0} - Status: Ok</body></html>", Configure.EndpointName);

            ctx.Response.ContentType = "text/html";
            ctx.Response.Close(System.Text.Encoding.UTF8.GetBytes(response),true);
        }
    }

    public class SetDefaultResponder : IWantToRunBeforeConfigurationIsFinalized
    {
        public void Run()
        {
            if (!Configure.Instance.Configurer.HasComponent<IHttpResponder>())
                Configure.Instance.Configurer.ConfigureComponent<DefaultResponder>(DependencyLifecycle.InstancePerCall);
        }
    }
}