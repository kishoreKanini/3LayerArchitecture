using MediatR;
using Kanini.EvaluationPortalFile.DataAccessLayer.Interface;
using Kanini.EvaluationPortal.UI.Command;

namespace Kanini.EvaluationPortal.UI.Handler;

public class AddUserHandler : IRequestHandler<AddUserCommand, bool>
{
    private readonly IUserRepository userRepository;

    public AddUserHandler(IUserRepository _userRepository)
    {
        this.userRepository = _userRepository;
    }

    public Task<bool> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(userRepository.AddUser(request.user));
    }
}

