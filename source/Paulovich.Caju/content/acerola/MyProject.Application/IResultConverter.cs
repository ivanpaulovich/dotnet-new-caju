namespace MyProject.Application
{
    public interface IResultConverter
    {
        T Map<T>(object source);
    }
}
