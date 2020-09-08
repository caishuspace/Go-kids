using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChanSc : MonoBehaviour
{
    public GameObject Parent;
    public GameObject piano;
    public GameObject pkq;
    public GameObject jqm;

    // Use this for initialization
    void Start () { 
        Parent.SetActive(true);
        piano.SetActive(false);
        pkq.SetActive(false);
        jqm.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

    }
    public void gq()
    {
        Parent.SetActive(false);
        piano.SetActive(true);
        pkq.SetActive(false);
        jqm.SetActive(false);
    }
    public void pq()
    {
        Parent.SetActive(false);
        piano.SetActive(false);
        pkq.SetActive(true);
        jqm.SetActive(false);
    }
    public void jm()
    {
        Parent.SetActive(false);
        piano.SetActive(false);
        pkq.SetActive(false);
        jqm.SetActive(true);
    }
}
