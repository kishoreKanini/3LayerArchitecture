using MediatR;
using Kanini.EvaluationPortalFile.DataAccessLayer.Entity;

namespace Kanini.EvaluationPortal.UI.Query;

public record LoginQuery(string email, string password):IRequest<User>;
