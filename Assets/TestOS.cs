using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class TestOS : Selectable {
    public Dropdown drpD;
    public Font customFont0;
    public Font customFont1;
    public Font customFont2;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public override void OnSelect(BaseEventData eventData)
    {
     //   int temp;
        base.OnSelect(eventData);
        Debug.LogFormat("select: Index=={0}", drpD.value);
        if (drpD.value == 0)
        {
            GameObject.Find("Canvas/P1/ScreenTxt").GetComponent<UnityEngine.UI.Text>().font = customFont0;
        }
        if (drpD.value == 1)
        {
            GameObject.Find("Canvas/P1/ScreenTxt").GetComponent<UnityEngine.UI.Text>().font = customFont1;
        }
        if (drpD.value == 2)
        {
            GameObject.Find("Canvas/P1/ScreenTxt").GetComponent<UnityEngine.UI.Text>().font = customFont2;
        }
    }
}
