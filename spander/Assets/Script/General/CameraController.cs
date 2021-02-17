using UnityEngine;
using System.Collections;

/// <summary>
/// ゲーム画面上のメインカメラの制御を行うクラス
/// </summary>

public class CameraController : MonoBehaviour
{

    // カメラの幅と高さ
    private float cameraRangeWidth, cameraRangeHeight;

    // 各オブジェクト
    private GameObject mainCamera;
    private GameObject player;

    // セクション範囲定義用
    public Rect section;
    private Vector3 top_left, bottom_left, top_right, bottom_right;
    Vector3 newPosition;

    void Start()
    {
        // パラメータに値を設定
        player = GameObject.FindGameObjectWithTag("Player");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        // プレイヤーキャラの位置に追従させる
        transform.position = player.transform.position;

        newPosition = mainCamera.transform.position;

        // カメラ描画範囲の上下左右を取得
        float distance = Vector3.Distance(mainCamera.transform.position, player.transform.position);
        bottom_left = mainCamera.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0, 0, distance));
        top_right = mainCamera.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(1, 1, distance));
        top_left = new Vector3(bottom_left.x, top_right.y, bottom_left.z);
        bottom_right = new Vector3(top_right.x, bottom_left.y, top_right.z);

        cameraRangeWidth = Vector3.Distance(bottom_left, bottom_right);
        cameraRangeHeight = Vector3.Distance(bottom_left, top_left);

        // カメラ位置をセクション範囲内に収める
        float newX = Mathf.Clamp(newPosition.x, section.xMin +cameraRangeWidth / 2, section.xMax-cameraRangeWidth / 2);
        float newY = Mathf.Clamp(newPosition.y, section.yMin+cameraRangeHeight / 2, section.yMax -cameraRangeHeight / 2);

        transform.position = new Vector3(newX, newY, newPosition.z);
    }

    //ゲーム実行中にカメラ描画範囲を表示する(カメラ範囲確認用)
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(bottom_left, top_left);
        Gizmos.DrawLine(top_left, top_right);
        Gizmos.DrawLine(top_right, bottom_right);
        Gizmos.DrawLine(bottom_right, bottom_left);
    }
    public void setSectionRect(Rect Section)
    {
        section = Section;
    }

}
