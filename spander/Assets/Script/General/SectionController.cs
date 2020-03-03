using UnityEngine;
using System.Collections;

public class SectionController : MonoBehaviour
{

    // セクションのカメラ範囲制御
    public Transform SectionArea;
    public float rect_width, rect_height, collider_depth;

    public Rect SectionRect;

    public GameObject camera;

    // マネージャ

    void Start()
    {
        // マネージャ取得

        // セクション範囲定義
        SectionRect = new Rect(SectionArea.position.x, SectionArea.position.y, rect_width, rect_height);
        camera.GetComponent<CameraController>().SectionRect = SectionRect;

        // セクション判定用オブジェクトに範囲を設定
      //  SectionArea.GetComponent<SectionArea>().setSectionRect(SectionRect);

        // CameraControllerにセクション範囲を渡すための判定定義
        SectionArea.transform.position = new Vector3(SectionRect.center.x, SectionRect.center.y, transform.position.z);
        BoxCollider boxCollider = SectionArea.GetComponent<BoxCollider>();
        boxCollider.size = new Vector3(SectionRect.width, SectionRect.height, collider_depth);

       
    }

    void OnDrawGizmos()
    {
        // セクション範囲を描画
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