using System.Buffers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Web.Api.Filters
{
    public class JsonConfigFilterAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ObjectResult objectResult)
            {
                var serializerSettings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = new DefaultContractResolver()
                };

                serializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                serializerSettings.MaxDepth = 2;

                var jsonFormatter = new NewtonsoftJsonOutputFormatter(
                    serializerSettings,
                    ArrayPool<char>.Shared,
                    new MvcOptions());

                objectResult.Formatters.Add(jsonFormatter);
            }

            base.OnResultExecuting(context);
        }
    }
}
