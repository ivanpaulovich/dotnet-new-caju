namespace Hexagonal_ReadOnlyProject.Application
{
    public interface IResultConverter
    {
        T Map<T>(object source);
    }
}
