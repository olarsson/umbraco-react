using System.Collections.Generic;
using Umbraco.Web;
using Umbraco.Web.WebApi;
using Newtonsoft.Json;
using System.Web.Mvc;
using System.Diagnostics;
using Newtonsoft.Json.Serialization;
using System.Reflection;

public class IgnorePropertiesResolverFull : DefaultContractResolver
{
  private readonly HashSet<string> ignoreProps;
  public IgnorePropertiesResolverFull(IEnumerable<string> propNamesToIgnore)
  {
    this.ignoreProps = new HashSet<string>(propNamesToIgnore);
  }

  protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
  {
    JsonProperty property = base.CreateProperty(member, memberSerialization);
    if (this.ignoreProps.Contains(property.PropertyName))
    {
      property.ShouldSerialize = _ => false;
    }
    return property;
  }

}

namespace apiNameFull
{
  // https://localhost:44348/umbraco/api/FullContentAtPathApi/GetFullContentAtPath?path=/contact
  public class FullContentAtPathApiController : UmbracoApiController
  {
    [HttpGet]
    public string GetFullContentAtPath(string path)
    {
      var content = UmbracoContext.Content.GetByRoute(path);

      var JSON = JsonConvert.SerializeObject(content, new JsonSerializerSettings()
      {
        ContractResolver = new IgnorePropertiesResolverFull(new[] { "ContentType", "Parent" })
      });

      var unEscapedJSON = JSON.Replace(@"\\""", "\\").Replace(@"\\""", "\\");

      Debug.WriteLine(unEscapedJSON);

      return unEscapedJSON;
    }

  }
}