# InstagramMediaGetter
Simple instagram media getter.Provides you basic info about user and his media.Only public accounts are supported.No api keys or registration are needed.

<h2>Introduction</h2>
This soft allows you to get user info and media without any accounts and api's.Only http requests.
Just copy files and use:
```C#
using System;
namespace InstagramMediaGetter
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var username="yandex";
			MediaGetter media = new MediaGetter (username);
			Console.Write (media.GetUserId());
		}
	}
}
```

<h2>MediaGetter methods</h2>
<ul>
  <h3><li>1.GetUserId()</li></h3></ul>
  Returns user id string or if account is private error string:Error:private account
  Usage example:
```C#
	var username="yandex";
	MediaGetter media = new MediaGetter (username);
	Console.Write (media.GetUserId());//"29586504"
```
<ul>
  <h3><li>2.GetProfilePictureUrl()</li></h3></ul>
  Returns a link to user profile picture
  Usage example
  ```C#
	var username="yandex";
	MediaGetter media = new MediaGetter (username);
	Console.Write (media.GetProfilePictureUrl());//https://instagram.fath3-1.fna.fbcdn.net/t51.2885-19/11333326_1644414245770085_1832966911_a.jpg
```  
<ul>
  <h3><li>3.GetVerified()</li></h3></ul>
  Returns true if account is verified by instgram,if not verified returns false,
  if account is private returns null;
  
  Usage example
  ```C#
	var username="yandex";
	MediaGetter media = new MediaGetter (username);
	Console.Write (media.GetVerified());//true
```  
<ul>
  <h3><li>4.GetBiography()</li></h3></ul>
  Returns user description or error string if account is private
  Usage example
  ```C#
	var username="yandex";
	MediaGetter media = new MediaGetter (username);
	Console.Write (media.GetBiography());//Яндекс Найдётся всё. yandex.ru
```  
<ul>
  <h3><li>5.GetFollowsCount()</li></h3></ul>
  Returns number of accounts which user follows
  Usage example
  ```C#
	var username="yandex";
	MediaGetter media = new MediaGetter (username);
	Console.Write (media.GetFollowsCount());//7
```  
<ul>
  <h3><li>6.GetFollowedByCount()</li></h3></ul>
  Returns number of user followers
  Usage example
  ```C#
	var username="yandex";
	MediaGetter media = new MediaGetter (username);
	Console.Write (media.GetFollowedByCount());//19994
```  
<ul>
  <h3><li>7.GetUserMedia(long startTime=0)</li></h3></ul>
  Returns List<InstagramPostModel> of all user media since startTime(optional,by default 0);
  Usage example
  ```C#
	var username="yandex";
	MediaGetter media = new MediaGetter (username);
	List<InstagramPostModel> data=media.GetUserMedia();
```  
<h2>InstagramPostModal methods</h2>
<ul>
  <h3><li>1.GetLowResolutionImageUrl()</li></h3></ul>
  Returns string url of image in 320x320 resolution;
  
<ul>
  <h3><li>2.GetStandardResolutionImageUrl()</li></h3></ul>
  Returns string url of image in standard resolution;

<ul>
  <h3><li>3.GetCreatedTime()</li></h3></ul>
  Returns creation time in seconds(long);
 
 <ul>
  <h3><li>4.GetDescription()</li></h3></ul>
  Returns string picture description ;

<ul>
  <h3><li>5.GetPostUrl()</li></h3></ul>
  Returns url link to post string ;

<ul>
  <h3><li>6.GetId()</li></h3></ul>
  Returns string photoId;
  
<ul>
  <h3><li>7.GetMoreAvailable()</li></h3></ul>
  Returns bool if more data is available;
<h2>License</h2>
MIT
