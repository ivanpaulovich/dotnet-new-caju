namespace Hexagonal_BasicProject.Application.Commands.Close
{
    using System.Threading.Tasks;

    public interface ICloseService
    {
        Task<CloseResult> Process(CloseCommand command);
    }
}
