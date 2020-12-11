/*using System;
using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Core.Composing;

namespace Umbraco8.Components
{
  /// <summary>
  /// Register Custom Route Composer
  /// Register any custom routes here - see https://our.umbraco.com/Documentation/Reference/Routing/custom-routes and https://our.umbraco.com/forum/umbraco-8/96167-registering-custom-routes-in-umbraco-8
  /// </summary>
  public class RegisterCustomRouteComposer : ComponentComposer<RegisterCustomRouteComponent>
  {
  }

  /// <summary>
  /// Register Custom Route Component
  /// </summary>
  public class RegisterCustomRouteComponent : IComponent
  {
    public void Initialize()
    {
      // Register Custom Forms Controller
      RouteTable.Routes.MapRoute("Forms", "forms", new { controller = "Forms", action = "Index" });

      // Register Custom ML Controller
      RouteTable.Routes.MapRoute("AzureML", "azureml-garden-design", new { controller = "AzureML", action = "Index" });
    }

    /// <summary>
    /// Terminate
    /// </summary>
    public void Terminate()
    {
      throw new NotImplementedException();
    }
  }
}*/

/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Core.Composing;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace WebApplication2
{

  public class RegisterCustomRouteComposer : ComponentComposer<RegisterCustomRouteComponent>
  {

  }

  public class RegisterCustomRouteComponent : IComponent
  {
    public void Initialize()
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
      routes.IgnoreRoute("Content/{*pathInfo}");
      routes.MapMvcAttributeRoutes();
      routes.MapRoute(
          name: "catch",
          url: "{*url}",
          defaults: new { controller = "Home", action = "Index" }
      );

    }

    public void Terminate()
    {
      throw new NotImplementedException();
    }
  }
}
*/

/*using System.Web.Mvc;
using System.Web.Routing;

public class RouteConfig
{

  public static void RegisterRoutes(RouteCollection routes)
  {
    routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    routes.IgnoreRoute("Content/{*pathInfo}");
    routes.MapMvcAttributeRoutes();
    routes.MapRoute(
        name: "catch",
        url: "{*url}",
        defaults: new { controller = "Home", action = "Index" }
    );
  }
}*/

/*using System.Collections.Generic;
using System.Web.Http;
using Umbraco.Web.WebApi;

namespace Umbraco8.Controllers
{
  public class MyApiController : UmbracoApiController
  {
    //[HttpGet]
    // umbraco/api/myapi/isup
    [HttpGet]
    public bool IsUp()
    {
      return true;
    }

    /*
    [HttpGet]
    [Route("umbraco/api/members")]
    public IEnumerable<string> GetAllMembers()
    {
      return new[] { "Table", "Chair", "Desk", "Computer", "Beer fridge" };
    }
    
  }
}
*/

/*using System.Web.Mvc;
using System.Web.Routing;

public class RouteConfig
{

  public static void RegisterRoutes(RouteCollection routes)
  {
    routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    routes.IgnoreRoute("Content/{*pathInfo}");
    routes.MapMvcAttributeRoutes();
    routes.MapRoute(
        name: "catch",
        url: "{*url}",
        defaults: new { controller = "Home", action = "Index" }
    );
  }
}*/
