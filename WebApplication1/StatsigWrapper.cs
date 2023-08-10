using Statsig;
using Statsig.Server;

namespace WebApplication1;

public class StatsigWrapper
{
    public static async Task<StatsigWrapper> Create()
    {
        var driver = new ServerDriver("SECRET_KEY_HERE",
            new StatsigServerOptions(environment: new StatsigEnvironment(tier: EnvironmentTier.Production))
        );
        await driver.Initialize();
        return new StatsigWrapper(driver);
    }

    private ServerDriver _driver;

    private StatsigWrapper(ServerDriver driver)
    {
        _driver = driver;
    }

    public async Task<bool> CheckGate(StatsigUser user, string gateName)
    {
        return await _driver.CheckGate(user, gateName);
    }
}