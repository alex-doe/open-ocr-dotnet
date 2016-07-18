using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace OpenOcrDotNet.Extensions {
    /// <summary>Provides a container for content encoded using multipart/related MIME type.</summary>
    internal class MultipartRelatedContent : MultipartContent {
        private const string SUBTYPE = "related";

        /// <summary>Creates a new instance of the <see cref="T:OpenOcrDotNet.Extensions.MultipartRelatedContent" /> class.</summary>
        public MultipartRelatedContent()
            : base(SUBTYPE) {
        }

        /// <summary>Creates a new instance of the <see cref="T:OpenOcrNetFullClient.Base.MultipartRelatedContent" /> class.</summary>
        /// <param name="boundary">The boundary string for the multipart related data content.</param>
        /// <exception cref="T:System.ArgumentException">The <paramref name="boundary" /> was null or contains only white space characters.-or-The <paramref name="boundary" /> ends with a space character.</exception>
        /// <exception cref="T:System.OutOfRangeException">The length of the <paramref name="boundary" /> was greater than 70.</exception>
        public MultipartRelatedContent(string boundary)
            : base(SUBTYPE, boundary) {
        }

        /// <summary>Add HTTP content to a collection of <see cref="T:OpenOcrDotNet.Extensions.MultipartRelatedContent" /> objects that get serialized to multipart/related MIME type.</summary>
        /// <param name="content">The HTTP content to add to the collection.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="content" /> was null.</exception>
        public override void Add(HttpContent content) {
            if (content == null)
                throw new ArgumentNullException(nameof(content));
            if (content.Headers.ContentDisposition == null)
                content.Headers.ContentDisposition = new ContentDispositionHeaderValue(SUBTYPE);
            base.Add(content);
        }

        /// <summary>Add HTTP content to a collection of <see cref="T:OpenOcrDotNet.Extensions.MultipartRelatedContent" /> objects that get serialized to multipart/related MIME type.</summary>
        /// <param name="content">The HTTP content to add to the collection.</param>
        /// <param name="name">The name for the HTTP content to add.</param>
        /// <exception cref="T:System.ArgumentException">The <paramref name="name" /> was null or contains only white space characters.</exception>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="content" /> was null.</exception>
        public void Add(HttpContent content, string name) {
            if (content == null)
                throw new ArgumentNullException(nameof(content));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The value cannot be null or empty.", nameof(name));
            AddInternal(content, name, null);
        }

        /// <summary>Add HTTP content to a collection of <see cref="T:OpenOcrDotNet.Extensions.MultipartRelatedContent" /> objects that get serialized to multipart/related MIME type.</summary>
        /// <param name="content">The HTTP content to add to the collection.</param>
        /// <param name="name">The name for the HTTP content to add.</param>
        /// <param name="fileName">The file name for the HTTP content to add to the collection.</param>
        /// <exception cref="T:System.ArgumentException">The <paramref name="name" /> was null or contains only white space characters.-or-The <paramref name="fileName" /> was null or contains only white space characters.</exception>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="content" /> was null.</exception>
        public void Add(HttpContent content, string name, string fileName) {
            if (content == null)
                throw new ArgumentNullException(nameof(content));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The value cannot be null or empty.", nameof(name));
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("The value cannot be null or empty.", nameof(fileName));
            AddInternal(content, name, fileName);
        }

        private void AddInternal(HttpContent content, string name, string fileName) {
            if (content.Headers.ContentDisposition == null)
                content.Headers.ContentDisposition = new ContentDispositionHeaderValue(SUBTYPE) {
                    Name = name,
                    FileName = fileName,
                    FileNameStar = fileName
                };
            base.Add(content);
        }
    }
}