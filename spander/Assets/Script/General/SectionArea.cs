using UnityEngine;
using System.Collections;

public class SectionArea : MonoBehaviour
{

    private Rect SectionRect;
    private CameraController cameraController;

    /// <summary>
    /// セクション範囲を設定する
    /// </summary>
    /// <param name="rect"></param>
    public void setSectionRect(Rect rect)
    {
        this.SectionRect = rect;
        cameraController = GameObject.FindGameObjectWithTag("CameraController").GetComponent<CameraController>();
    }

    void OnTriggerEnter(Collider c)
    {
        if ((c.gameObject.tag) == "Player")
        {
            cameraController.setSectionRect(SectionRect);
        }
    }
}