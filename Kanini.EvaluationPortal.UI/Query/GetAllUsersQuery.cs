using MediatR;
using Kanini.EvaluationPortalFile.DataAccessLayer.Entity;

namespace Kanini.EvaluationPortal.UI.Query;

public record GetAllUsersQuery():IRequest<List<User>>;
