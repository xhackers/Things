using MonoTouch.AVFoundation;

[assembly: Xamarin.Forms.Dependency (typeof(Things.iOS.TextToSpeech_iOS))]
namespace Things.iOS
{
	public class TextToSpeech_iOS : ITextToSpeech
	{
		public TextToSpeech_iOS () {}

		public void Speak (string text)
		{
			var speechSynthesizer = new AVSpeechSynthesizer ();

			var speechUtterance = new AVSpeechUtterance (text) {
				Rate = AVSpeechUtterance.MaximumSpeechRate/4,
				Voice = AVSpeechSynthesisVoice.FromLanguage ("en-US"),
				Volume = 0.5f,
				PitchMultiplier = 1.0f
			};

			speechSynthesizer.SpeakUtterance (speechUtterance);
		}
	}
}

