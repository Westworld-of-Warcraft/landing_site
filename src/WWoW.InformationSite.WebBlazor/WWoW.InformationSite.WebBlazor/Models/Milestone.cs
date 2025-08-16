namespace WWoW.InformationSite.WebBlazor.Models;

public enum ProjectTaskStatus { Completed, InProgress, Planned }

public sealed record TaskItem(string Title, ProjectTaskStatus Status);

public sealed record Milestone(string Title, ProjectTaskStatus Status, int Percent, IReadOnlyList<TaskItem> Tasks);

public static class MilestoneData
{
    public static IReadOnlyList<Milestone> All => new List<Milestone>
    {
        new(
            "Milestone 1: Core AI Framework",
            ProjectTaskStatus.Completed,
            100,
            new[]
            {
                new TaskItem("Decision Engine", ProjectTaskStatus.Completed),
                new TaskItem("World State Management", ProjectTaskStatus.Completed),
                new TaskItem("Basic Bot Navigation", ProjectTaskStatus.Completed),
            }
        ),
        new(
            "Milestone 2: Dynamic World Interactions",
            ProjectTaskStatus.InProgress,
            65,
            new[]
            {
                new TaskItem("Environmental Awareness", ProjectTaskStatus.Completed),
                new TaskItem("Reactive Behaviors", ProjectTaskStatus.InProgress),
                new TaskItem("Advanced Navigation", ProjectTaskStatus.InProgress),
                new TaskItem("Player Interaction Framework", ProjectTaskStatus.Planned),
            }
        ),
        new(
            "Milestone 3: Advanced Bot Behaviors",
            ProjectTaskStatus.InProgress,
            25,
            new[]
            {
                new TaskItem("Complex Decision Making", ProjectTaskStatus.InProgress),
                new TaskItem("Social Interactions", ProjectTaskStatus.Planned),
                new TaskItem("Learning and Adaptation", ProjectTaskStatus.Planned),
            }
        ),
        new(
            "Milestone 4: Performance Optimization",
            ProjectTaskStatus.Planned,
            0,
            new[]
            {
                new TaskItem("Memory Management", ProjectTaskStatus.Planned),
                new TaskItem("Concurrent Processing", ProjectTaskStatus.Planned),
                new TaskItem("Load Testing", ProjectTaskStatus.Planned),
            }
        ),
        new(
            "Milestone 5: Public Beta Release",
            ProjectTaskStatus.Planned,
            0,
            new[]
            {
                new TaskItem("Beta Testing Framework", ProjectTaskStatus.Planned),
                new TaskItem("User Documentation", ProjectTaskStatus.Planned),
                new TaskItem("Community Integration", ProjectTaskStatus.Planned),
            }
        ),
    };
}