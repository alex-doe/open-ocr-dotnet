using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace OpenOcrDotNet.Extensions {
    /// <summary>Provides HTTP content based on a json string.</summary>
    public class JsonContent : ByteArrayContent {
        /// <summary>Creates a new instance of the <see cref="T:System.Net.Http.StringContent" /> class.</summary>
        /// <param name="content">The content used to initialize the <see cref="T:System.Net.Http.StringContent" />.</param>
        public JsonContent(string content)
            : this(content, null) {
        }

        /// <summary>Creates a new instance of the <see cref="T:System.Net.Http.StringContent" /> class.</summary>
        /// <param name="content">The content used to initialize the <see cref="T:System.Net.Http.StringContent" />.</param>
        /// <param name="mediaType">The media type to use for the content.</param>
        public JsonContent(string content, string mediaType)
            : base(GetContentByteArray(content)) {
            Headers.ContentType = new MediaTypeHeaderValue(mediaType ?? "application/json");
        }

        private static byte[] GetContentByteArray(string content) {
            if (content == null)
                throw new ArgumentNullException(nameof(content));
            var encoding = Encoding.UTF8;
            return encoding.GetBytes(content);
        }
    }
}