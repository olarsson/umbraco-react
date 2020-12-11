/*using WebApplication2.Classes.Utilities;*/
/*using WebApplication2.Controllers.SurfaceControllers;*//*
using WebApplication2.Models;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using Examine;
using WebApplication2.Controllers;
using Newtonsoft.Json;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web.Mvc;
using Umbraco.Web.Composing;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.PublishedModels;
using Umbraco.Core.Logging;

namespace WebApplication2.Controllers
{
  public class ReactRoutesController : ReactRenderMvcController
  {
    public override ActionResult Index(ContentModel model)
    {
      return View("Master", CreateMasterModel());
    }


    private MasterModel CreateMasterModel()
    {
      // Get reference to the Umbraco helper   
      var helper = Current.UmbracoHelper;

      // Create return model
      var model = new MasterModel(helper.AssignedContentItem);

      // Get node id
      model.NodeId = helper.AssignedContentItem.Id;

      // Get content based on node id
      var content = Current.UmbracoContext.Content.GetById(model.NodeId);

      // Initializations
      bool siteImage = false;
      IPublishedContent headerImage = null;

      return model;
    }



    *//*** HELPER METHODS ***//*

  }
}
*/

/*using System.Diagnostics;
using System.Web.Mvc;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace Umbraco8.Composers
{
  public class CatchAllController : Umbraco.Web.Mvc.RenderMvcController
  {
    public override ActionResult Index(ContentModel model)
    {
      // you are in control here!

      // return a 'model' to the selected template/view for this page.
      Debug.WriteLine(model);
      return CurrentTemplate(model);
    }
  }

  public class SetDefaultRenderMvcControllerComposer : IUserComposer
  {
    public void Compose(Composition composition)
    {
      composition.SetDefaultRenderMvcController<CatchAllController>();
    }
  }
}*/

/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Classes.Utilities;
using WebApplication2.Controllers.SurfaceControllers;
using WebApplication2.Models;
using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Models;


namespace WebApplication2.Controllers
{
  public class ReactRoutesController : ReactRenderMvcController
  {
    public override ActionResult Index(RenderModel model)
    {
      return View("Master", CreateMasterModel());
    }


    /// <summary>
    /// Creates a master model for the current page.
    /// </summary>
    /// <returns>A <see cref="MasterModel"/> object.</returns>
    private MasterModel CreateMasterModel()
    {

      // Get an Umbraco helper
      var helper = new UmbracoHelper(UmbracoContext.Current);

      var root = CurrentPage.Site();
      var model = new MasterModel(CurrentPage);

      // Set node id
      model.NodeId = CurrentPage.Id;


      *//*** META TAGS (SITE, PAGE AND OG TAGS) ***//*

      // Get meta tags due to document type
      model = CommonSurfaceController.GetMetaTags(model, helper);


      *//*** GDPR ***//*

      // Get GDPR content and add to return model
      model.Gdpr = CommonSurfaceController.GetGdpr(helper);


      *//*** GOOGLE ANALYTICS KEY ***//*

      // Get content from Settings node
      var contentSettings = helper.TypedContentAtXPath("//" + MyConstants.ResourcesDocTypeAlias +
          "/" + MyConstants.AdministrationDocTypeAlias + "/" + MyConstants.SettingsDocTypeAlias)
          .FirstOrDefault();

      model.GoogleAnalyticsKey = contentSettings.GetPropertyValue<string>(MyConstants.GoogleAnalyticsKeyPropertyAlias);


      return model;
    }



    *//*** HELPER METHODS ***//*

  }
}*/
