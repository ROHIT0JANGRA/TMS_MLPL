//  
// Type: DataAnnotationHelper
//  
//  
//  

using System;
using System.Linq.Expressions;
using System.Web.Mvc;

public static class DataAnnotationHelper
{
  public static MvcHtmlString YesNo(this HtmlHelper htmlHelper, bool yesNo)
  {
    return new MvcHtmlString(yesNo ? "Yes" : "No");
  }

  public static string GetDisplayName(string module, string field)
  {
    return DisplayName.Name(module, field);
  }

  public static string GetDisplayName<TModel, TProperty>(
    this TModel model,
    Expression<Func<TModel, TProperty>> expression)
  {
    return ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, new ViewDataDictionary<TModel>(model)).DisplayName;
  }
}
