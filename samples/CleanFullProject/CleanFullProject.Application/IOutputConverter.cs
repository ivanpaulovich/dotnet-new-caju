namespace CleanFullProject.Application
{
    public interface IOutputConverter
    {
        T Map<T>(object source);
    }
}
