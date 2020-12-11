using System;
using System.Linq;
using Umbraco.Web;
using Umbraco.Web.WebApi;
using System.Web.Mvc;
using System.Web.Http.Controllers;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using System.Diagnostics;

namespace GetContentAtPathApi
{

  /*  public class Header
    {
      public string pageTitle { get; set; }
    }

    public class JsonResultModel
    {

      public Header header;

    }*/


  // https://localhost:44348/umbraco/api/ContentAtPathApi/GetContentAtPath?path=/contact
  //[JsonOnlyConfiguration]
  public class ContentAtPathApiController : UmbracoApiController
  {
    [HttpGet]
    public Object GetContentAtPath(string path)
    {
      var content = UmbracoContext.Content.GetByRoute(path);

      // Debug.WriteLine(content);

      /*      var jsonResultObj = new JsonResultModel();
            jsonResultObj.header.pageTitle = content.Value<String>("PageTitle");
      */
      return new
      {
        header = new
        {
          pageTitle = content.Value<String>("PageTitle")
        }
        /*        results = new List<Result>()
                {
                    new Result { id = 1, value = "ABC", info = "ABC" },
                    new Result { id = 2, value = "JKL", info = "JKL" }
                }*/
      };

    }

  }
}