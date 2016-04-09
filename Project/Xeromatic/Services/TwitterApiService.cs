using System.Collections.Generic;
using System.Linq;
using Tweetinvi;
using Tweetinvi.Core.Credentials;
using Tweet = Xeromatic.Models.Tweet;

namespace Xeromatic.Services
{
    public class TwitterApiService : ITwitterService
    {
        // Get keys from: https://apps.twitter.com
        // Wiki for tweetinvi: https://github.com/linvi/tweetinvi/wiki

        readonly TwitterCredentials _creds;

        public TwitterApiService()
        {
            _creds = new TwitterCredentials
            {
                ConsumerKey = "UCeOk3fECxQ7KBCfXlI5jyAic",
                ConsumerSecret = "bydz8ebkb8Wr9xOqbJflb6s5QzoxsG69HZE9NBoObDWDzVkZhy",
                AccessToken = "718575110974603264-6lGrfBafHupcAO9ZCsO0YWg5bT6DqZc",
                AccessTokenSecret = "JRy4h9UZ1AGgogDdB3u3qbII1oQPaBsLiUqpC4l0N9gES"
            };
        }

        public IEnumerable<Tweet> GetTweets()
        {
            var tweets = 
                Auth.ExecuteOperationWithCredentials(_creds, () => Timeline.GetUserTimeline("xero", 10)).ToList();
            if (tweets.Any())
                return tweets.Select(t => new Tweet
                {
                    Id = t.Id,
                    Text = t.Text
                });
            return new List<Tweet>();
        }

    }
}