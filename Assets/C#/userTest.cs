
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System.Linq;

public class userTest : MonoBehaviour, IUserDefinedTargetEventHandler
{
    UserDefinedTargetBuildingBehaviour m_UserDefinedTarget;
    ObjectTracker m_ObjectTracker;
    DataSet m_DataSet;
    ImageTargetBuilder.FrameQuality m_FrameQuality;
    int m_TargetCount;
    public ImageTargetBehaviour m_ImageTarget;
    void Start()
    {
        m_UserDefinedTarget = this.GetComponent<UserDefinedTargetBuildingBehaviour>();//获取挂载这个脚本的物体上的UserDefinedTargetBuildingBehaviour脚本
        m_FrameQuality = ImageTargetBuilder.FrameQuality.FRAME_QUALITY_NONE;
        if (m_UserDefinedTarget != null)
        {
            m_UserDefinedTarget.RegisterEventHandler(this);
        }
    }
    public void OnFrameQualityChanged(ImageTargetBuilder.FrameQuality frameQuality)
    {
        m_FrameQuality = frameQuality;

        if (m_FrameQuality == ImageTargetBuilder.FrameQuality.FRAME_QUALITY_LOW)
        {

            Debug.Log("Low camera image quality");
        }
    }
    public void OnInitialized()
    {
        m_ObjectTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
        if (m_ObjectTracker != null)
        {
            m_DataSet = m_ObjectTracker.CreateDataSet();//如果m_ObjectTracker不为空的话，m_DataSet等于我新创建的数据集
            m_ObjectTracker.ActivateDataSet(m_DataSet);    //激活数据集  
        }
    }
    public void OnNewTrackableSource(TrackableSource trackableSource)
    {

        m_TargetCount++;//每新增一次识别图，m_TargetCount自增一次

        m_ObjectTracker.DeactivateDataSet(m_DataSet);//关闭数据集
                                                     //当数据饱和或者大于设定数字5的时候，删除最初保存的那个数据，以此类推

        if (m_DataSet.HasReachedTrackableLimit() || m_DataSet.GetTrackables().Count() >= 5)
        {
            IEnumerable<Trackable> trackables = m_DataSet.GetTrackables();

            Trackable oldest = null;

            foreach (Trackable trackable in trackables)
            {
                if (oldest == null || trackable.ID < oldest.ID)

                    oldest = trackable;
            }
            if (oldest != null)
            {
                Debug.Log("Destroying oldest trackable in UDT dataset: " + oldest.Name);

                m_DataSet.Destroy(oldest, true);
            }
        }
        //创建一个新的ImageTarget，并为其命名
        ImageTargetBehaviour ImageTBCopy = (ImageTargetBehaviour)Instantiate(m_ImageTarget);

        ImageTBCopy.gameObject.name = "CustomImageTarget-" + m_TargetCount;
        //将创建过的ImageTarget添加到数据集中
        m_DataSet.CreateTrackable(trackableSource, ImageTBCopy.gameObject);
        //激活数据集
        m_ObjectTracker.ActivateDataSet(m_DataSet);
    }
    public void BuildNewImageTarget()
    {
        //创建新识别图，括号中前一个变量是名字，后一个变量是识别图的Size；
        m_UserDefinedTarget.BuildNewTarget("CustomImageTarget" + m_TargetCount, 1);
    }
}