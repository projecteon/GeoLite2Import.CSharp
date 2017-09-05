namespace GeoLite2Import
{
    public interface ICommand<T>
    {
        T Execute();
    }
}