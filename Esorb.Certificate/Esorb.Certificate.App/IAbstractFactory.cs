namespace Esorb.Certificate.App
{
    public interface IAbstractFactory<T>
    {
        T Create();
    }
}