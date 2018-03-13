namespace HexagonalBasicWithoutInfraProject.Application
{
    public interface IOutputConverter
    {
        T Map<T>(object source);
    }
}
