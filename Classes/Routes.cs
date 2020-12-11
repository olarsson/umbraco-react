using System;
using System.Linq;
using Umbraco.Web;
using Umbraco.Web.WebApi;
using System.Web.Mvc;
using System.Web.Http.Controllers;
using System.Net.Http.Formatting;
using System.Diagnostics;

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
    [HttpGet]
    public Object GetRoutes()
    {
      var content = UmbracoContext.Content.GetAtRoot().FirstOrDefault();

      Debug.WriteLine(content);

      //var jsonResultObj = new JsonResultModel();
      //jsonResultObj.PageTitle = content.Value<String>("PageTitle");

      return content;

    }

  }
}