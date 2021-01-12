using System;
using Umbraco.Web;
using Umbraco.Web.WebApi;
using System.Web.Mvc;

namespace GetContentAtPathApi
{

  // https://localhost:44348/umbraco/api/contentbypathapi/getcontent?path=/contact1
  public class ContentByPathApiController : UmbracoApiController
  {
    [HttpGet]
    public Object GetContent(string path)
    {
      var content = UmbracoContext.Content.GetByRoute(path);

      if (content == null)
      {
        return new
        {
          code = 404,
          text = "The page could not be found."
        };
      }

      switch (content.ContentType.Alias)
      {
        case "home":
          return new
          {
            code = 200,
            text = "Ok",
            header = new
            {
              homeAttr = "only exists for home page",
              pageTitle = content.Value<String>("PageTitle")
            }
          };

        case "contact":
          return new
          {
            code = 200,
            text = "Ok",
            header = new
            {
              contactAttr = "only exists for contact page",
              pageTitle = content.Value<String>("PageTitle")
            }
          };

        case "faq":
          return new
          {
            code = 200,
            text = "Ok",
            header = new
            {
              faqAttr = "only exists for faq page",
              pageTitle = content.Value<String>("PageTitle")
            }
          };

        case "somePage":
          return new
          {
            code = 200,
            text = "Ok",
            header = new
            {
              somePageAttr = "only exists for somePage page",
              pageTitle = content.Value<String>("PageTitle")
            }
          };

        default:
          return new
          {
            code = 200,
            text = "This path lacks routing."
          };

      }


      /*      return new
            {
              code = 200,
              text = "Ok",
              header = new
              {
                pageTitle = content.Value<String>("PageTitle")
              }
              *//*        results = new List<Result>()
                      {
                          new Result { id = 1, value = "ABC", info = "ABC" },
                          new Result { id = 2, value = "JKL", info = "JKL" }
                      }*//*
            };*/

    }

  }
}