using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using OpenOcrDotNet.Extensions;
using OpenOcrDotNet.Interfaces;

namespace OpenOcrDotNet.Services {
    public class RestService : IRestService {
        public async Task<string> PostToApiWithJson(string url, string body) {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "POST";

            using (var streamWriter = new StreamWriter(await request.GetRequestStreamAsync())) {
                await streamWriter.WriteAsync(body);
                streamWriter.Flush();
            }
            string resultString;
            using (var response = (HttpWebResponse) await request.GetResponseAsync()) {
                using (var responseStream = response.GetResponseStream()) {
                    if (responseStream == null) {
                        throw new InvalidOperationException("Response Stream is empty or null");
                    }
                    using (var streamReader = new StreamReader(responseStream)) {
                        resultString = streamReader.ReadToEnd();
                    }
                }
            }
            return resultString;
        }
        public async Task<string> PostToApiBytes(string url,string settings, byte[] fileBytes)
        {
            string formDataBoundary = $"----------{Guid.NewGuid()}";
            string resultString;

            using (var client = new HttpClient()) {
                using (var content = new MultipartRelatedContent(formDataBoundary)) {
                    content.Add(new JsonContent(settings, "application/json"));
                    content.Add(new ImageStreamContent(new MemoryStream(fileBytes)), "imagefile", "image/png");
                    using (var message = await client.PostAsync(url,content)) {
                        resultString = await message.Content.ReadAsStringAsync();
                    }
                }
            }

            return resultString;
        }
    }
}