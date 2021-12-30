using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Nest;
using SmartApi.Core;
using SmartApi.Core.Domains;
using SmartApi.Core.Interfaces;

namespace SmartApi.Infrastructure.Services
{
    public class Service : IService
    {
        private ElasticClient _elasticClient;

        public Service(ElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public List<Property> SearchApartment(string query)
        {
            try
            {    

                var request = _elasticClient.Search<Property>(s => s
                                .Index("properties")
                                .Query(a => a
                                          .MultiMatch(b => b
                                            .Fields(c=>c
                                                .Field("name")
                                                .Field("formerName")
                                                .Field("streetAddress")
                                                .Field("city")
                                                .Field("market")
                                                .Field("state")
                                            )
                                            .Query(query)
                                           )
                                        )
                            );

                var result = JsonSerializer.Deserialize<List<Property>>(JsonSerializer.Serialize(request.Documents));
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Management> SearchManagement(string query)
        {
            try
            {

                var request = _elasticClient.Search<Management>(s => s
                                .Index("management")
                                .Query(a => a
                                          .MultiMatch(b => b
                                            .Fields(c => c
                                                .Field("name")
                                                .Field("market")
                                                .Field("state")
                                            )
                                            .Query(query)
                                           )
                                        )
                            );

                var result = JsonSerializer.Deserialize<List<Management>>(JsonSerializer.Serialize(request.Documents));
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}
