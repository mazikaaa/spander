using UnityEngine;
using System.Collections;

public class SectionController : MonoBehaviour
{

    // マップのカメラ範囲制御
    public Transform sectionarea;
    public float rect_width, rect_height, collider_depth;

    public Rect SectionRect;

    public GameObject camera;

    // マネージャ

    void Start()
    {
        // マネージャ取得

        // マップの範囲定義
        SectionRect = new Rect(sectionarea.position.x, sectionarea.position.y, rect_width, rect_height);
        //カメラ側にマップの範囲を渡す
        camera.GetComponent<CameraController>().setSectionRect(SectionRect);

        
        // マップの範囲（マップの端）に当たり判定を展開する(マップの外に自機が出来ないようにする)
        sectionarea.transform.position = new Vector3(SectionRect.center.x, SectionRect.center.y, transform.position.z);
        BoxCollider boxCollider = sectionarea.GetComponent<BoxCollider>();
        boxCollider.size = new Vector3(SectionRect.width, SectionRect.height, collider_depth);
        

       
    }

    // マップ範囲を描画(マップ範囲の確認用)
    void OnDrawGizmos()
    {
       
        float base_depth = -10;

            Vector3 lower_left = new Vector3(SectionRect.xMin, SectionRect.yMax, base_depth);
            Vector3 upper_left = new Vector3(SectionRect.xMin, SectionRect.yMin, base_depth);
            Vector3 lower_right = new Vector3(SectionRect.xMax, SectionRect.yMax, base_depth);
            Vector3 upper_right = new Vector3(SectionRect.xMax, SectionRect.yMin, base_depth);

            Gizmos.color = Color.red;
            Gizmos.DrawLine(lower_left, upper_left);
            Gizmos.DrawLine(upper_left, upper_right);
            Gizmos.DrawLine(upper_right, lower_right);
            Gizmos.DrawLine(lower_right, lower_left);
        
    }
}