using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance; // 他のクラスからMapManager.Instanceでアクセスできるように

    public Grid grid; // GridオブジェクトをInspectorでアタッチ

    private void Awake() // Startより先に呼ばれるメソッド
    {
        if (Instance == null) Instance = this; // Instanceに自信を代入、MpaManagerをどこからでも使える共通オブジェクトにするための処理
    }

    public Vector3 GridToWorld(Vector2Int gridPos) // グリッド座標を受け取り、ワールド座標を返す関数
    {
        Vector3Int cellPos = new Vector3Int(gridPos.x, gridPos.y, 0); // グリッド操作はVector3Intをよく使うため変換
        return grid.GetCellCenterWorld(cellPos); // キャラ、カーソルをタイルの中央に配置
    }
}
