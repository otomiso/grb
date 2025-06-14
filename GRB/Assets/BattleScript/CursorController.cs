using UnityEngine;

public class CursorController : MonoBehaviour
{
    public bool controlEnabled = false; // カーソル制御 true:プレイヤーターン false:エネミーターン
    public Grid grid; // UnityのGridをInspectorでセット

    void Update()
    {
        if (!controlEnabled) return; // カーソル操作が有効時

        // マウス位置をワールド座標に変換
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;

        // ワールド座標 → グリッド座標
        Vector3Int cellPosition = grid.WorldToCell(mouseWorldPos);

        // グリッドの中心にカーソルを移動
        transform.position = grid.GetCellCenterWorld(cellPosition);
    }

    public void SetControlEnabled(bool enabled) // カーソル操作のON/OFFを切り替えるメソッド
    {
        controlEnabled = enabled; // 他のスクリプトからCursorController.SetControlEnabled(true);等で呼び出せるように
    }
}
