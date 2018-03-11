namespace Hexagonal_ReadOnlyProject.Application.Commands.Close
{
    using System.Threading.Tasks;

    public interface ICloseService
    {
        Task<CloseResult> Process(CloseCommand command);
    }
}
