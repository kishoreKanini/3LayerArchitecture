using MediatR;
using Kanini.EvaluationPortalFile.DataAccessLayer.Entity;

namespace Kanini.EvaluationPortal.UI.Command;

public record DeleteUserCommand(User user):IRequest<bool>;
