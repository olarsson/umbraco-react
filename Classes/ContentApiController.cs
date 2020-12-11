using Umbraco.Web.WebApi;
using System.Web.Mvc;

namespace Controllers.WebAPI.Qwerty
{

  public class ContentApiModel
  {
    public int ContentId { get; set; }
    public string ContentUrl { get; set; }
  }

  // https://localhost:44348/umbraco/api/ContentApi/getcontentbyid?id=1114
  public class ContentApiController : UmbracoApiController
  {
    [HttpGet]
    public ContentApiModel GetContentById(string id)
    {
      var content = Umbraco.Content(id);

      return new ContentApiModel
      {
        ContentId = content.Id,
        ContentUrl = content.Url
      };
    }

  }
}