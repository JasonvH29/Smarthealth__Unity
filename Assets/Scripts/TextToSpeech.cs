using UnityEngine;
using System.Diagnostics;
using System.IO;

public class TextToSpeech : MonoBehaviour
{
    public static void Speak(string text)
    {
        string command = $"espeak \"{text}\"";
        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = $"/c {command}",
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        Process process = new Process { StartInfo = psi };
        process.Start();
    }
}
