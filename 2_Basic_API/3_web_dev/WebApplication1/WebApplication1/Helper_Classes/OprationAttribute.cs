using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace WebApplication1.Helper_Classes
{
    public class OprationAttribute : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null)
                operation.parameters = new List<Parameter>();

            operation.parameters.Add(new Parameter
            {
                name = "Authorization",
                @in = "header",
                type = "string",
                description = "Add authorization token over here",
                required = false
            });
        }
    }
}