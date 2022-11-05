namespace Mapper
{
    internal sealed class MapBuilder<_TDest> : IMapBuilder<_TDest>
        where _TDest : class, new()
    {
        public _TDest _Dest { get; set; } = new();

        internal static object source { get; set; }

        IMapBuilder<_TDest> IMapBuilder<_TDest>.FromProperty<Dest>(string source_name, Convert<Type> converter)
        {
            var Source_Property = source.GetType().GetProperty(source_name).GetValue(source);
            converter(typeof(Dest)).SetValue(_Dest, Source_Property);
            return this;
        }

        object IMapBuilder<_TDest>.GetFiniteValue()
        {
            return _Dest;
        }

        IMapBuilder<_TDest> IMapBuilder<_TDest>.FromPropertyManualy<Source>(Setter<Source, _TDest> setter)
        {
            setter((Source)source, _Dest);
            return this;
        }
    }
}
