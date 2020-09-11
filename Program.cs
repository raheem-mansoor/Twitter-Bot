using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using TweetSharp;
using static Sunriset;
using System.Security.Cryptography.X509Certificates;

namespace Twitter_Bot_v._2._1
{
	class Program
	{
		private static string customer_key = "";
		private static string customer_key_secret = "";
		private static string access_token = "";
		private static string acces_token_secret = ";

		private static TwitterService service = new TwitterService(customer_key,
																   customer_key_secret,
																   access_token,
																   acces_token_secret);

		static void Main(string[] args)
		{
			
			Console.WriteLine("Jahr eingeben:");
			int year = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Monat eingeben:");
			int month = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Aktuellen Tag eingeben:");
			int day = Convert.ToInt32(Console.ReadLine());

			double tsunrise, tsunset;

			Sunriset.SunriseSunset(year, month, day, 49.00937, 8.40444, out tsunrise, out tsunset);
			TimeSpan sunriseTime = TimeSpan.FromHours(tsunrise);
			TimeSpan sunsetTime = TimeSpan.FromHours(tsunset);
			string sunriseTimeString = sunriseTime.ToString(@"hh\:mm\:ss");
			string sunsetTimeString = sunsetTime.ToString(@"hh\:mm\:ss");

			System.TimeSpan durationCET = new System.TimeSpan(0, 2, 0, 0);

			System.TimeSpan sunRiseResultCET = sunriseTime.Add(durationCET);
			System.TimeSpan sunSetResultCET = sunsetTime.Add(durationCET);
			string sunRiseResultCetString = sunRiseResultCET.ToString(@"hh\:mm\:ss");
			string sunSetResultCetString = sunSetResultCET.ToString(@"hh\:mm\:ss");

			DateTime sunriseFinalDT = DateTime.Today;
			TimeSpan sunriseFinalTS = sunRiseResultCET;
			sunriseFinalDT = sunriseFinalDT + sunriseFinalTS;
			
			DateTime sunsetFinalDT = DateTime.Today;
			TimeSpan sunsetFinalTS = sunSetResultCET;
			sunsetFinalDT = sunsetFinalDT + sunsetFinalTS;

			Console.WriteLine("Sonnenaufgang in Karlsruhe ist um: " + sunriseFinalDT);
			Console.WriteLine("Sonnenuntergang in Karlsruhe ist um: " + sunsetFinalDT);

			Console.WriteLine($"<{DateTime.Now}> - Bot started");

			while (true)
			{
				DateTime localTime = DateTime.Now;
				
				int timeComparison = DateTime.Compare(localTime, sunriseFinalDT);

				bool checkPoint = false;

				if (timeComparison > 0)
				{
					SendTweet($"It's {sunriseFinalDT} Good Morning Karlsruhe!");
					checkPoint = true;
				}
				if (checkPoint == true)
				{
					break;
				}
			}
			while (true)
			{
				DateTime localTimeTwo = DateTime.Now;
				int timeComparisonTwo = DateTime.Compare(localTimeTwo, sunsetFinalDT);

				if (timeComparisonTwo > 0)
				{
					SendTweet($"It's {sunsetFinalDT} Good Night Karlsruhe");
					Console.Read();
					break;
				}
			}
		}
		
		public static void SendTweet(string _status)
		{
			service.SendTweet(new SendTweetOptions { Status = _status }, (tweet, response) =>
			{
				if (response.StatusCode == HttpStatusCode.OK)
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine($"{DateTime.Now}> - Tweet sent!");
					Console.ResetColor();
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine($"<Error> " + response.Error.Message);
					Console.ResetColor();
				}

			});
		}
	}
}
