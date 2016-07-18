namespace OpenOcrDotNet.Model {
    public class OpenOcrOptions {
        public EngineLanguage Language { get; set; }

        public EngineOptions EngineOptions { get; set; }

        public string[] Preprocessors { get; set; }

        public OpenOcrOptions() {
            Language = EngineLanguage.eng;
            EngineOptions = new EngineOptions();
            Preprocessors = null;
        }
    }
}