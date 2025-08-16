using WWoW.InformationSite.WebBlazor.Components;
using WWoW.InformationSite.WebBlazor.Models;
using System.Text;
using System.Xml;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

// RSS Feed endpoint
app.MapGet("/rss", () =>
{
    var rss = GenerateRssFeed();
    return Results.Content(rss, "application/rss+xml; charset=utf-8");
});

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

static string GenerateRssFeed()
{
    var posts = UpdateData.All.OrderByDescending(p => p.Date).Take(10);
    
    var sb = new StringBuilder();
    using var writer = XmlWriter.Create(sb, new XmlWriterSettings { Indent = true });
    
    writer.WriteStartDocument();
    writer.WriteStartElement("rss");
    writer.WriteAttributeString("version", "2.0");
    
    writer.WriteStartElement("channel");
    writer.WriteElementString("title", "WWoW Updates");
    writer.WriteElementString("description", "Latest updates from the WWoW development team");
    writer.WriteElementString("link", "https://wwow.dev/updates");
    writer.WriteElementString("lastBuildDate", DateTime.UtcNow.ToString("R"));
    
    foreach (var post in posts)
    {
        writer.WriteStartElement("item");
        writer.WriteElementString("title", post.Title);
        writer.WriteElementString("description", post.Summary);
        writer.WriteElementString("link", $"https://wwow.dev/updates/{post.Slug ?? post.Id.ToString()}");
        writer.WriteElementString("pubDate", post.Date.ToString("R"));
        writer.WriteElementString("category", post.Category.ToString());
        writer.WriteElementString("guid", post.Id.ToString());
        writer.WriteEndElement(); // item
    }
    
    writer.WriteEndElement(); // channel
    writer.WriteEndElement(); // rss
    writer.WriteEndDocument();
    
    return sb.ToString();
}
