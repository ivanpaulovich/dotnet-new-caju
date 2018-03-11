namespace Clean_FullProject.Application
{
    public interface IOutputConverter
    {
        T Map<T>(object source);
    }
}
