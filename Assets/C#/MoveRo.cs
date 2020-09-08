using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRo : MonoBehaviour
{

    public float rotationSpeed = 100; //设置旋转的速度
    public Transform PlayerTrans;    //设置空物体的位置
    public float maxh = 10;        //设置提升的最高高度

    enum RotationAxes { MouseXAndY, MouseX, MouseY }
    RotationAxes axes = RotationAxes.MouseXAndY;
    float sensitivityX = 15;
    float sensitivityY = 15;
    float minimumY = -80;
    float maximumY = 80;
    private float rotationY = 0;
    // Use this for initialization
    void Start()
    {

        PlayerTrans.position = PlayerTrans.position + new Vector3(0, maxh, 0);   //提升空物体的位置，后面做旋转范围
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {

            if (axes == RotationAxes.MouseXAndY)
            {

                float rotationX = transform.localEulerAngles.y - Input.GetAxis("Mouse X") * sensitivityX;
                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                 rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
                transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
            }
            else if (axes == RotationAxes.MouseX)
            {

                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityY, 0);
            }
            else
            {

                 rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                 rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
                transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
            }
        }

        //通过鼠标滚轮实现场景缩放
        //鼠标滚轮的效果
        //Camera.main.fieldOfView    摄像机的视野
        //Camera.main.orthographicSize   摄像机的正交投影

        //Zoom out
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {

            if (Camera.main.fieldOfView <= 100)
                Camera.main.fieldOfView += 2;
            if (Camera.main.orthographicSize <= 20)
                Camera.main.orthographicSize -= 0.5f;
        }

        //右键旋转
        if (Input.GetMouseButton(1))
        {

            float nor = Input.GetAxis("Mouse X");  //获取鼠标的偏移量
            PlayerTrans.RotateAround(PlayerTrans.position, Vector3.up, Time.deltaTime * rotationSpeed * nor);  //每帧旋转空物体，相机也跟随旋转
        }
    }
}
