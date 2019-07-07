using Microsoft.AspNetCore.Http;

namespace CarRental.Common.Extensions
{
	public static class HttpRequestExtensions
	{
		public static string GetAbsoluteUri(this HttpRequest request)
		{
			return $"{request.Scheme}://{request.Host}{request.Path}{request.QueryString}";
		}
	}
}