using MediatR;
using Kanini.EvaluationPortalFile.DataAccessLayer.Interface;
using Kanini.EvaluationPortal.UI.Query;
using Kanini.EvaluationPortalFile.DataAccessLayer.Entity;

namespace Kanini.EvaluationPortal.UI.Handler;

public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<User>>
{
    private readonly IUserRepository _userRepository;
    public GetAllUsersHandler(IUserRepository userRepository)
    {
        this._userRepository = userRepository;
    }

    public Task<List<User>> Handle(GetAllUsersQuery command, CancellationToken cancellationToken)
    {
        return Task.FromResult(this._userRepository.GetAllUsers());
    }
}
