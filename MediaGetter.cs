﻿using System;
using System.Net;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;
namespace instagramMediaGetter
{
	public class MediaGetter
	{
		public string username;
		private void getBasicInfo(){
			/*
			string html = string.Empty;
			string url = @"https://instagram.com/"+username+"/?__a=1";

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.AutomaticDecompression = DecompressionMethods.GZip;

			using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
			using (Stream stream = response.GetResponseStream())
			using (StreamReader reader = new StreamReader(stream))
			{
				html = reader.ReadToEnd();
			}
			*/
			var html="{\"user\": {\"username\": \"brandcollector_msk\", \"has_blocked_viewer\": false, \"follows\": {\"count\": 4523}, \"requested_by_viewer\": false, \"followed_by\": {\"count\": 87599}, \"external_url_linkshimmed\": \"http://l.instagram.com/?e=ATPwz8QT9E2lCGWOq80vM4JMmTicuK8kwsoZZzHJj-p-ymLpQyGaaGLy\\u0026u=http%3A%2F%2FWWW.BRAND-COLLECTOR.COM%2F\", \"has_requested_viewer\": false, \"country_block\": null, \"follows_viewer\": false, \"profile_pic_url_hd\": \"https://scontent.cdninstagram.com/t51.2885-19/s320x320/12142185_1635024990097978_1756038568_a.jpg\", \"profile_pic_url\": \"https://scontent.cdninstagram.com/t51.2885-19/s150x150/12142185_1635024990097978_1756038568_a.jpg\", \"is_private\": false, \"full_name\": \"\\u2800\\u2800\\u2800\\u2800\\u2800BRAND\\u2022COLLECTOR\", \"media\": {\"count\": 1302, \"page_info\": {\"has_previous_page\": false, \"start_cursor\": \"1307422913049235415\", \"end_cursor\": \"1307283784110060899\", \"has_next_page\": true}, \"nodes\": [{\"code\": \"BIk5jZfgY_X\", \"dimensions\": {\"width\": 1080, \"height\": 1080}, \"owner\": {\"id\": \"10682709\"}, \"comments\": {\"count\": 0}, \"caption\": \"\\u0422\\u0443\\u0444\\u043b\\u0438 Alexander McQueen 36.5 \\u0432 \\u0445\\u043e\\u0440\\u043e\\u0448\\u0435\\u043c \\u0441\\u043e\\u0441\\u0442\\u043e\\u044f\\u043d\\u0438\\u0438, 7000rub. Wapp: +79167111011 www.brand-collector.com #bcalexandermcqueen #bc36\\u0440\\u0430\\u0437\\u043c\\u0435\\u0440 #bc\\u0442\\u0443\\u0444\\u043b\\u0438 #bc\\u043c\\u043e\\u0441\\u043a\\u0432\\u0430\", \"likes\": {\"count\": 1}, \"date\": 1470076978, \"thumbnail_src\": \"https://scontent.cdninstagram.com/t51.2885-15/s640x640/sh0.08/e35/13774384_1776931232583528_43257411_n.jpg?ig_cache_key=MTMwNzQyMjkxMzA0OTIzNTQxNQ%3D%3D.2\", \"is_video\": false, \"id\": \"1307422913049235415\", \"display_src\": \"https://scontent.cdninstagram.com/t51.2885-15/e35/13774384_1776931232583528_43257411_n.jpg?ig_cache_key=MTMwNzQyMjkxMzA0OTIzNTQxNQ%3D%3D.2\"}, {\"code\": \"BIk5Oyeg4QO\", \"dimensions\": {\"width\": 1080, \"height\": 1080}, \"owner\": {\"id\": \"10682709\"}, \"comments\": {\"count\": 1}, \"caption\": \"\\u0422\\u0435\\u043a\\u0441\\u0442\\u0438\\u043b\\u044c\\u043d\\u044b\\u0435 \\u0442\\u0443\\u0444\\u043b\\u0438 Elizabeth and James 38 \\u0432 \\u0445\\u043e\\u0440\\u043e\\u0448\\u0435\\u043c \\u0441\\u043e\\u0441\\u0442\\u043e\\u044f\\u043d\\u0438\\u0438 5500rub. Wapp: \\u207a79110101013 www.brand-collector.com #bc\\u0442\\u0443\\u0444\\u043b\\u0438 #bc\\u043f\\u0438\\u0442\\u0435\\u0440 #bc38\\u0440\\u0430\\u0437\\u043c\\u0435\\u0440\", \"likes\": {\"count\": 5}, \"date\": 1470076809, \"thumbnail_src\": \"https://scontent.cdninstagram.com/t51.2885-15/s640x640/sh0.08/e35/13628157_302720996747830_75316655_n.jpg?ig_cache_key=MTMwNzQyMTQ5Njc2NzEyMDM5OA%3D%3D.2\", \"is_video\": false, \"id\": \"1307421496767120398\", \"display_src\": \"https://scontent.cdninstagram.com/t51.2885-15/e35/13628157_302720996747830_75316655_n.jpg?ig_cache_key=MTMwNzQyMTQ5Njc2NzEyMDM5OA%3D%3D.2\"}, {\"code\": \"BIk47A_A4m1\", \"dimensions\": {\"width\": 1080, \"height\": 1080}, \"owner\": {\"id\": \"10682709\"}, \"comments\": {\"count\": 0}, \"caption\": \"\\u0422\\u0443\\u0444\\u043b\\u0438 Sergio Rossi 38.5 \\u0432 \\u0445\\u043e\\u0440\\u043e\\u0448\\u0435\\u043c \\u0441\\u043e\\u0441\\u0442\\u043e\\u044f\\u043d\\u0438\\u0438 6000rub. Wapp: \\uff0b79167111011 www.brand-collector.com #bcsergiorossi #bc\\u0442\\u0443\\u0444\\u043b\\u0438 #bc\\u043c\\u043e\\u0441\\u043a\\u0432\\u0430  #bc38\\u0440\\u0430\\u0437\\u043c\\u0435\\u0440\", \"likes\": {\"count\": 8}, \"date\": 1470076647, \"thumbnail_src\": \"https://scontent.cdninstagram.com/t51.2885-15/s640x640/sh0.08/e35/13743613_551613031714585_623930309_n.jpg?ig_cache_key=MTMwNzQyMDEzNzk1NTIzMjE4MQ%3D%3D.2\", \"is_video\": false, \"id\": \"1307420137955232181\", \"display_src\": \"https://scontent.cdninstagram.com/t51.2885-15/e35/13743613_551613031714585_623930309_n.jpg?ig_cache_key=MTMwNzQyMDEzNzk1NTIzMjE4MQ%3D%3D.2\"}, {\"code\": \"BIkxUMZAKwL\", \"dimensions\": {\"width\": 1080, \"height\": 1080}, \"owner\": {\"id\": \"10682709\"}, \"comments\": {\"count\": 0}, \"caption\": \"\\u041e\\u0447\\u043a\\u0438 Chanel, \\u043d\\u043e\\u0432\\u044b\\u0435, 12000rub. Wapp: \\uff0b79167111011 www.brand-collector.com #BrandCollector #bc\\u043c\\u043e\\u0441\\u043a\\u0432\\u0430 #bc\\u043e\\u0447\\u043a\\u0438 #bc\\u043d\\u043e\\u0432\\u043e\\u0435 #bcchanel\", \"likes\": {\"count\": 11}, \"date\": 1470072659, \"thumbnail_src\": \"https://scontent.cdninstagram.com/t51.2885-15/s640x640/sh0.08/e35/13745172_539650899564185_2071935318_n.jpg?ig_cache_key=MTMwNzM4NjY4MzgxNzI0MTYxMQ%3D%3D.2\", \"is_video\": false, \"id\": \"1307386683817241611\", \"display_src\": \"https://scontent.cdninstagram.com/t51.2885-15/e35/13745172_539650899564185_2071935318_n.jpg?ig_cache_key=MTMwNzM4NjY4MzgxNzI0MTYxMQ%3D%3D.2\"}, {\"code\": \"BIkwOTPgsZ-\", \"dimensions\": {\"width\": 1080, \"height\": 1080}, \"owner\": {\"id\": \"10682709\"}, \"comments\": {\"count\": 0}, \"caption\": \"\\u0411\\u043e\\u0441\\u043e\\u043d\\u043e\\u0436\\u043a\\u0438 D\\u0026G 36\\u0440\\u0430\\u0437\\u043c\\u0435\\u0440 \\u0432 \\u043e\\u0442\\u043b\\u0438\\u0447\\u043d\\u043e\\u043c \\u0441\\u043e\\u0441\\u0442\\u043e\\u044f\\u043d\\u0438\\u0438, \\u0441 \\u043f\\u0440\\u043e\\u0444\\u0438\\u043b\\u0430\\u043a\\u0442\\u0438\\u043a\\u043e\\u0439, 5500rub. Wapp: \\uff0b79167111011 www.brand-collector.com #bcdolcegabbana #bc\\u0431\\u043e\\u0441\\u043e\\u043d\\u043e\\u0436\\u043a\\u0438 #bc36\\u0440\\u0430\\u0437\\u043c\\u0435\\u0440 #bc\\u043c\\u043e\\u0441\\u043a\\u0432\\u0430\", \"likes\": {\"count\": 12}, \"date\": 1470072086, \"thumbnail_src\": \"https://scontent.cdninstagram.com/t51.2885-15/s640x640/sh0.08/e35/13687393_661468894001686_1524144264_n.jpg?ig_cache_key=MTMwNzM4MTg4MDgxMDgxNzE1MA%3D%3D.2\", \"is_video\": false, \"id\": \"1307381880810817150\", \"display_src\": \"https://scontent.cdninstagram.com/t51.2885-15/e35/13687393_661468894001686_1524144264_n.jpg?ig_cache_key=MTMwNzM4MTg4MDgxMDgxNzE1MA%3D%3D.2\"}, {\"code\": \"BIktXRjgWKn\", \"dimensions\": {\"width\": 1080, \"height\": 1080}, \"owner\": {\"id\": \"10682709\"}, \"comments\": {\"count\": 0}, \"caption\": \"\\u0421\\u0443\\u043c\\u043a\\u0430 Gucci, \\u0432 \\u0441\\u043e\\u0441\\u0442\\u043e\\u044f\\u043d\\u0438\\u0438 \\u043d\\u043e\\u0432\\u043e\\u0439, \\u0446\\u0435\\u043d\\u0430 \\u0441\\u043d\\u0438\\u0436\\u0435\\u043d\\u0430\\u203c\\ufe0f 43000rub. Wapp: +79167111011 www.brand-collector.com #bcgucci #bc\\u0441\\u0443\\u043c\\u043a\\u0438 #bc\\u043c\\u043e\\u0441\\u043a\\u0432\\u0430\", \"likes\": {\"count\": 16}, \"date\": 1470070587, \"thumbnail_src\": \"https://scontent.cdninstagram.com/t51.2885-15/s640x640/sh0.08/e35/13658377_1047193952033319_1898758443_n.jpg?ig_cache_key=MTMwNzM2OTMwMzMzNDU0NDAzOQ%3D%3D.2\", \"is_video\": false, \"id\": \"1307369303334544039\", \"display_src\": \"https://scontent.cdninstagram.com/t51.2885-15/e35/13658377_1047193952033319_1898758443_n.jpg?ig_cache_key=MTMwNzM2OTMwMzMzNDU0NDAzOQ%3D%3D.2\"}, {\"code\": \"BIkqtrRghXx\", \"dimensions\": {\"width\": 1080, \"height\": 1080}, \"owner\": {\"id\": \"10682709\"}, \"comments\": {\"count\": 0}, \"caption\": \"\\u0422\\u0443\\u0444\\u043b\\u0438 Sergio Rossi 39, \\u043d\\u043e\\u0432\\u044b\\u0435, 22000rub. Wapp: \\uff0b79167111011 www.brand-collector.com #BrandCollector #bc\\u043c\\u043e\\u0441\\u043a\\u0432\\u0430 #bc\\u0442\\u0443\\u0444\\u043b\\u0438 #bcsergiorossi #bc39\\u0440\\u0430\\u0437\\u043c\\u0435\\u0440 #bc\\u043d\\u043e\\u0432\\u043e\\u0435\", \"likes\": {\"count\": 16}, \"date\": 1470069198, \"thumbnail_src\": \"https://scontent.cdninstagram.com/t51.2885-15/s640x640/sh0.08/e35/13734261_543701459164157_1976726769_n.jpg?ig_cache_key=MTMwNzM1NzY0ODYzODg0MjM1Mw%3D%3D.2\", \"is_video\": false, \"id\": \"1307357648638842353\", \"display_src\": \"https://scontent.cdninstagram.com/t51.2885-15/e35/13734261_543701459164157_1976726769_n.jpg?ig_cache_key=MTMwNzM1NzY0ODYzODg0MjM1Mw%3D%3D.2\"}, {\"code\": \"BIknzTwgpEa\", \"dimensions\": {\"width\": 1080, \"height\": 1080}, \"owner\": {\"id\": \"10682709\"}, \"comments\": {\"count\": 0}, \"caption\": \"\\u0422\\u043e\\u043f Dolce\\u0026Gabbana S \\u0432 \\u0438\\u0434\\u0435\\u0430\\u043b\\u0435 14000rub. Wapp: +79167111011 www.brand-collector.com #bcdolcegabbana #bc\\u0431\\u043b\\u0443\\u0437\\u043a\\u0438 #bc\\u0442\\u043e\\u043f\\u044b #bc\\u043c\\u043e\\u0441\\u043a\\u0432\\u0430\", \"likes\": {\"count\": 17}, \"date\": 1470067671, \"thumbnail_src\": \"https://scontent.cdninstagram.com/t51.2885-15/s640x640/sh0.08/e35/13712512_1827207204174731_1485005649_n.jpg?ig_cache_key=MTMwNzM0NDg0MTU2NjQ5MDkwNg%3D%3D.2\", \"is_video\": false, \"id\": \"1307344841566490906\", \"display_src\": \"https://scontent.cdninstagram.com/t51.2885-15/e35/13712512_1827207204174731_1485005649_n.jpg?ig_cache_key=MTMwNzM0NDg0MTU2NjQ5MDkwNg%3D%3D.2\"}, {\"code\": \"BIkkLMwgTbm\", \"dimensions\": {\"width\": 1080, \"height\": 1080}, \"owner\": {\"id\": \"10682709\"}, \"comments\": {\"count\": 0}, \"caption\": \"\\u0420\\u0443\\u0431\\u0430\\u0448\\u043a\\u0430 D\\u0026G xs \\u0432 \\u0438\\u0434\\u0435\\u0430\\u043b\\u0435 7000rub. Wapp: +79167111011 www.brand-collector.com\\n#bcdg #bcdolcegabbana #bc\\u0440\\u0443\\u0431\\u0430\\u0448\\u043a\\u0438 #bc\\u043c\\u043e\\u0441\\u043a\\u0432\\u0430\", \"likes\": {\"count\": 13}, \"date\": 1470065770, \"thumbnail_src\": \"https://scontent.cdninstagram.com/t51.2885-15/s640x640/sh0.08/e35/13702969_109251586186077_412447302_n.jpg?ig_cache_key=MTMwNzMyODg5MTEzMTYwNjc1OA%3D%3D.2\", \"is_video\": false, \"id\": \"1307328891131606758\", \"display_src\": \"https://scontent.cdninstagram.com/t51.2885-15/e35/13702969_109251586186077_412447302_n.jpg?ig_cache_key=MTMwNzMyODg5MTEzMTYwNjc1OA%3D%3D.2\"}, {\"code\": \"BIkhuLtAI4I\", \"dimensions\": {\"width\": 1080, \"height\": 1080}, \"owner\": {\"id\": \"10682709\"}, \"comments\": {\"count\": 0}, \"caption\": \"\\u0411\\u043e\\u0441\\u043e\\u043d\\u043e\\u0436\\u043a\\u0438 Miu Miu 41, \\u0432 \\u043e\\u0442\\u043b\\u0438\\u0447\\u043d\\u043e\\u043c \\u0441\\u043e\\u0441\\u0442\\u043e\\u044f\\u043d\\u0438\\u0438, 16000rub. Wapp: \\uff0b79167111011 www.brand-collector.com #BrandCollector #bc\\u043c\\u043e\\u0441\\u043a\\u0432\\u0430 #bc\\u0431\\u043e\\u0441\\u043e\\u043d\\u043e\\u0436\\u043a\\u0438 #bcmiumiu #bc41\\u0440\\u0430\\u0437\\u043c\\u0435\\u0440\", \"likes\": {\"count\": 18}, \"date\": 1470064483, \"thumbnail_src\": \"https://scontent.cdninstagram.com/t51.2885-15/s640x640/sh0.08/e35/13707300_517911635067665_1611273080_n.jpg?ig_cache_key=MTMwNzMxODEwMTA0MTI1Mzg5Ng%3D%3D.2\", \"is_video\": false, \"id\": \"1307318101041253896\", \"display_src\": \"https://scontent.cdninstagram.com/t51.2885-15/e35/13707300_517911635067665_1611273080_n.jpg?ig_cache_key=MTMwNzMxODEwMTA0MTI1Mzg5Ng%3D%3D.2\"}, {\"code\": \"BIkd8HzgoRD\", \"dimensions\": {\"width\": 1080, \"height\": 1080}, \"owner\": {\"id\": \"10682709\"}, \"comments\": {\"count\": 0}, \"caption\": \"\\u0411\\u043e\\u0442\\u0438\\u043b\\u044c\\u043e\\u043d\\u044b Rupert Sanderson 36.5, \\u0432 \\u043e\\u0442\\u043b\\u0438\\u0447\\u043d\\u043e\\u043c \\u0441\\u043e\\u0441\\u0442\\u043e\\u044f\\u043d\\u0438\\u0438, 14000rub. Wapp \\uff0b79167111011 www.brand-collector.com #BrandCollector #bc\\u0431\\u043e\\u0442\\u0438\\u043b\\u044c\\u043e\\u043d\\u044b #bc\\u043c\\u043e\\u0441\\u043a\\u0432\\u0430 #bc36\\u0440\\u0430\\u0437\\u043c\\u0435\\u0440 #bcrupertsanderson\", \"likes\": {\"count\": 29}, \"date\": 1470062500, \"thumbnail_src\": \"https://scontent.cdninstagram.com/t51.2885-15/s640x640/sh0.08/e35/13732229_635663956592656_2100886607_n.jpg?ig_cache_key=MTMwNzMwMTQ2Njc0MjA5Njk2Mw%3D%3D.2\", \"is_video\": false, \"id\": \"1307301466742096963\", \"display_src\": \"https://scontent.cdninstagram.com/t51.2885-15/e35/13732229_635663956592656_2100886607_n.jpg?ig_cache_key=MTMwNzMwMTQ2Njc0MjA5Njk2Mw%3D%3D.2\"}, {\"code\": \"BIkZ6zkgjVj\", \"dimensions\": {\"width\": 1080, \"height\": 1080}, \"owner\": {\"id\": \"10682709\"}, \"comments\": {\"count\": 0}, \"caption\": \"\\u0411\\u043b\\u0443\\u0437\\u0430 Gianfranco Ferre S/M, \\u0432 \\u0445\\u043e\\u0440\\u043e\\u0448\\u0435\\u043c \\u0441\\u043e\\u0441\\u0442\\u043e\\u044f\\u043d\\u0438\\u0438, 3500rub. Wapp: \\uff0b79167111011 www.brand-collector.com #BrandCollector #bc\\u043c\\u043e\\u0441\\u043a\\u0432\\u0430 #bc\\u0431\\u043b\\u0443\\u0437\\u044b #bcgianfrancoferre\", \"likes\": {\"count\": 10}, \"date\": 1470060392, \"thumbnail_src\": \"https://scontent.cdninstagram.com/t51.2885-15/s640x640/sh0.08/e35/13744256_517987795069483_82709924_n.jpg?ig_cache_key=MTMwNzI4Mzc4NDExMDA2MDg5OQ%3D%3D.2\", \"is_video\": false, \"id\": \"1307283784110060899\", \"display_src\": \"https://scontent.cdninstagram.com/t51.2885-15/e35/13744256_517987795069483_82709924_n.jpg?ig_cache_key=MTMwNzI4Mzc4NDExMDA2MDg5OQ%3D%3D.2\"}]}, \"blocked_by_viewer\": false, \"followed_by_viewer\": false, \"is_verified\": false, \"id\": \"10682709\", \"biography\": \"\\u041a\\u043e\\u043c\\u0438\\u0441\\u0441\\u0438\\u043e\\u043d\\u043d\\u044b\\u0439 \\u0431\\u0443\\u0442\\u0438\\u043a, 100% \\u043e\\u0440\\u0438\\u0433\\u0438\\u043d\\u0430\\u043b\\u044b\\n\\u041c\\u043e\\u0441\\u043a\\u0432\\u0430, \\u0412\\u0441\\u043f\\u043e\\u043b\\u044c\\u043d\\u044b\\u0439 \\u043f\\u0435\\u0440\\u0435\\u0443\\u043b\\u043e\\u043a \\u0434.3 \\u041f\\u043d-\\u041f\\u0442: 11.00-21.00 \\u0421\\u0431-\\u0412\\u0441: \\u0432\\u044b\\u0445\\u043e\\u0434\\u043d\\u043e\\u0439\\u274c +7(916)711-10-11\", \"external_url\": \"http://WWW.BRAND-COLLECTOR.COM\"}";
			dynamic data = JsonConvert.DeserializeObject(html);
			string s = data.user.username;
			Console.Write (s);
		}
		public MediaGetter (string user)
		{
			username = user;
			getBasicInfo ();
			
		}
		public string getUserId ()
		{
			return "vasya";

		}
	}
}