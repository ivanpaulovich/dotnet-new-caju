namespace Clean_BasicProject.Application
{
    public interface IOutputConverter
    {
        T Map<T>(object source);
    }
}
