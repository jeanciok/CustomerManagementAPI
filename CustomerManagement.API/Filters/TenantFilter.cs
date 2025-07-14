using CustomerManagementAPI.Attributes;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CustomerManagementAPI.Filters
{
    public class TenantFilter : IActionFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TenantFilter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            bool ignoreTenant = context.ActionDescriptor.EndpointMetadata
                .Any(m => m.GetType() == typeof(IgnoreTenantAttribute));


            if (!ignoreTenant)
            {
                string tenantId = _httpContextAccessor.HttpContext.User.FindFirst("tenant_id")?.Value;

                if (!string.IsNullOrEmpty(tenantId))
                {
                    context.HttpContext.Items["TenantId"] = tenantId;
                }
                else
                {
                    throw new Exception("Tenant not found");
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
