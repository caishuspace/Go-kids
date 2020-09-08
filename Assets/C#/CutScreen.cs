using UnityEngine;
using System.Collections;
using System;
using System.IO;


public class CutScreen : MonoBehaviour
{
    public void Click()
    {
        //获取系统时间并命名相片名
        System.DateTime now = System.DateTime.Now;
        string times = now.ToString();
        times = times.Trim();
        times = times.Replace("/", "-");
        string filename = "Screenshot" + times + ".png";
        //判断是否为Android平台
        if (Application.platform == RuntimePlatform.Android)
        {

            //截取屏幕
            Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
            texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            texture.Apply();
            //转为字节数组
            byte[] bytes = texture.EncodeToPNG();

            string destination = "/sdcard/DCIM/Camera";
            //判断目录是否存在，不存在则会创建目录
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }
           String  Path_save = destination + "/" + filename;
            //存图片
            System.IO.File.WriteAllBytes(Path_save, bytes);
            ScanFile(Path_save);
        }
        Debug.Log( "Button Clicked. TestClick.++");

    }

    //1刷新相册
    void ScanFile(string path)
    {
        using (AndroidJavaClass PlayerActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            AndroidJavaObject playerActivity = PlayerActivity.GetStatic<AndroidJavaObject>("currentActivity");
            using (AndroidJavaObject Conn = new AndroidJavaObject("android.media.MediaScannerConnection", playerActivity, null))
            {
                Conn.CallStatic("scanFile", playerActivity, path, null, null);
            }
        }
    }


}
