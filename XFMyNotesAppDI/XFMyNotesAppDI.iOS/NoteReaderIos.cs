using System;
using System.Collections.Generic;
using System.Text;
using AVFoundation;

namespace XFMyNotesAppDI.iOS
{
    public class NoteReaderIos : INoteReader
    {
        public void Speak(string text)
        {
            var speechSynthesizer = new AVSpeechSynthesizer();
            speechSynthesizer.SpeakUtterance(new AVSpeechUtterance(text)
            {
                Rate = AVSpeechUtterance.DefaultSpeechRate,
                Voice = AVSpeechSynthesisVoice.FromLanguage("en-US"),
                Volume = .5f,
                PitchMultiplier = 1.0f
            });
        }
    }
}
