using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Text;

public class Test : MonoBehaviour {
	public InputField resInputField;

	void OutputMessage(string msg) {
		resInputField.text = msg;
	}

	// StreamingAssets からロード(NFC)
	public void LoadFromSaNfc() {
		var s = "nfc\u30ac.txt";
		LoadFromSA (s);
	}

	// StreamingAssets からロード(NFD)
	public void LoadFromSaNfd() {
		var s = "nfd\u30ab\u3099.txt";
		LoadFromSA (s);
	}

	void LoadFromSA(string fileName) {
		try {
			var filePath = Path.Combine(Application.streamingAssetsPath, fileName);
			using (StreamReader sr = new StreamReader (filePath)) {
				var msg = string.Format("Load complete. \n\nFileName:{0}\nData:{1}\n", fileName, sr.ReadToEnd());
				OutputMessage (msg);
			}
		} catch(Exception e) {
			OutputMessage ("Load file error : " + e.Message);
		}
	}

	// Resources からロード(NFC)
	public void LoadFromResourcesNfc() {
		var s = "nfc\u30ac";
		LoadFromResources (s);
	}

	// Resources からロード(NFD)
	public void LoadFromResourcesNfd() {
		var s = "nfd\u30ab\u3099";
		LoadFromResources (s);
	}

	void LoadFromResources(string fileName) {
		var textAsset = Resources.Load(fileName) as TextAsset;
		if (textAsset == null) {
			OutputMessage ("Load file error : " + fileName);
		} else {
			var msg = string.Format("Load complete. \n\nFileName:{0}\nData:{1}\n", fileName, textAsset.text);
			OutputMessage (msg);
		}
	}
}
