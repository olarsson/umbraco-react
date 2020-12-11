/*using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Models;
using System.Diagnostics;
using Umbraco.Core.Composing;
using Umbraco.Web.Mvc;
using System.Web.Extensions;

*//*

namespace WebApplication2.Models
{

  public class HomeController : Umbraco.Web.Mvc.RenderMvcController
  {
    public override ActionResult Index(ContentModel model)
    {
      // you are in control here!

      Debug.WriteLine(model.Content.GetTemplateAlias());

      // return a 'model' to the selected template/view for this page.
      // return CurrentTemplate(model);
      return View("home", ContentModel);
    }
  }
}
*//*

namespace WebApplication2.Controllers
{

  public class ReactRenderMvcController : RenderMvcController
  {

    public ViewResult ViewFromContentId(int id, IPublishedContentQuery publishedContentQuery)
    {
      // Get instance of he Umbraco Helper
      //var helper = Current.UmbracoHelper;

      // Get content by node id
      var result = publishedContentQuery.Content(id);

      var renderModel = ViewExtensions.CreateRenderModel(result, RouteData);

      return View("~/Views/Master.cshtml", renderModel);
    }


    // REKOMMENDERAT F�R UMBRACO 8 - MEN OK�NT HUR Execute OCH Index SKA IMPLEMENTERAS  
    //public class ReactRenderMvcController : IRenderMvcController
    //{
    //    public void Execute(RequestContext requestContext)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public ActionResult Index(ContentModel model)
    //    {
    //        throw new NotImplementedException();
    //    }
  }
}
*/