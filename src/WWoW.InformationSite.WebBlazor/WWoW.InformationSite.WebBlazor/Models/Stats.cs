namespace WWoW.InformationSite.WebBlazor.Models;

public enum StatsTab { BotsOnline, Economy, RaidHealth, ServerStatus }

public static class StatsLabels
{
    public static string Label(StatsTab t) => t switch
    {
        StatsTab.BotsOnline  => "Bots Online",
        StatsTab.Economy     => "Economy Metrics",
        StatsTab.RaidHealth  => "Raid Health",
        StatsTab.ServerStatus=> "Server Status",
        _ => t.ToString()
    };

    public static string Anchor(StatsTab t) => t switch
    {
        StatsTab.BotsOnline  => "bots-online",
        StatsTab.Economy     => "economy-metrics",
        StatsTab.RaidHealth  => "raid-health",
        StatsTab.ServerStatus=> "server-status",
        _ => string.Empty
    };
}