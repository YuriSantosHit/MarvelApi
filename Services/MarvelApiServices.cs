using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using MarvelApi.Model;
using MarvelApi.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MarvelApi.Controllers
{
        
        [ProducesResponseType(typeof(MarvelApiServices), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
    public class MarvelApiServices
    {


        private readonly string url = "http://gateway.marvel.com/v1/public/series?ts=1&apikey=473da253b3977826288936c4a61c0991&hash=8be15a064f1557728066139e0619aaf6";
        string JsonRetorno;
        int count = 1;

        public string BuscaDadosApiMarvel()
        {
            ListaResultados result = GetRequest();
            string retorno = ParseiaResultado(result);
            FileTxt file = new FileTxt(retorno);
            return retorno;
        }

        private string ParseiaResultado(ListaResultados result)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in result.results)
            {
                sb.AppendLine("--------------------------------------------------------------------------------------------------------------------");
                if (item.id != null)
                {
                    sb.AppendLine("Id: " + item.id);
                }
                if (item.name != null)
                {
                    sb.AppendLine("\tName: " + item.name);
                }

                if (item.description != null)
                {
                    sb.AppendLine("\tDescription: " + item.description);
                }

                if (item.comics != null)
                {
                    foreach (var comics in item.comics.items)
                    {
                        sb.AppendLine("\t\tComics: " + count + " - " + comics.name);
                        count++;
                    }
                }
                count = 1;

                if (item.series != null)
                {
                    foreach (var series in item.series.items)
                    {
                        sb.AppendLine("\t\tSeries: " + count + " - " + series.name);
                        count++;
                    }

                }
                count = 1;

                if (item.stories != null)
                {
                    foreach (var stories in item.stories.items)
                    {
                        sb.AppendLine("\t\t\tStorie: " + count + " - " + stories.name);
                        count++;
                    }

                }
                count = 1;

                if (item.events != null)
                {
                    foreach (var events in item.events.items)
                    {
                        sb.AppendLine("\t\tComics: " + count + " - " + events.name);
                        count++;
                    }
                }
                count = 1;

            }
            return sb.ToString();
        }

        private ListaResultados GetRequest()
        {
            HttpResponseMessage lRespMsg;

            using (HttpClient lHttpCliente = new HttpClient())
            {
                lRespMsg = lHttpCliente.GetAsync(url).Result;
            }

            JsonRetorno = lRespMsg.Content.ReadAsStringAsync().Result;

            object objJson = JsonConvert.DeserializeObject<object>(JsonRetorno);

            dynamic jsonParse = JObject.Parse(JsonRetorno);

            ListaResultados result = JsonConvert.DeserializeObject<ListaResultados>(Convert.ToString(jsonParse.data));

            return result;
        }
    }
}