using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Diagnostics;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Core;
using Umbraco.Core.Composing;

[RuntimeLevel(MinLevel = RuntimeLevel.Run)]
internal class ApiConfigurationComposer : IComposer
{
  public void Compose(Composition composition)
  {
    composition.Components().Insert<ApiConfigurationComponent>();
  }

  public class ApiConfigurationComponent : IComponent
  {
    public void Initialize()
    {
      //Debug.WriteLine("started");
      //GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

      GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(
        new System.Net.Http.Formatting.RequestHeaderMapping(
        "Accept",
        "text/html",
        StringComparison.InvariantCultureIgnoreCase,
        true,
        "application/json")
      );
    }

    public void Terminate()
    {
    }
  }
}