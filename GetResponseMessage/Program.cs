//using System;
//using System.IO;
//using System.Net;

//namespace GetResponseMessage
//{
//	internal class Program
//	{
//		static void Main(string[] args)
//		{
//			string requestUrl = "http://example.com";
//			string apiKey = "8081578a-e375-4fb9-8885-d2359fe94b72";

//			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl);
//			request.Method = "GET";
//			request.Headers.Add("apikey", apiKey);

//			try
//			{
//				using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
//				{
//					if (response.StatusCode == HttpStatusCode.OK)
//					{
//						using (Stream responseStream = response.GetResponseStream())
//						{
//							// Process the response stream here
//							// For example, you can read the stream using StreamReader
//							using (StreamReader reader = new StreamReader(responseStream))
//							{
//								string content = reader.ReadToEnd();
//								Console.WriteLine(content);
//							}
//						}
//					}
//				}
//			}
//			catch (WebException ex)
//			{
//				Console.WriteLine("An error occurred while making the request:");
//				Console.WriteLine(ex.ToString());
//			}

//			// Wait for user input before exiting
//			Console.WriteLine("Press Enter to exit...");
//			Console.ReadLine();
//		}
//	}
//}




using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace GetResponseMessage
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			var client = new HttpClient();
			HttpRequestMessage reqMsg = new HttpRequestMessage()
			{
				Headers = {
					{ "Accept", "*/*" },
					{ "apikey", "8081578a-e375-4fb9-8885-d2359fe94b72" },
				},
				Method = HttpMethod.Get,
				RequestUri = new Uri("http://118.189.146.180:9080/geopoints/list/fixes"),
				Version = new Version(1, 0)
			};

			try
			{
				HttpResponseMessage response = await client.SendAsync(reqMsg);
				//string content = await response.Content.ReadAsStringAsync();
				var responseValue = string.Empty;
				if (response.IsSuccessStatusCode)
				{

					Task task = response.Content.ReadAsStreamAsync().ContinueWith(t =>
					{
						var stream = t.Result;
						using (var reader = new StreamReader(stream))
						{
							responseValue = reader.ReadToEnd();
						}
					});

					task.Wait();

				}
				Console.WriteLine(responseValue);
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine("An error occurred while making the request:");
				Console.WriteLine(ex.ToString());
			}

			//Wait for the response to be completed before exiting

			Console.WriteLine("Press Enter to exit...");
			Console.ReadLine();
		}
	}
}
