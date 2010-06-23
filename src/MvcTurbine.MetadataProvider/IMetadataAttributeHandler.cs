using System.Web.Mvc;

namespace MvcTurbine.MetadataProvider
{
    public interface IMetadataAttributeHandler<T> : IMetadataAttributeHandlerBase
    {
    }

    public interface IMetadataAttributeHandlerBase
    {
        void AlterMetadata(ModelMetadata metadata, CreateMetadataArguments args);
    }
}