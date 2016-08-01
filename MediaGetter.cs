using System;
using System.Net;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;
namespace instagramMediaGetter
{
	public class MediaGetter
	{
		private string id;
		public string username;

		public MediaGetter (string user)
		{
			username = user;
			getBasicInfo();
			
		}
		private void getBasicInfo(){
			string html = string.Empty;
			string url = @"https://instagram.com/" + username + "/?__a=1";

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create (url);
			request.AutomaticDecompression = DecompressionMethods.GZip;

			using (HttpWebResponse response = (HttpWebResponse)request.GetResponse ())
			using (Stream stream = response.GetResponseStream ())
			using (StreamReader reader = new StreamReader (stream)) {
				html = reader.ReadToEnd ();

				dynamic data = JsonConvert.DeserializeObject (html);
				id = data.user.id;
			}
		}
		public string getUserId()
		{
			return id;

		}
	}
}