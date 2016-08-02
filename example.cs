using System;
namespace InstagramMediaGetter
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var username="brandcollector_msk";
			MediaGetter media = new MediaGetter (username);
			Console.Write (media.getUserId());
		}
	}
}
