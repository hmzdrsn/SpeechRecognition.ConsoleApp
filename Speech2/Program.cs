using System.Globalization;
using System.Speech.Recognition;
using System.Speech.Synthesis;

if (!OperatingSystem.IsWindows()) return;


CultureInfo culture = new("en-US");
SpeechRecognitionEngine recognizer = new(culture);

SpeechSynthesizer speechSynthesizer = new();
