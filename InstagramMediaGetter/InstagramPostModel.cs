using System;
using Newtonsoft.Json;

namespace InstagramMediaGetter
{
    public class InstagramPostModel
    {
        private string _lowResolutionImageUrl;
        private string _standardResolutionImageUrl;
        private long _createdTime;
        private string _text;
        private string _photoId;
        private string _postUrl;
        private int _likesCount;
        private bool _moreAvailable;
        public InstagramPostModel(string lowResolutionImageUrl, string standardResolutionImageUrl, long createdTime, string text, string photoId, string postUrl, int likesCount,bool moreAvailable)
        {
            _lowResolutionImageUrl = lowResolutionImageUrl;
            _standardResolutionImageUrl = standardResolutionImageUrl;
            _createdTime = createdTime;
            _text = text;
            _photoId = photoId;
            _postUrl = postUrl;
            _likesCount= likesCount;
            _moreAvailable = moreAvailable;

        }

        /// <summary>
        /// Provides URL of low resolution image
        /// </summary>
        /// <returns>string url</returns>
        public string GetLowResolutionImageUrl()
        {
            return _lowResolutionImageUrl;
        }

        /// <summary>
        /// Provides URL of standard resolution image
        /// </summary>
        /// <returns>string url</returns>
        public string GetStandardResolutionImageUrl()
        {
            return _standardResolutionImageUrl;
        }

        /// <summary>
        /// Provides created time
        /// </summary>
        /// <returns>long created time in seconds</returns>
        public long GetCreatedTime()
        {
            return _createdTime;
        }

        /// <summary>
        /// Provides description of photo
        /// </summary>
        /// <returns>string description</returns>
        public string GetDescription()
        {
            return _text;
        }

        /// <summary>
        /// Provides link to post with this photo
        /// </summary>
        /// <returns>URL string</returns></returns>
        public string GetPostUrl()
        {
            return _postUrl;
        }

        /// <summary>
        /// Provides photo id
        /// </summary>
        /// <returns>string id</returns>
        public string GetId()
        {
            return _photoId;
        }

        /// <summary>
        /// Provides description of photo
        /// </summary>
        /// <returns>string description</returns>
        public int GetLikesCount(){
            return _likesCount;
        }

        /// <summary>
        /// Provides moreAvailable status
        /// </summary>
        /// <returns>bool moreAvailable</returns>
        public bool GetMoreAvailable(){
            return _moreAvailable;
        }
    
    }
}

