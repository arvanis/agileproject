using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;

namespace ImNew
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            // Web API configuration and services
            // Web API routes
			config.EnableCors();
            config.MapHttpAttributeRoutes();
			var jsonFormatter = new JsonMediaTypeFormatter();
			//optional: set serializer settings here
			config.Services.Replace(typeof(IContentNegotiator), new JsonContentNegotiator(jsonFormatter));

			config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }

	public class JsonContentNegotiator : IContentNegotiator
	{
		private readonly JsonMediaTypeFormatter _jsonFormatter;

		public JsonContentNegotiator(JsonMediaTypeFormatter formatter)
		{
			_jsonFormatter = formatter;
		}

		public ContentNegotiationResult Negotiate(
				Type type,
				HttpRequestMessage request,
				IEnumerable<MediaTypeFormatter> formatters)
		{
			return new ContentNegotiationResult(
				_jsonFormatter,
				new MediaTypeHeaderValue("application/json"));
		}
	}
}
