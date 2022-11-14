﻿using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace eLibrary.WebApi.OData.Models
{
    public static class EdmModelBuilder
    {
        public static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Book>("Books");
            return builder.GetEdmModel();
        }
    }
}
