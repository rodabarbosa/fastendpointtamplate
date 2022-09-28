using FastEndpointTemplate.Persistence.Contexts;

namespace FastEndpointTemplate.Persistence.Test.Utils;

static public class ContextUtil
{
    public static ApplicationContext GetContext()
    {
        var builder = new DbContextOptionsBuilder<ApplicationContext>();
        builder.UseInMemoryDatabase("ApiTemplate");
        return new ApplicationContext(builder.Options);
    }
}
