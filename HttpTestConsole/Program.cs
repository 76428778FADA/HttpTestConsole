using System;
using System.Net;
using System.Text;

namespace HttpTestConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var http = new WebClient())
			{
				http.Headers.Add("Content-Type", "application/json; charset=utf-8");
				http.DownloadDataCompleted += Http_DownloadDataCompleted;

				var uri = new Uri("http://itashelp.hivedome.net/umbraco/api/helpapi/GetFieldHelpWithCulture?id=01024&c=en");
				http.DownloadDataAsync(uri);
			}

			Console.WriteLine("-----------------------------");
			Console.WriteLine("Press ENTER to EXIT");
			Console.WriteLine("-----------------------------");
			Console.ReadLine();
		}

		private static void Http_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				Console.WriteLine("WEB REQUEST ERROR!");
				Console.WriteLine(e.Error.ToString());
			}
			else
			{
				Console.WriteLine("WEB REQUEST SUCCESS!");
				Console.WriteLine(Encoding.UTF8.GetString(e.Result));
			}
		}
	}
}
