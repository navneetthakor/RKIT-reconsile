using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebApplication1.Helper_Classes;
namespace WebApplication1.Utilitlies
{
    /// <summary>
    /// JWT middleware : it checks for token in header of request
    /// </summary>
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        /// <summary>
        /// it token is present, it attaches to the 'User' field of request
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                AttachUserToContext(context, token);
            }

            await _next(context);
        }

        private void AttachUserToContext(HttpContext context, string token)
        {
            try
            {
                ClaimsPrincipal result = JWT.ValidateJwtToken(token, out string email );
                if (result != null)
                {
                    context.User = result; // Attach user to context
                }
                return;
            }
            catch
            {
                Console.WriteLine("JWT verification faild");
                return;
            }
        }
    }
}