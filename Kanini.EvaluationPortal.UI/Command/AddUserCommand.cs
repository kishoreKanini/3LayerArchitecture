using MediatR;
using Kanini.EvaluationPortalFile.DataAccessLayer.Entity;

namespace Kanini.EvaluationPortal.UI.Command;

public record AddUserCommand(User user):IRequest<bool>;