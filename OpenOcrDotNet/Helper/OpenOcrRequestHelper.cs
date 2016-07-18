using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenOcrDotNet.Base;
using OpenOcrDotNet.Interfaces;
using OpenOcrDotNet.Model;

namespace OpenOcrDotNet.Helper {
    public class OpenOcrRequestHelper : RequestHelperBase, IRequestHelper {
        private readonly string _ocrHost;
        private readonly string _ocrPort;
        private readonly OpenOcrOptions _options;
        private const string DEFAULT_PORT = "9292";

        /// <summary>
        /// Create new request helper with default port 9292 and language en
        /// </summary>
        /// <param name="ocrHost">url to host. http://xxx</param>
        public OpenOcrRequestHelper(string ocrHost) : this(ocrHost, DEFAULT_PORT) {
        }

        /// <summary>
        /// Create new request helper.
        /// </summary>
        /// <param name="ocrHost">url to open-ocr host. http://xxx</param>
        /// <param name="ocrPort">port of open-ocr service.</param>
        public OpenOcrRequestHelper(string ocrHost, string ocrPort) : this(ocrHost, ocrPort, new OpenOcrOptions()) {
        }

        /// <summary>
        /// Create new request helper.
        /// </summary>
        /// <param name="ocrHost">url to open-ocr host. http://xxx</param>
        /// <param name="ocrPort">port of open-ocr service.</param>
        /// <param name="options">pass custom open-ocr options</param>
        public OpenOcrRequestHelper(string ocrHost, string ocrPort, OpenOcrOptions options) {
            _ocrHost = ocrHost;
            _ocrPort = string.IsNullOrEmpty(ocrPort) ? DEFAULT_PORT : ocrPort;
            _options = options;
        }

        public override string GetActionUrl() {
            return $"{_ocrHost}:{_ocrPort}/ocr";
        }

        /// <summary>
        /// Gets the json for an http reqest.
        /// </summary>
        /// <param name="imagetodetect">if provided the image from url get processed </param>
        /// <returns></returns>
        public string GetConfigJson(string imagetodetect) {
            List<string> jsonEntries = new List<string>();

            //image url if exists
            if (!string.IsNullOrWhiteSpace(imagetodetect) && !string.IsNullOrEmpty(imagetodetect)) {
                jsonEntries.Add($"\"img_url\":\"{imagetodetect}\"");
            }

            //engine
            jsonEntries.Add($"\"engine\":\"{_options.EngineOptions.Engine}\"");

            //engine args
            jsonEntries.Add("\"engine_args\":{\"lang\":\"" + _options.Language + "\"}");

            //preprocessors
            if (_options.Preprocessors != null) {
                jsonEntries.Add(GetPreprocessorsJson());
            }

            //build json string
            StringBuilder sb = new StringBuilder("{");
            for (int i = 0; i < jsonEntries.Count; i++) {
                sb.Append(jsonEntries[i]);
                if (i + 1 != jsonEntries.Count)
                {
                    sb.Append(",");
                }
            }
            sb.Append("}");
            var result = sb.ToString();
            return result;
        }

        private string GetPreprocessorsJson() {
            var processors = _options.Preprocessors.Select(e => "\"" + e + "\"").ToArray();
            var sb = new StringBuilder("\"preprocessors\":[");
            for (int i = 0; i < processors.Count(); i++) {
                sb.Append(processors[i]);
                if (i+1 != processors.Length) {
                    sb.Append(",");
                }
            }
            sb.Append("]");
            var result = sb.ToString();
            return result;
        }

        public string GetActionFileUrl() {
            return $"{_ocrHost}:{_ocrPort}/ocr-file-upload";
        }
    }
}