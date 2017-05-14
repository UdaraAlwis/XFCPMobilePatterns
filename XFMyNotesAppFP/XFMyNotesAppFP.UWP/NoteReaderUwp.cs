using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml.Controls;

namespace XFMyNotesAppFP.UWP
{
    public class NoteReaderUwp : INoteReader
    {
        public async void Speak(string text)
        {
            var mediaPronunciation = new MediaElement();
            try
            {
                using (var speech = new SpeechSynthesizer())
                {
                    speech.Voice = SpeechSynthesizer.DefaultVoice;
                    var voiceStream = await speech.SynthesizeTextToStreamAsync(text);
                    mediaPronunciation.SetSource(voiceStream, voiceStream.ContentType);
                    mediaPronunciation.Play();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}
