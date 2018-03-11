namespace Clean_EmptyProject.Application
{
    public interface IOutputConverter
    {
        T Map<T>(object source);
    }
}
