namespace CleanBasicMongoProject.Application
{
    public interface IOutputConverter
    {
        T Map<T>(object source);
    }
}
