namespace Clean_ReadOnlyProject.Application
{
    public interface IOutputConverter
    {
        T Map<T>(object source);
    }
}
