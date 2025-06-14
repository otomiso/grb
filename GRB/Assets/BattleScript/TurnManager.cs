using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public GameObject cursor; // カーソルのゲームオブジェクト
    public Vector2Int startPosition = new Vector2Int(0, 0);

    void Start()
    {
        StartPlayerTurn();
        // 他勢力のターン開始は例として 5 秒後に呼びます
        // Invoke("EndPlayerTurn", 5f);
    }

    public void StartPlayerTurn()
    {
        // カーソル表示を有効にする
        cursor.SetActive(true);

        // 初期位置に移動
        Vector3 worldPos = MapManager.Instance.GridToWorld(startPosition);
        cursor.transform.position = worldPos;

        // カーソル操作も有効に
        cursor.GetComponent<CursorController>().SetControlEnabled(true);
    }

    public void EndPlayerTurn()
    {
        // カーソル非表示＆操作無効
        cursor.SetActive(false);
        cursor.GetComponent<CursorController>().SetControlEnabled(false);
    }
}
