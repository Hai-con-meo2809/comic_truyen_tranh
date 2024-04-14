using System.Security.Cryptography;
using System.Text;

namespace Web_BanSach.Models
{
	public class Utils
	{
		public static String HmacSHA512(string key, String inputData)
		{
			var hash = new StringBuilder();
			byte[] keyBytes = Encoding.UTF8.GetBytes(key);
			byte[] inputBytes = Encoding.UTF8.GetBytes(inputData);
			using (var hmac = new HMACSHA512(keyBytes))
			{
				byte[] hashValue = hmac.ComputeHash(inputBytes);
				foreach (var theByte in hashValue)
				{
					hash.Append(theByte.ToString("x2"));
				}
			}

			return hash.ToString();
		}

		public static string GetIpAddress(HttpContext httpContext)
		{
			string ipAddress;
			try
			{
				ipAddress = httpContext.Request.Headers["X-Forwarded-For"];

				if (string.IsNullOrEmpty(ipAddress) || (ipAddress.ToLower() == "unknown") || ipAddress.Length > 45)
					ipAddress = httpContext.Connection.RemoteIpAddress.ToString();
			}
			catch (Exception ex)
			{
				ipAddress = "Invalid IP:" + ex.Message;
			}

			return ipAddress;
		}
	}
}
