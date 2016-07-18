namespace OpenOcrDotNet.Base {
    public abstract class RequestHelperBase {
        public abstract string GetActionUrl();

        public virtual string GetConfigJson() {
            return "";
        }
    }
}