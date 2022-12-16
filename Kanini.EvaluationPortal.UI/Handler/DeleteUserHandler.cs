using MediatR;
using Kanini.EvaluationPortalFile.DataAccessLayer.Interface;
using Kanini.EvaluationPortal.UI.Command;

namespace Kanini.EvaluationPortal.UI.Handler;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, bool> 
{
    private IUserRepository _userRepository;
    public DeleteUserHandler(IUserRepository userRepository)
    {
        this._userRepository = userRepository;
    }
        
    public Task<bool> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        return Task.FromResult(this._userRepository.DeleteUser(command.user));
    }
}
