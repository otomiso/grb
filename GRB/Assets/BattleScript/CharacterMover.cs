using UnityEditor;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    public Grid grid; // 自身のグリッド参照（必要に応じてCursorController経由でも可）

    private bool isMoving = false;
    private Vector3 targetPosition;
    public MoveRangeHighlighter rangeHighlighter;
    private bool isInMoveMode = false;
    private CharacterStats stats;
    private Vector3 previousPosition; // 移動後キャンセルボタンで元の位置に戻すために、移動前座標を入れておく変数 
    public bool hasActed = false; // 行動済みかどうか判断する変数
    void Start()
    {
        if (grid == null)
        {
            grid = FindFirstObjectByType<Grid>();
        }
        if (rangeHighlighter == null)
        {
            rangeHighlighter = FindFirstObjectByType<MoveRangeHighlighter>();
        }
        stats = GetComponent<CharacterStats>();
    }

    void Update()
    {
        if (isMoving) // isMovingがtrueになったとき
        {
            // 現在位置をMoveTowards関数で目標位置まで移動
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 5f * Time.deltaTime);
            // 目標位置に移動出来たら、MoveTowardでは正確に止まらない可能性があるため、位置を正確に補正
            if (Vector3.Distance(transform.position, targetPosition) < 0.05f) // 目標位置に近づいたとき
            {
                transform.position = targetPosition; // 目標位置を現在位置に
                isMoving = false; // isMovingをfalseに
                rangeHighlighter.ClearHighlights(); // 移動完了後にハイライトを消去
                CommandUI.Instance.Show(this, afterMove: true);
            }
        }
        else if (isInMoveMode && Input.GetMouseButtonDown(0)) // TryMoveTo関数をこっちに置き換え、isInMoveModeがtrueの条件追加
        {
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorld.z = 0;
            Vector3Int destGrid = grid.WorldToCell(mouseWorld);
            if (rangeHighlighter.IsCellInRange(destGrid)) // rangeHighlighterのIsCellRange(destGrid)を呼び出し、戻ってきた値がtrueの場合だけ中の処理を実行する、validCellsに値が入ってるかどうか
            {
                targetPosition = grid.GetCellCenterWorld(destGrid);
                isMoving = true;
                isInMoveMode = false;
                rangeHighlighter.ClearHighlights();
            }
            else
            {
                Debug.Log("移動範囲外");
            }
        }
    }
    public void Select() // CursorControllerで呼び出されたとき
    {
        if (hasActed) // hasActedがtrueのとき
        {
            Debug.Log($"{gameObject.name}はすでに行動済みです");
            return; // 処理を中断
        }
        Debug.Log($"{gameObject.name} を選択しました");
        CommandUI.Instance.Show(this);
        // if (rangeHighlighter != null) // rangeHighlighterがnullじゃなくなったとき
        // {
        //     rangeHighlighter.ShowMoveRange(transform.position, moveRange); // rangeHighlighterに入ったキャラにShowMoveRangeを実行、rangeにmoveRangeを代入
        // }
    }

    public void Deselect() // CursorControllerで呼び出されたとき
    {
        Debug.Log("Deselect");
        isInMoveMode = false;
        rangeHighlighter.ClearHighlights();
    }
    public void StartMoveMode() // CommandUIのOnMove関数で呼び出されたら
    {
        isInMoveMode = true; // isInMoveModeをtrueに
        rangeHighlighter.ShowMoveRange(transform.position, stats.moveRange); // MoveRangeHighlighterのShowMoveRange関数呼び出し
        previousPosition = transform.position; // 移動後キャンセルボタンで元の位置に戻すために、移動前座標を入れておく変数
    }
    public void CancelMove() // 呼び出されたらキャラクターを元の位置に戻す
    {
        if (isMoving) return; // 移動中には戻さない
        transform.position = previousPosition; // キャラクターの現在座標を記憶座標に
        isInMoveMode = false; // isInMoveModeはfalseに
        rangeHighlighter.ClearHighlights(); // タイルハイライトもリセット
        Debug.Log($"{gameObject.name}をもとの位置に戻しました");
    }
    public void Wait() // CommandUIで呼び出し
    {
        hasActed = true; // 呼び出されたらtrueに
        Debug.Log($"{gameObject.name}は待機して行動済みになりました");
        Deselect();
        GetComponent<SpriteRenderer>().color = Color.gray; // Waitボタン押下でキャラクターの色をグレーに
    }
    // public void TryMoveTo(Vector3 destination) // CursorControllerに呼び出されたとき
    // // 目的地(destination)に向かって移動できるかチェックして可能なら移動
    // {
    //     if (!isSelected || isMoving) return; // 非isSelectedかisMovingのとき、処理を中断
    //     Vector3Int charGrid = grid.WorldToCell(transform.position); // charGridにキャラの現在位置(グリッド座標)代入
    //     Vector3Int destGrid = grid.WorldToCell(destination); // destGridに目的地の位置(グリッド座標)代入
    //     // マンハッタン距離で計算、destGrid(目的地グリッド) - charGrid(キャラの現在グリッド)をx,yそれぞれ引いて足した値が移動先のグリッドになる
    //     int distance = Mathf.Abs(destGrid.x - charGrid.x) + Mathf.Abs(destGrid.y - charGrid.y); // distanceにcharGridとdestGridを足した値を代入
    //     if (distance <= moveRange) // 移動先グリッドを代入したdistance変数がmoveRange(移動力)より小さいとき
    //     {
    //         Debug.Log($"移動距離: {distance} → OK、移動開始");
    //         targetPosition = grid.GetCellCenterWorld(destGrid); // グリッドの中央にグラフィックを揃える
    //         isMoving = true; // Update内の移動処理が動くように、isMovingをtrueへ
    //         isSelected = false; // 選択解除
    //     }
    //     else // distance変数がmoveRangeより大きいとき
    //     {
    //         Debug.Log("移動範囲外");
    //     }
    // }
}
