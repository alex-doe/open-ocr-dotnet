using System.Threading.Tasks;
using OpenOcrDotNet.Helper;
using OpenOcrDotNet.Interfaces;
using OpenOcrDotNet.Model;

namespace OpenOcrDotNet.Services {
    public class OpenOcrService {
        private readonly IRestService _restService;
        private readonly IRequestHelper _requestHelper;

        public OpenOcrService(string openOcrHostUrl) : this(new RestService(), new OpenOcrRequestHelper(openOcrHostUrl)) {
        }

        public OpenOcrService(string openOcrHostUrl, string openOcrPort)
            : this(new RestService(), new OpenOcrRequestHelper(openOcrHostUrl, openOcrPort, new OpenOcrOptions())) {
        }

        public OpenOcrService(string openOcrHostUrl, string openOcrPort, OpenOcrOptions options)
            : this(new RestService(), new OpenOcrRequestHelper(openOcrHostUrl, openOcrPort, options)) {
        }

        private OpenOcrService(IRestService restService, IRequestHelper requestHelper) {
            _restService = restService;
            _requestHelper = requestHelper;
        }

        //todo check service available

        public async Task<string> ProgressImageFromUrl(string imageUrl) {
            var body = _requestHelper.GetConfigJson(imageUrl);
            var result = await _restService.PostToApiWithJson(_requestHelper.GetActionUrl(), body);
            return result;
        }

        public async Task<string> ProgressImage(byte[] fileBytes) {
            var settings = _requestHelper.GetConfigJson(null);
            var result = await _restService.PostToApiBytes(_requestHelper.GetActionFileUrl(), settings, fileBytes);
            return result;
        }
    }
}