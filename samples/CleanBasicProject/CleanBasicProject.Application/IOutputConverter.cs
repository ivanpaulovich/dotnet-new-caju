namespace CleanBasicProject.Application
{
    public interface IOutputConverter
    {
        T Map<T>(object source);
    }
}
