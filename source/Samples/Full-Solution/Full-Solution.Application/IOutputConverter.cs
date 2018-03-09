namespace Full_Solution.Application
{
    public interface IOutputConverter
    {
        T Map<T>(object source);
    }
}
