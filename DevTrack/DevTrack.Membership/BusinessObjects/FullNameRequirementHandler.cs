using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace DevTrack.Membership.BusinessObjects
{
    public class FullNameRequirementHandler : AuthorizationHandler<FullNameRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, FullNameRequirement requirement)
        {
            var claim = context.User.FindFirst("FullName");
            if (claim != null && !string.IsNullOrWhiteSpace(claim.Value))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
