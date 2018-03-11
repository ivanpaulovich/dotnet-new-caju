namespace Hexagonal_EmptyProject.Application
{
    public interface IOutputConverter
    {
        T Map<T>(object source);
    }
}
