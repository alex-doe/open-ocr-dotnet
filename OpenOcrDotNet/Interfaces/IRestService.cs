using System.Threading.Tasks;

namespace OpenOcrDotNet.Interfaces {
    public interface IRestService {
        Task<string> PostToApiWithJson(string url, string body);
        Task<string> PostToApiBytes(string url, string settings, byte[] fileBytes);
    }
}