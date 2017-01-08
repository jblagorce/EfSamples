namespace CustomSqlFunctions
{
    using System;
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class CustomFunctionConvention : IConceptualModelConvention<EdmModel>
    {
        public void Apply(EdmModel item, DbModel model)
        {
            var functionParseInt = new EdmFunctionPayload()
            {
                CommandText = String.Format("CAST(strValue AS {0})", PrimitiveType.GetEdmPrimitiveType(PrimitiveTypeKind.Int32)),
                Parameters = new[] {
                    FunctionParameter.Create("strValue", PrimitiveType.GetEdmPrimitiveType(PrimitiveTypeKind.String), ParameterMode.In),
                },

                ReturnParameters = new[] {
                    FunctionParameter.Create("ReturnValue", PrimitiveType.GetEdmPrimitiveType(PrimitiveTypeKind.Int32), ParameterMode.ReturnValue),
                },
                IsComposable = true
            };

            var function = EdmFunction.Create("ParseInt", model.ConceptualModel.EntityTypes.First().NamespaceName, DataSpace.CSpace, functionParseInt, null);
            model.ConceptualModel.AddItem(function);
        }
    }
}
