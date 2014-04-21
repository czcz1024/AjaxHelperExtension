namespace System.Web.Mvc.Ajax
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Routing;

    public static class AjaxHelperExtensions
    {
        public static MvcHtmlString RenderAction(
            this AjaxHelper ajaxHelper,
            string actionName,
            string controllerName,
            AjaxOptions ajaxOptions)
        {
            return ajaxHelper.RenderAction(null,actionName, controllerName, null, ajaxOptions, null);
        }
        public static MvcHtmlString RenderAction(
            this AjaxHelper ajaxHelper,
            string id,
            string actionName,
            string controllerName,
            AjaxOptions ajaxOptions)
        {
            return ajaxHelper.RenderAction(id,actionName, controllerName, null, ajaxOptions,null);
        }
        public static MvcHtmlString RenderAction(
            this AjaxHelper ajaxHelper,
            string actionName,
            string controllerName,
            object routeValues,
            AjaxOptions ajaxOptions)
        {
            var routeValues1 = new RouteValueDictionary(routeValues);
            return ajaxHelper.RenderAction(null, actionName, controllerName, routeValues1, ajaxOptions, null);
        }
        public static MvcHtmlString RenderAction(
            this AjaxHelper ajaxHelper,
            string id,
            string actionName,
            string controllerName,
            object routeValues,
            AjaxOptions ajaxOptions)
        {
            var routeValues1 = new RouteValueDictionary(routeValues);
            return ajaxHelper.RenderAction(id,actionName, controllerName, routeValues1, ajaxOptions, null);
        }
        public static MvcHtmlString RenderAction(
            this AjaxHelper ajaxHelper,
            string actionName,
            string controllerName,
            object routeValues,
            AjaxOptions ajaxOptions,
            object htmlAttributes)
        {
            var routeValues1 = new RouteValueDictionary(routeValues);
            var routeValueDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            return ajaxHelper.RenderAction(null,actionName, controllerName, routeValues1, ajaxOptions, routeValueDictionary);
        }
        public static MvcHtmlString RenderAction(
            this AjaxHelper ajaxHelper,
            string id,
            string actionName,
            string controllerName,
            object routeValues,
            AjaxOptions ajaxOptions,
            object htmlAttributes)
        {
            var routeValues1 = new RouteValueDictionary(routeValues);
            var routeValueDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            return ajaxHelper.RenderAction(id,actionName, controllerName, routeValues1, ajaxOptions, routeValueDictionary);
        }
        public static MvcHtmlString RenderAction(
            this AjaxHelper ajaxHelper,
            string actionName,
            string controllerName,
            RouteValueDictionary routeValues,
            AjaxOptions ajaxOptions,
            IDictionary<string, object> htmlAttributes)
        {
            return ajaxHelper.RenderAction(null, actionName, controllerName, routeValues, ajaxOptions, htmlAttributes);

        }
        public static MvcHtmlString RenderAction(
            this AjaxHelper ajaxHelper,
            string id,
            string actionName,
            string controllerName,
            RouteValueDictionary routeValues,
            AjaxOptions ajaxOptions,
            IDictionary<string, object> htmlAttributes)
        {
            string targetUrl = UrlHelper.GenerateUrl((string)null, actionName, controllerName,routeValues, ajaxHelper.RouteCollection, ajaxHelper.ViewContext.RequestContext, true);
            return MvcHtmlString.Create(GenerateDiv(ajaxHelper,id,targetUrl, ajaxOptions, htmlAttributes));
        }

        private static string GenerateDiv(AjaxHelper ajaxHelper,
            string id,
            string targetUrl,
            AjaxOptions ajaxOptions,
            IDictionary<string, object> htmlAttributes)
        {
            id = string.IsNullOrEmpty(id) ? Guid.NewGuid().ToString() : id;
            var tagBuilder = new TagBuilder("div")
            {
                
            };
            if (string.IsNullOrEmpty(ajaxOptions.UpdateTargetId))
            {
                ajaxOptions.UpdateTargetId = id;
            }
            else
            {
                ajaxOptions.UpdateTargetId += ",#" + id;
            }
            tagBuilder.MergeAttribute("id", id);
            tagBuilder.MergeAttributes(htmlAttributes);
            tagBuilder.MergeAttribute("data-ajax-href", targetUrl);
            tagBuilder.MergeAttributes(ajaxOptions.ToUnobtrusiveHtmlAttributes());
            return tagBuilder.ToString(TagRenderMode.Normal);
        }
    }
}