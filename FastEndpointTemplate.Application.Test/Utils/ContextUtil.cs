using Microsoft.EntityFrameworkCore;

namespace FastEndpointTemplate.Application.Test.Utils;

static public class ContextUtil
{
    public static ApplicationContext GetContext()
    {
        var builder = new DbContextOptionsBuilder<ApplicationContext>();
        builder.UseInMemoryDatabase("ApiTemplate");
        return new ApplicationContext(builder.Options);
    }
}
