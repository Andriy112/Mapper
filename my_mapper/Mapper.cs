using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public delegate PropertyInfo Convert<S>(S value);
    public delegate void Setter<T, V>(T source, V dest);
    internal sealed class Mapper : MapperBase
    {

        public override TDestination Convert<TSource, TDestination>(TSource source, Action<IMapBuilder<TDestination>> map) where TDestination : class
        {
            IMapBuilder<TDestination> mapBuilder = null;
            mapBuilder ??= new MapBuilder<TDestination>();
            MapBuilder<TDestination>.source = source;
            map(mapBuilder);
            return MapBuilder<TDestination>.source != null ? (TDestination)mapBuilder.GetFiniteValue() : throw null;
        }

        public override TDestination[] ConvertArray<TSource, TDestination>(TSource[] sources, Action<IMapBuilder<TDestination>> map) where TDestination : class
        {
            if (sources.Length == 0)
            {
                base.ConvertArray(sources, map);
            }
            TDestination[] destination = new TDestination[sources.Length];
            foreach (int i in Enumerable.Range(0, sources.Length))
            {
                destination[i] = this.Convert<TSource, TDestination>(sources[i], map);
            }
            return destination;
        }
    }
}
