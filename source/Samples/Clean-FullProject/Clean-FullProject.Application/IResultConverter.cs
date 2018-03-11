namespace Clean_FullProject.Application
{
    public interface IResultConverter
    {
        T Map<T>(object source);
    }
}
