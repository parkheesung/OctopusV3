using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using OctopusV3.API.Google;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace OctopusV3.API
{
    public class GoogleAPI : ApiHelperBase, IDisposable
    {
        public GoogleAccount google { get; set; } = new GoogleAccount();

        public GoogleAPIAuth auth { get; set; } = new GoogleAPIAuth();

        protected OctopusV3.Core.ILogHelper Logger { get; set; }

        public GoogleAPI() : base()
        {
        }

        public List<Subscription> GetSubscriptions(string channelID)
        {
            List<Subscription> result = new List<Subscription>();

            using (var youtube = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = this.auth.ApiKey,
                ApplicationName = this.ApplicationName
            }))
            {
                try
                {
                    SubscriptionsResource.ListRequest listRequest = youtube.Subscriptions.List("snippet");
                    // listRequest.MySubscribers = False
                    // listRequest.Mine = False
                    listRequest.ChannelId = channelID;
                    listRequest.MaxResults = 50;
                    listRequest.Order = SubscriptionsResource.ListRequest.OrderEnum.Alphabetical;

                    SubscriptionListResponse searchResponse = listRequest.Execute();

                    while (true)
                    {
                        foreach (Subscription searchResult in searchResponse.Items)
                        {
                            result.Add(searchResult);
                        }

                        if (!string.IsNullOrEmpty(searchResponse.NextPageToken))
                        {
                            listRequest.PageToken = searchResponse.NextPageToken;
                            searchResponse = listRequest.Execute();
                        }
                        else
                        {
                            break; // TODO: might not be correct. Was : Exit Do
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (Logger != null)
                    {
                        Logger.Error(ex);
                    }
                }
            }

            return result;

        }

        public List<SearchResult> GetSearch(string keyword)
        {
            var result = new List<SearchResult>();

            using (var youtube = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = this.auth.ApiKey,
                ApplicationName = this.ApplicationName
            }))
            {
                try
                {
                    var listRequest = youtube.Search.List("snippet");
                    // listRequest.MySubscribers = False
                    // listRequest.Mine = False
                    listRequest.Q = keyword;
                    listRequest.MaxResults = 50;
                    listRequest.Order = SearchResource.ListRequest.OrderEnum.Date;

                    var searchResponse = listRequest.Execute();

                    while (true)
                    {
                        foreach (var searchResult in searchResponse.Items)
                        {
                            result.Add(searchResult);
                        }

                        if (!string.IsNullOrEmpty(searchResponse.NextPageToken))
                        {
                            listRequest.PageToken = searchResponse.NextPageToken;
                            searchResponse = listRequest.Execute();
                        }
                        else
                        {
                            break; // TODO: might not be correct. Was : Exit Do
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (Logger != null)
                    {
                        Logger.Error(ex);
                    }
                }
            }

            return result;

        }

        public List<Playlist> GetPlaylists(string channelID)
        {
            var result = new List<Playlist>();

            using (var youtube = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = this.auth.ApiKey,
                ApplicationName = this.ApplicationName
            }))
            {
                try
                {
                    var listRequest = youtube.Playlists.List("snippet");
                    // listRequest.MySubscribers = False
                    // listRequest.Mine = False
                    listRequest.MaxResults = 50;
                    listRequest.ChannelId = channelID;

                    var searchResponse = listRequest.Execute();

                    while (true)
                    {
                        foreach (var searchResult in searchResponse.Items)
                        {
                            result.Add(searchResult);
                        }

                        if (!string.IsNullOrEmpty(searchResponse.NextPageToken))
                        {
                            listRequest.PageToken = searchResponse.NextPageToken;
                            searchResponse = listRequest.Execute();
                        }
                        else
                        {
                            break; // TODO: might not be correct. Was : Exit Do
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (Logger != null)
                    {
                        Logger.Error(ex);
                    }
                }
            }

            return result;

        }

        public List<PlaylistItem> GetPlaylistItems(string playListID)
        {
            var result = new List<PlaylistItem>();

            using (var youtube = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = this.auth.ApiKey,
                ApplicationName = this.ApplicationName
            }))
            {
                try
                {
                    var listRequest = youtube.PlaylistItems.List("snippet");
                    // listRequest.MySubscribers = False
                    // listRequest.Mine = False
                    listRequest.MaxResults = 50;
                    listRequest.PlaylistId = playListID;

                    var searchResponse = listRequest.Execute();

                    while (true)
                    {
                        foreach (var searchResult in searchResponse.Items)
                        {
                            result.Add(searchResult);
                        }

                        if (!string.IsNullOrEmpty(searchResponse.NextPageToken))
                        {
                            listRequest.PageToken = searchResponse.NextPageToken;
                            searchResponse = listRequest.Execute();
                        }
                        else
                        {
                            break; // TODO: might not be correct. Was : Exit Do
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (Logger != null)
                    {
                        Logger.Error(ex);
                    }
                }
            }

            return result;

        }
        public BloggerData GetBlog(string blogID)
        {
            var result = new BloggerData();

            using (var wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                string tmp = wc.DownloadString("https://" + $"www.googleapis.com/blogger/v3/blogs/{blogID}/?key={this.auth.ApiKey}");
                if (!string.IsNullOrWhiteSpace(tmp))
                {
                    result = this.Deserialize<BloggerData>(tmp);
                }
            }

            return result;
        }

        public BloggerPost GetPost(string blogID)
        {
            var result = new BloggerPost();

            using (var wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                string tmp = wc.DownloadString("https://" + $"www.googleapis.com/blogger/v3/blogs/{blogID}/posts/?key={this.auth.ApiKey}");
                if (!string.IsNullOrWhiteSpace(tmp))
                {
                    result = this.Deserialize<BloggerPost>(tmp);
                }
            }

            return result;
        }

        public void Dispose()
        {
            
        }
    }
}
