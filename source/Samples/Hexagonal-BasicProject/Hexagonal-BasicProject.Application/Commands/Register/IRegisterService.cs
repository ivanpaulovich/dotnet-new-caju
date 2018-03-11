namespace Hexagonal_BasicProject.Application.Commands.Register
{
    using System.Threading.Tasks;

    public interface IRegisterService
    {
        Task<RegisterResult> Process(RegisterCommand message);
    }
}
