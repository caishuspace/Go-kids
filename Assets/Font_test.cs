using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Font_test : MonoBehaviour {

    public Font customFont;
	public void Click () {
        GameObject.Find("Canvas/Ret/ScreenTxt").GetComponent<UnityEngine.UI.Text>().font = customFont;
	}
}
