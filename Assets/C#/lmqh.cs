using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lmqh : MonoBehaviour
{
    public GameObject ParP;
    public GameObject ChP;


    // Use this for initialization
    void Start ()
    {
        ParP.SetActive(true);
        ChP.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void chag()
    {
        ParP.SetActive(false);
        ChP.SetActive(true);
    }
}
