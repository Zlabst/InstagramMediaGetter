using System;
using System.Net;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
namespace InstagramMediaGetter
{
    public class MediaGetter
    {
        private string _id;
        private string _username;
        private bool _isPrivate;
        private bool? _isVerified;
        private string _profilePicUrlHD;
        private string _profilePicUrl;
        private string _biography;
        private int? _followsCount;
        private int? _followedByCount;

        public MediaGetter(string user)
        {
            _username = user;
            getBasicInfo();

        }

        /// <summary>
        /// Provides basic info about user 
        /// </summary>
        private void getBasicInfo()
        {
            string html = string.Empty;
            string url = @"https://instagram.com/" + _username + "/?__a=1";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }
            dynamic data = JsonConvert.DeserializeObject(html);
            _isPrivate = data.user.is_private;
            if (_isPrivate)
            {
                _id = null;
                _profilePicUrlHD = null;
                _profilePicUrl = null;
                _isVerified = null;
                _biography = null;
                _followsCount = null;
                _followedByCount = null;
                return;
            }
            _id = data.user.id;
            _profilePicUrlHD = data.user.profile_pic_url_hd;
            _profilePicUrl = data.user.profile_pic_url;
            _isVerified = data.user.is_verified;
            _biography = data.user.biography;
            _followsCount = data.user.follows.count;
            _followedByCount = data.user.followed_by.count;
        }

        /// <summary>
        /// Provides userId
        /// </summary>
        /// <returns>string User Id or error string</returns>
        public string GetUserId()
        {
            if (_isPrivate)
            {
                if (_id != null)
                {
                    return _id;
                }
            }
            return "Error:private account";
        }

        /// <summary>
        /// Provides url to profile picture in HD
        /// </summary>
        /// <returns>Url string or error string</returns>
        public string GetProfilePictureHdUrl()
        {
            if (_isPrivate)
            {
                if (_profilePicUrlHD != null)
                {
                    return _profilePicUrlHD;
                }
            }
            return "Error:private account";
        }

        /// <summary>
        /// Provides url to profile picture
        /// </summary>
        /// <returns>Url string or error string</returns>
        public string GetProfilePictureUrl()
        {
            if (_isPrivate)
            {
                if (_profilePicUrl != null)
                {
                    return _profilePicUrl;
                }
            }
            return "Error:private account";
        }

        /// <summary>
        /// Provides is user verified or not 
        /// </summary>
        /// <returns>if Verified return true else false,
        /// if account is private return null</returns>
        public bool? GetVerified()
        {
            if (_isPrivate)
            {
                if (_isVerified != null)
                {
                    return _isVerified;
                }
            }
            return null;
        }

        /// <summary>
        /// Provides user biography 
        /// </summary>
        /// <returns>string biography or error string</returns>
        public string GetBiography()
        {
            if (_isPrivate)
            {
                if (_biography != null)
                {
                    return _biography;
                }
            }
            return "Error:private account";
        }

        /// <summary>
        /// Provides followings number of user 
        /// </summary>
        /// <returns>follows count int or null if user is private</returns>
        public int? GetFollowsCount()
        {
            if (_isPrivate)
            {
                if (_followsCount != null)
                {
                    return _followsCount;
                }
            }
            return null;
        }

        /// <summary>
        /// Provides followed by count of user
        /// </summary>
        /// <returns>followed by count int or null if user is private</returns>
        public int? GetFollowedByCount()
        {
            if (_isPrivate)
            {
                if (_followedByCount != null)
                {
                    return _followedByCount;
                }
            }
            return null;
        }

        /// <summary>
        /// Provides user media
        /// </summary>
        /// <param name="startTime">optional Defines time from which func returns user media,by default all photos</param>
        /// <returns>List of InstagramPostModel</returns>
        public List<InstagramPostModel> GetUserMedia(int startTime=0)
        {
            List <InstagramPostModel> postList = new List<InstagramPostModel>();
            string html = string.Empty;
            if (_isPrivate)
            {
                return postList;
            }
           
            string url = @"https://instagram.com/" + _username + "/media";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }
            dynamic data = JsonConvert.DeserializeObject(html);
            foreach (var item in data.items)
            {
                string lowResImageUrl = item.image.low_resolution.url;
                string standardResImageUrl = item.image.standard_resolution.url;
                long createdTime = item.caption.created_time;
                string text = item.caption.text;
                string photoId = item.id;
                string postUrl = item.link;
                int likesCount = item.likes.count;
                bool moreAvailable = data.more_available;
                if (startTime > createdTime)
                {
                    return postList;
                }
                InstagramPostModel temp = new InstagramPostModel(lowResImageUrl, standardResImageUrl, createdTime, text, photoId, postUrl, likesCount, moreAvailable);
                postList.Add(temp);
            }
            if (!postList[postList.Count-1].GetMoreAvailable())
            {
                return postList;
            }
            if (startTime > postList[postList.Count - 1].GetCreatedTime())
            {
                return postList;
            }
            bool MoreAvail = true;
            string lastId = postList[postList.Count - 1].GetId();

            while (MoreAvail)
            {
                html = string.Empty;
                url = @"https://instagram.com/" + _username + "/media/?max_id="+lastId;

                request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    html = reader.ReadToEnd();
                }
                dynamic dataLocal = JsonConvert.DeserializeObject(html);
                foreach (var item in dataLocal.items)
                {
                    string lowResImageUrl = item.image.low_resolution.url;
                    string standardResImageUrl = item.image.standard_resolution.url;
                    long createdTime = item.caption.created_time;
                    string text = item.caption.text;
                    string photoId = item.id;
                    string postUrl = item.link;
                    int likesCount = item.likes.count;
                    bool moreAvailable = data.more_available;
                    if (startTime > createdTime)
                    {
                        return postList;
                    }
                    InstagramPostModel temp = new InstagramPostModel(lowResImageUrl, standardResImageUrl, createdTime, text, photoId, postUrl, likesCount, moreAvailable);
                    postList.Add(temp);
                }
                if (!postList[postList.Count-1].GetMoreAvailable())
                {
                    return postList;
                }
                if (startTime > postList[postList.Count - 1].GetCreatedTime())
                {
                    return postList;
                }
                MoreAvail = postList[postList.Count - 1].GetMoreAvailable();
                lastId = postList[postList.Count - 1].GetId();

            }

        }

    }
}