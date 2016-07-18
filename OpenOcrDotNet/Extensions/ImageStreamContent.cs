using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace OpenOcrDotNet.Extensions {
    /// <summary>Provides HTTP content based on a image stream.</summary>
    public class ImageStreamContent : StreamContent {
        public ImageStreamContent(Stream content) : base(content) {
            //todo dynamic detect - at them moment the engine is searching against image/* content-type
            Headers.ContentType = new MediaTypeHeaderValue("image/png");
        }

        public ImageStreamContent(Stream content, int bufferSize) : base(content, bufferSize) {
            //todo dynamic detect - at them moment the engine is searching against image/* content-type
            Headers.ContentType = new MediaTypeHeaderValue("image/png");
        }
    }
}