namespace WWoW.InformationSite.WebBlazor.Models;

public enum UpdateCategory { DevLog, Release, Media }

public sealed record UpdatePost(
    Guid Id,
    UpdateCategory Category,
    string Title,
    string Summary,
    string ImageUrl,
    DateTime Date,
    string? Slug = null
);

public static class UpdateData
{
    public static readonly IReadOnlyList<UpdatePost> All = new List<UpdatePost>
    {
        new(Guid.NewGuid(), UpdateCategory.Release, "WWoW Alpha 0.1.0 Released",
            "The first alpha release of WWoW is now available. Core simulation engine, basic AI behaviors, and a limited set of game content.",
            "https://images.unsplash.com/photo-1501785888041-af3ef285b470?q=80&w=1200&auto=format&fit=crop",
            new DateTime(2025, 01, 28), "alpha-010"),
        new(Guid.NewGuid(), UpdateCategory.DevLog, "AI Behavior Development Update",
            "Pathfinding improvements, more realistic combat tactics, and dynamic reactions to player actions and environmental changes.",
            "https://images.unsplash.com/photo-1518779578993-ec3579fee39f?q=80&w=1200&auto=format&fit=crop",
            new DateTime(2025, 01, 18), "devlog-ai-update"),
        new(Guid.NewGuid(), UpdateCategory.Media, "WWoW Gameplay Trailer",
            "Highlights of agent interactions, world exploration, and the quest system in action.",
            "https://images.unsplash.com/photo-1502082553048-f009c37129b9?q=80&w=1200&auto=format&fit=crop",
            new DateTime(2025, 01, 10), "gameplay-trailer"),
        new(Guid.NewGuid(), UpdateCategory.DevLog, "Server Tick & Scheduling",
            "Refined the simulation tick pipeline and introduced deterministic scheduling for agent actions.",
            "https://images.unsplash.com/photo-1520607162513-77705c0f0d4a?q=80&w=1200&auto=format&fit=crop",
            new DateTime(2024, 12, 22), "server-tick-scheduling"),
        new(Guid.NewGuid(), UpdateCategory.Release, "Patch 0.1.1",
            "Bug fixes, stability improvements, and expanded world state serialization.",
            "https://images.unsplash.com/photo-1499951360447-b19be8fe80f5?q=80&w=1200&auto=format&fit=crop",
            new DateTime(2025, 02, 02), "patch-011"),
    };
}