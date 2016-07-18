namespace OpenOcrDotNet.Model {
    public class EngineOptions {
        public string Engine { get; set; }

        public EngineOptions() {
            Engine = OcrEngine.Tesseract;
        }
    }
}