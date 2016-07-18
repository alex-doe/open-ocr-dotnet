namespace OpenOcrDotNet.Model {
    public enum EngineLanguage {
        //container preinstalled versions. Copied from https://github.com/tleyden/docker/blob/master/open-ocr/Dockerfile
        eng,
        ara,
        bel,
        ben,
        bul,
        ces,
        dan,
        deu,
        ell,
        fin,
        fra,
        heb,
        hin,
        ind,
        isl,
        ita,
        jpn,
        kor,
        nld,
        nor,
        pol,
        por,
        ron,
        rus,
        spa,
        swe,
        tha,
        tur,
        ukr,
        vie,
        chi_sim,
        chi_tra
    }

    public class OcrEngine {
        public static string Tesseract = "tesseract";
    }

    public class Preprocessor {
        public static string StrokeWidthTransform => "stroke-width-transform";
    }

}