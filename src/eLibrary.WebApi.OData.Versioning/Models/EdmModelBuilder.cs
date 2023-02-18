using Asp.Versioning;
using Asp.Versioning.OData;
using eLibrary.Models;
using Microsoft.OData.ModelBuilder;

namespace eLibrary.WebApi.OData.Models
{
    public class EdmModelBuilder : IModelConfiguration
    {
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion, string? routePrefix)
        {
            builder.EntitySet<Book>("Books");
        }
    }
}
