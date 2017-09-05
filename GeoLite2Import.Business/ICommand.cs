namespace GeoLite2Import.Business
{
    public interface ICommand<T>
    {
        T Execute();
    }
}