using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{
    public AudioClip[] aclips;
    public AudioSource myAudioSourse;
    string btname;

    void Start()
    {
        myAudioSourse = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                btname = hit.transform.name;
                switch (btname)
                {
                    case "b1":
                        myAudioSourse.clip = aclips[0];
                        myAudioSourse.Play();
                        break;
                    case "b2":
                        myAudioSourse.clip = aclips[1];
                        myAudioSourse.Play();
                        break;
                        break;
                    case "b3":
                        myAudioSourse.clip = aclips[2];
                        myAudioSourse.Play();
                        break;
                    case "b4":
                        myAudioSourse.clip = aclips[3];
                        myAudioSourse.Play();
                        break;
                    case "b5":
                        myAudioSourse.clip = aclips[4];
                        myAudioSourse.Play();
                        break;
                    case "b6":
                        myAudioSourse.clip = aclips[5];
                        myAudioSourse.Play();
                        break;
                    case "b7":
                        myAudioSourse.clip = aclips[6];
                        myAudioSourse.Play();
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
