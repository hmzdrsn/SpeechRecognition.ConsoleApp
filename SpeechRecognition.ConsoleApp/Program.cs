using System.Diagnostics;
using System.Globalization;
using System.Speech.Recognition;
using System.Speech.Synthesis;

if (!OperatingSystem.IsWindows()) return;


CultureInfo culture = new ("en-US");
SpeechRecognitionEngine recognizer = new(culture);

SpeechSynthesizer speechSynthesizer = new();


Choices commands = new();
commands.Add("jarvis");
commands.Add("open powershell");
commands.Add("open visual code");
commands.Add("hello");

GrammarBuilder builder = new(commands);
builder.Culture = culture;

Grammar grammar = new(builder);
recognizer.LoadGrammar(grammar);

recognizer.SpeechRecognized += Recognizer_SpeechRecognized;
recognizer.SpeechRecognitionRejected += Recognizer_SpeechRejected;

void Recognizer_SpeechRejected(object? sender, SpeechRecognitionRejectedEventArgs e)
{
    Console.WriteLine("Command Not Recognized!");
}

recognizer.SetInputToDefaultAudioDevice();
recognizer.RecognizeAsync(RecognizeMode.Multiple);

Console.WriteLine("Waiting command...");

Console.ReadLine();
void Recognizer_SpeechRecognized(object? sender, SpeechRecognizedEventArgs e)
{
    string text = e.Result.Text;
    Console.WriteLine(text);

    if (text == "jarvis")
    {
        Console.WriteLine("How can I help you sir");
        speechSynthesizer.Speak("How can I help you sir");
    }
    else if (text == "open powershell")
    {
        speechSynthesizer.Speak("Okey im trying");
        openPowerShell();
    }
    else if (text == "open visual code")
    {
        speechSynthesizer.Speak("Okey im trying");
        OpenProject();
    }
}
void openPowerShell()
{
    var psi = new ProcessStartInfo
    {
        FileName = "powershell.exe",
        Arguments = $"-NoExit -Command \"cd C:/Users/Administrator/source/repos/B2B_Project.CLIENT; ng serve \"",
        UseShellExecute = true,
        CreateNoWindow = false,
    };
    Process.Start(psi);
}

void OpenProject()
{
    var psi = new ProcessStartInfo()
    {
        FileName = "powershell.exe",
        Arguments = "-NoExit -Command \"cd C:/Users/Administrator/source/repos/B2B_Project.CLIENT/; code.. \"",
        UseShellExecute = true,
        CreateNoWindow = false
    };
    Process.Start(psi);
}
