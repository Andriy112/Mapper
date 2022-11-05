namespace Mapper
{
    public abstract class MapperBase
    {
        public virtual TDestination[] ConvertArray<TSource, TDestination>(TSource[] sources, Action<IMapBuilder<TDestination>> map) where TDestination : class, new()
        {
            throw null;
        }
        public abstract TDestination Convert<TSource, TDestination>(TSource source, Action<IMapBuilder<TDestination>> map) where TDestination : class, new();

    }
}
