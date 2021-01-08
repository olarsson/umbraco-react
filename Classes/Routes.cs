using System;
using System.Linq;
using Umbraco.Web;
using Umbraco.Web.WebApi;
using System.Web.Mvc;
using System.Web.Http.Controllers;
using System.Net.Http.Formatting;
using System.Diagnostics;
using System.Collections.Generic;
using Umbraco.Web.Composing;
using Umbraco.Core.Models.PublishedContent;

namespace GetRoutesApi
{

  public class JsonResultModel
  {
    public string PageTitle { get; set; }
  }


  // https://localhost:44348/umbraco/api/routesapi/getroutes
  //[JsonOnlyConfiguration]
  public class RoutesApiController : UmbracoApiController
  {

    //public routes = new List<Route>(); 

    static void RetNode(IPublishedContent node, List<Route> routes)
    {
      routes.Add(new Route()
      {
        component = node.ContentType.Alias,
        path = node.Url(),
        pageTitle = node.Value<String>("PageTitle")
      });
    }

    class Route
    {
      public string path;
      public string component;
      public string pageTitle;
    }

    [HttpGet]
    public Object GetRoutes()
    {
      var routes = new List<Route>();

      var helper = Current.UmbracoHelper;

      // Get the root node content
      var rootNode = helper.ContentAtRoot().First();

      /*Debug.WriteLine(rootNode.Url());
      Debug.WriteLine(rootNode.ContentType.Alias);*/

      RetNode(rootNode, routes);

      var nodes = rootNode.Children;

      foreach (var node in nodes)
      {
        Debug.WriteLine(node.Name); // individual
        Debug.WriteLine(node.ContentType.Alias); // shared (component)

        switch (node.ContentType.Alias)
        {
          case "contact":
            RetNode(node, routes);
            break;
          case "faq":
            RetNode(node, routes);
            break;
          case "somePage":
            RetNode(node, routes);
            break;
        }
      }

      // 404 page
      routes.Add(new Route()
      {
        component = "NotFound",
        path = "*",
        pageTitle = "Page couldn't be found"
      });

      return routes;

    }

  }
}