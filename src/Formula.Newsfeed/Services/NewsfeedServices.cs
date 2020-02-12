using Formula.Newsfeed.Extentions;
using Formula.Newsfeed.Model;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Xml;

namespace Formula.Newsfeed.Services
{
    class NewsfeedServices
    {
        public List<FeedItem> GetItems(string feed)
        {
            List<FeedItem> itens = new List<FeedItem>();
            SyndicationFeed syndicationFeed = SyndicationFeed.Load(XmlReader.Create(feed));


            foreach (SyndicationItem item in syndicationFeed.Items.Take(6))
            {
                FeedItem feedItem = new FeedItem
                {
                    Title = item.Title.Text,
                    Url = item.Id.Replace("http://dev.vtnorton", "http://vtnorton").Replace("http://yapp.vtnorton", "http://vtnorton"),
                    Content = WebUtility.HtmlDecode(item.Summary?.Text.RemoveHTML())
                };

                itens.Add(feedItem);
            }

            return itens;
        }
    }
}
