namespace Mapper
{
    public interface IMapBuilder<TDest>
    {
        TDest _Dest { get; set; }
        object GetFiniteValue();
        IMapBuilder<TDest> FromProperty<Dest>(string source_name, Convert<Type> converter);
        IMapBuilder<TDest> FromPropertyManualy<Source>(Setter<Source, TDest> setter);
    }
}
