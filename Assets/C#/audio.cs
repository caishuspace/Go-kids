using UnityEngine;
using System.Collections;
using Vuforia;
using System;

public class audio : MonoBehaviour, IVirtualButtonEventHandler
{
    public AudioSource a1, a2, a3, a4, a5, a6, a7;


    void Start()
    {
        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();

        for (int i = 0; i < vbs.Length; i++)
        {
            //在虚拟按钮中注册TrackableBehaviour事件
            vbs[i].RegisterEventHandler(this);
        }


    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        switch (vb.VirtualButtonName)
        {
            case "btn1":
                a2.Stop();
                a3.Stop();
                a4.Stop();
                a5.Stop();
                a6.Stop();
                a7.Stop();
            
                a1.Play();
                break;
            case "btn2":
                a1.Stop();
                a3.Stop();
                a4.Stop();
                a5.Stop();
                a6.Stop();
                a7.Stop();

                a2.Play();
                break;
            case "btn3":
                a2.Stop();
                a1.Stop();
                a4.Stop();
                a5.Stop();
                a6.Stop();
                a7.Stop();

                a3.Play();
                break;
            case "btn4":
                a2.Stop();
                a3.Stop();
                a1.Stop();
                a5.Stop();
                a6.Stop();
                a7.Stop();

                a4.Play();
                break;
            case "btn5":
                a2.Stop();
                a3.Stop();
                a4.Stop();
                a1.Stop();
                a6.Stop();
                a7.Stop();

                a5.Play();
                break;
            case "btn6":
                a2.Stop();
                a3.Stop();
                a4.Stop();
                a5.Stop();
                a1.Stop();
                a7.Stop();

                a6.Play();
                break;
            case "btn7":
                a2.Stop();
                a3.Stop();
                a4.Stop();
                a5.Stop();
                a6.Stop();
                a1.Stop();

                a7.Play();
                break;

            default:
                break;
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        switch (vb.VirtualButtonName)
        {
            case "btn1":
                a1.Stop();
                break;
            case "btn2":
                a2.Stop();
                break;
            case "btn3":
                a3.Stop();
                break;
            case "btn4":
                a4.Stop();
                break;
            case "btn5":
                a5.Stop();
                break;
            case "btn6":
                a6.Stop();
                break;
            case "btn7":
                a7.Stop();
                break;

            default:
                break;
        }
    }
}

