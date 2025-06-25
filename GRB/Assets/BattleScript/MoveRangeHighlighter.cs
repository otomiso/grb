using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class MoveRangeHighlighter : MonoBehaviour
{
    public Tilemap mapTilemap;         // 実際のマップに使っているTilemap
    public Tilemap highlightTilemap;   // ハイライト表示用のTilemap
    public Tile highlightTile;         // ハイライトに使うTile（半透明の青タイルなど）
    public Grid grid; // グリッド

    // 移動コストを設定したTileに使うカスタムTile（ScriptableObjectで定義）
    public CostTile defaultCostTile; // コストが未設定のタイル用（通常は1）
    private HashSet<Vector3Int> validCells = new HashSet<Vector3Int>(); // 移動可能なマスを記録するための型と変数

    public void ShowMoveRange(Vector3 centerWorldPos, int moveRange) // タイルをハイライトするための関数、キャラクターの現在位置と移動コスト
    {
        ClearHighlights(); // ハイライトリセット
        validCells.Clear(); // ハイライトセルの記憶の変数もリセット

        Vector3Int startCell = grid.WorldToCell(centerWorldPos); // キャラクターの現在位置の入った変数をワールド座標からグリッド座標に変換

        Queue<Node> queue = new Queue<Node>(); // BFSで近いタイルから順に探索
        Dictionary<Vector3Int, int> visited = new Dictionary<Vector3Int, int>();

        queue.Enqueue(new Node(startCell, 0)); // 探索開始地点をキューに追加、初期コストは0
        visited[startCell] = 0;

        while (queue.Count > 0) // BFSのメインループ、キューが空になるまでループ
        {
            Node current = queue.Dequeue(); // キューから次の探索対象を(座標と累積コスト)を取り出す

            if (current.cost > moveRange) continue; // 現在のタイルと累積コストが移動力を超えたらスキップ

            highlightTilemap.SetTile(current.pos, highlightTile); // ハイライトタイルを描画し、そのマスを移動可能リストに追加

            validCells.Add(current.pos); // 移動可能か判定するため、ハイライトセルを記憶

            foreach (var dir in directions) // 上下左右の4方向に隣接するマスを走査
            {
                Vector3Int next = current.pos + dir;

                if (!mapTilemap.HasTile(next)) continue; // タイルが存在しない(マップ外等)場合はスキップ

                CostTile costTile = mapTilemap.GetTile<CostTile>(next); // CostTile型としてタイルを取得できた場合はコストを使って計算、なければデフォルトのコストを使用
                int moveCost = (costTile != null) ? costTile.moveCost : defaultCostTile.moveCost;

                int nextCost = current.cost + moveCost; // 現在位置までのコストに加え、次のマスのコストを加算して累積コストとする

                if (nextCost <= moveRange && (!visited.ContainsKey(next) || visited[next] > nextCost)) // まだ訪れていないマス、またはより安くたどり着けるマスのみ次の探索候補として登録
                {
                    visited[next] = nextCost;
                    queue.Enqueue(new Node(next, nextCost));
                }
            }
        }
    }
    public bool IsCellInRange(Vector3Int cellPos) // CharacterMoverで呼び出し、移動先のマスがハイライトされているか確認するために使用
    {
        return validCells.Contains(cellPos);
    }

    public void ClearHighlights()
    {
        highlightTilemap.ClearAllTiles();
    }

    private struct Node // Queue<Node>に入れて探索用に使用
    {
        public Vector3Int pos; // マスの座標
        public int cost; // ここまでの累積コスト

        public Node(Vector3Int pos, int cost)
        {
            this.pos = pos;
            this.cost = cost;
        }
    }

    private static readonly Vector3Int[] directions = // 上下左右に探索するための方向ベクトル
    {
        new Vector3Int(1, 0, 0),
        new Vector3Int(-1, 0, 0),
        new Vector3Int(0, 1, 0),
        new Vector3Int(0, -1, 0)
    };
}
