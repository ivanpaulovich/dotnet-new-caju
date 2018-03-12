namespace CleanBasicWithoutInfraProject.Application
{
    public interface IOutputConverter
    {
        T Map<T>(object source);
    }
}
