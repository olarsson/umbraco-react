using System;
using System.Linq;
using Umbraco.Web;
using Umbraco.Web.WebApi;
using System.Web.Mvc;
using System.Collections.Generic;
using Umbraco.Web.Composing;
using Umbraco.Core.Models.PublishedContent;
using System.Dynamic;

namespace GetRoutesApi
{
  // https://localhost:44348/umbraco/api/routesapi/getroutes
  public class RoutesApiController : UmbracoApiController
  {
    public object CreateRoute(
      IPublishedContent node = null,
      string component = null,
      string path = null,
      string pageTitle = null,
      bool exactPath = false,
      string className = null,
      bool show = true
    )
    {
      dynamic routeObj = new ExpandoObject();
      routeObj.component = component ?? node.ContentType.Alias;
      routeObj.path = path ?? node.Url();
      routeObj.pageTitle = pageTitle ?? node.Value("PageTitle").ToString();
      routeObj.pageTransition = "fade";
      routeObj.exactPath = exactPath;
      routeObj.navigation = new
      {
        className = className,
        show = show
      };
      return routeObj;
    }

    [HttpGet]
    public Object GetRoutes()
    {
      var helper = Current.UmbracoHelper;

      var rootNode = helper.ContentAtRoot().First();

      dynamic allRoutes = new List<dynamic>();

      dynamic routeObj = CreateRoute(rootNode, null, null, null, true);
      /*routeObj.onlyForStart = "test";*/

      allRoutes.Add(routeObj);

      var nodes = rootNode.Children;

      foreach (var node in nodes)
      {
        switch (node.ContentType.Alias)
        {
          case "contact":
            routeObj = CreateRoute(node, null, null, null, false);
            /*routeObj.onlyForContact = "test";*/
            break;
          case "faq":
            routeObj = CreateRoute(node, null, null, null, true);
            /*routeObj.onlyForFaq = "test";*/
            break;
          case "somePage":
            routeObj = CreateRoute(node, null, null, null, true);
            /*routeObj.onlyForSomePage = "test";*/
            break;
        }
        allRoutes.Add(routeObj);
      }

      routeObj = CreateRoute(null, "NotFound", "*", "Page can't be found!", false, null, false);
      allRoutes.Add(routeObj);

      return new
      {
        routes = allRoutes
      };

    }

  }
}