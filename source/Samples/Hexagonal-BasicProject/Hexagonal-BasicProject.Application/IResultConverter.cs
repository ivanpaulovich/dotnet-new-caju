namespace Hexagonal_BasicProject.Application
{
    public interface IResultConverter
    {
        T Map<T>(object source);
    }
}
