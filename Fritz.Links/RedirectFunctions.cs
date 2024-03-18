using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Fritz.Links
{
	public class RedirectFunctions
	{
		private readonly ILogger<RedirectFunctions> _logger;

		public RedirectFunctions(ILogger<RedirectFunctions> logger)
		{
			_logger = logger;
		}

		[Function(name: "RedirectUrl")]
		public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "r/{shortUrl}")] HttpRequest req,
			string shortUrl
		)
		{

			if (string.IsNullOrEmpty(shortUrl)) {
				return new OkResult();
			}

			var targetUrl = shortUrl.ToLowerInvariant() switch
			{
				"discord" => "https://discord.gg/zFyukmNzRX",
				_ => "https://jeffreyfritz.com"
			};

			return new RedirectResult(targetUrl);

		}
	}
}
