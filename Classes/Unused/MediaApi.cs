using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Web;
using Umbraco.Web.WebApi;
using Newtonsoft.Json;
using System.Web.Mvc;
using DTOs.PostDTO;
using Umbraco;
using Umbraco.Web.Mvc;
using Umbraco.Core.Models.PublishedContent;

namespace DTOs.PostDTO
{
  public class PostDTO
  {
    public string Url { get; set; }
  }

  public class MyDTO
  {
    public string Id { get; set; }
  }
}


namespace Controllers.WebAPI.Qwerty
{

  public class MediaApiModel
  {
    public int MediaId { get; set; }
    public string MediaUrl { get; set; }
  }

  // https://localhost:44348/umbraco/api/MediaApi/getmediabyid?id=1139
  public class MediaApiController : UmbracoApiController
  {
    [HttpGet]
    public MediaApiModel GetMediaById(string id)
    {
      var media = Umbraco.Media(id);
      return new MediaApiModel
      {
        MediaId = media.Id,
        MediaUrl = media.Url
      };
    }

  }
}