# open-ocr-dotnet 
[![Build status](https://ci.appveyor.com/api/projects/status/5838h4n16b5onco3?svg=true)](https://ci.appveyor.com/project/alex-doe/open-ocr-dotnet)

A small lightweight C# client library for the amazing [open-ocr](https://github.com/tleyden/open-ocr) project.
## Prerequisites
All you need is a running instance of [open-ocr](https://github.com/tleyden/open-ocr).
## Install in your project
Install the nugetpackage:
```
Install-Package open-ocr-dotnet -Pre
```
## Usage
### Basic example

#### Get an Instance of the open ocr client service
In minimal config you only need to provide the host url.
The default port (9292) will be used.
Default language is eng.

```csharp
var service = new OpenOcrService(ocrhosturl);
var service = new OpenOcrService(ocrhosturl,ocrport);
var service = new OpenOcrService(ocrhosturl,ocrport,options);
```
#### Customize settings (optional)
```csharp
string imagetodetect = @"http://bit.ly/ocrimage";
string ocrhosturl = @"http://PLACE_HOST_IP_HERE";
string ocrport = "HOSTPORT";
OpenOcrOptions options = new OpenOcrOptions {
    Language = EngineLanguage.eng,
    EngineOptions = new EngineOptions {
        Engine = OcrEngine.Tesseract
}
```
#### Analyze image from Url
```csharp
OpenOcrService service = new OpenOcrService(ocrhosturl, ocrport, options);
string resultFromUrl = await service.ProgressImageFromUrl(imagetodetect);
```
#### Analyze image from Filesystem
```csharp
byte[] fileBytes = File.ReadAllBytes(@"PATHTOIMAGE\ocr_test.png");
string resultlocalFile = await service.ProgressImage(fileBytes);
```

### Advanced stuff
#### Use a preprocessor
> It is important that you first enable the preprocessor in your open-ocr instance
> https://github.com/tleyden/open-ocr/wiki/Stroke-Width-Transform#start-an-additional-worker

```csharp
OpenOcrOptions optionsSample = new OpenOcrOptions {
    Language = EngineLanguage.eng,
    EngineOptions = new EngineOptions {
        Engine = OcrEngine.Tesseract
    },
    Preprocessors = new[] {
        Preprocessor.StrokeWidthTransform,
        "super-fancy-new-preprocessor"
    }
};
```

## Todo's
- [ ] provide sample console app
- [x] samples in README
- [ ] add credits
- [ ] json.net optional integration
- [ ] impove ci build
- [ ] implement todo's in code
