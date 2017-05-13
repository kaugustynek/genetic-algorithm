using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EncogTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://wiadomosci.wp.pl/ver,rss,rss.xml";
            using (XmlReader reader = XmlReader.Create(url))
            {
                SyndicationFeed feed = SyndicationFeed.Load(reader);

                foreach (SyndicationItem item in feed.Items)
                {
                    String subject = item.Title.Text;
                    //String summary = item.Summary.Text;
                    String summary = item.PublishDate.ToString();

                    Console.WriteLine($"{subject}");
                    Console.WriteLine($"{summary}");
                }
            }
        }
    }
}
