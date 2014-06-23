using System;
using Android.Speech.Tts;
using System.Collections.Generic;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency (typeof(Things.Android.TextToSpeech_Android))]
namespace Things.Android
{
	public class TextToSpeech_Android : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
	{
		TextToSpeech speaker;
		string toSpeak;

		public TextToSpeech_Android ()
		{
		}

		public void Speak (string text)
		{
			var ctx = Forms.Context; // useful for many Android SDK features
			toSpeak = text;
			if (speaker == null) {
				speaker = new TextToSpeech (ctx, this);
			} else {
				var p = new Dictionary<string,string> ();
				speaker.Speak (toSpeak, QueueMode.Flush, p);
			}
		}

		#region IOnInitListener implementation

		public void OnInit (OperationResult status)
		{
			if (status.Equals (OperationResult.Success)) {
				var p = new Dictionary<string,string> ();
				speaker.Speak (toSpeak, QueueMode.Flush, p);
			} 
		}

		#endregion
	}
}

