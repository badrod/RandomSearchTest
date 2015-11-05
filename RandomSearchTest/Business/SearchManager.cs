using Nest;
using RandomSearchTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomSearchTest.Business
{
    public static class  SearchManager
    {
        public static IEnumerable<Person> FindPerson(string query)
        {

            var client = Business.SearchManager.ElasticClient;

            var searchResults = client.Search<Person>(s => s
                 .From(0)
                 .Size(10000)
                 .Query(q => q
                      .Term(p => p.Firstname, query)
                 ) );

            return searchResults.Documents.ToList();
        }
        public static ElasticClient ElasticClient
        {
            get
            {
                var node = new Uri("http://localhost:9200");

                var settings = new ConnectionSettings(
                    node,
                    defaultIndex: "my-application");

                return new ElasticClient(settings);



            }
        }
    }
}
