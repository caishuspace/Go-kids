using UnityEngine;
using System.Collections;

public class span : MonoBehaviour
{
    void OnMouseDrag()
    {
        this.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0) * 6f, Space.World);
    }

}