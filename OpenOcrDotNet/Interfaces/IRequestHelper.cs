namespace OpenOcrDotNet.Interfaces {
    public interface IRequestHelper {
        string GetActionUrl();
        string GetConfigJson(string inputData);
        string GetActionFileUrl();
    }
}