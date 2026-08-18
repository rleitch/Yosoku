namespace Yosoku.Worker.Extensions;

public static class HostApplicationBuilderExtensions
{
    public static T AddSettings<T>(this HostApplicationBuilder builder, string sectionName = "Settings")
        where T : class
    {
        var section = builder.Configuration.GetSection(sectionName);
        var settings = Activator.CreateInstance<T>();
        section.Bind(settings);
        builder.Services.Configure<T>(section);
        return settings;
    }
}