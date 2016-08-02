# InstagramMediaGetter
Simple instagram media getter.Provides you basic info about user and his media.Only public accounts are supported 
<h2>Introduction</h2>
This soft allows you to get user info and media without any accounts and api's.Only http.requests.
Just copy files and use:
```C#
using System;
using InstagramMediaGetter;
class MainClass
	{
		public static void Main (string[] args)
		{
			var username="yandex";
			MediaGetter media = new MediaGetter (username);
			Console.Write (media.GetUserId());
		}
	}
```
<h2>License</h2>
MIT
<h2>MediaGetter methods</h2>
<ul>
  <h3><li>1.GetUserId()</li></h3>
  example:
  ```C#
  var username="yandex";
  MediaGetter media = new MediaGetter (username);
	Console.Write (media.GetUserId());
  ```
  
</ul>
