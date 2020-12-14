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

    class Route
    {
      public string path;
      public string component;
    }

    [HttpGet]
    public Object GetRoutes()
    {
      //var content = UmbracoContext.Content.GetAtRoot();
      //Debug.WriteLine(content);

      var routesList = new List<Route>();

      var helper = Current.UmbracoHelper;

      // Get the root node content
      var rootNode = helper.ContentAtRoot().First();

      var nodes = rootNode.Children;

      foreach (var node in nodes)
      {
        //Debug.WriteLine(node.Name); // individual
        //Debug.WriteLine(node.ContentType.Alias); // shared (component)
        routesList.Add(new Route()
        {
          component = node.ContentType.Alias,
          path = node.Url()
        });
      }

      // 404 page
      routesList.Add(new Route()
      {
        component = "NotFound",
        path = "*"
      });

      //Debug.Write(nodes);

      return new
      {
        results = routesList
        /*        results = new List<Route>()
                {
                    new Route {
                      component = "Start",
                      path = "/test1"
                    },
                    new Route {
                      component = "Contact",
                      path = "/test2"
                    },
                }*/
      };

    }

  }
}