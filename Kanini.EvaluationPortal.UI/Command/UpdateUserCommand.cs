using MediatR;
using Kanini.EvaluationPortalFile.DataAccessLayer.Entity;

namespace Kanini.EvaluationPortal.UI.Command;

public record UpdateUserCommand(User user) : IRequest<bool>; 
