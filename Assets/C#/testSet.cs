using UnityEngine;
using UnityEngine.UI;//犹如我们要获取一个text并操作，所以需要这个头文件
using System.Collections;
using System.Collections.Generic;

public class testSet : MonoBehaviour {

    public GameObject Panel;
    public void hidePanel()
    {
        Panel.gameObject.SetActive(false);
    }

}
