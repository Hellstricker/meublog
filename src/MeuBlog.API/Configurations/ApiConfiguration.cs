using System.Runtime.CompilerServices;

namespace MeuBlog.Api.Configurations
{
    public static class ApiConfiguration
    {
        public static WebApplicationBuilder AddApiConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                        options.SuppressModelStateInvalidFilter = true
                );
            return builder;
        }
    }
}
