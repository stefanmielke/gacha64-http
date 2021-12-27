using Gacha64Http.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gacha64Http.Controllers;

[Route("/notifications")]
public class NotificationsController : Controller
{
    private static readonly List<Notification> Notifications = new List<Notification>
    {
        new Notification("Mielke got a 'Mistermind'"),
        new Notification("Ana got a 'Cute Bear'"),
        new Notification("Mielke got a 'Plushie'"),
    };

    [HttpGet]
    public IActionResult Index()
    {
        const int maxResults = 5;
        var skipCount = Math.Max(Notifications.Count - maxResults, 0);
        return Content(string.Join("\n", Notifications.Skip(skipCount).Take(maxResults).Select(n => n)));
    }

    [HttpPost]
    public IActionResult Post([FromQuery] string message)
    {
        if (string.IsNullOrWhiteSpace(message))
            return StatusCode(400);

        message = message.Replace("_", " ");

        Notifications.Add(new Notification(message));

        return Ok();
    }
}