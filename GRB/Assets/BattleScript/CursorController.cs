using UnityEngine;

public class CursorController : MonoBehaviour
{
    public bool controlEnabled = false; // カーソル制御 true:プレイヤーターン false:エネミーターン
    public Grid grid; // UnityのGridをInspectorでセット
    private CharacterMover selectedCharacter = null; // CharacterMoverがアタッチされているオブジェクトを参照、変数初期化
    private bool hasJustSelected = false; // キャラを選択した直後かどうか (1フレームスキップ用)
    public float zoomSpeed = 5f;  // ズーム
    public float minZoom = 3f; // ズーム
    public float maxZoom = 10f; // ズーム
    void Start()
    {
          
    }
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

        if (Input.GetMouseButtonDown(0)) // 左クリックされたとき
        {
            if (hasJustSelected) // hasJustSelectedがtrueになったとき
            {
                hasJustSelected = false; // フレーム消費
                Debug.Log("falseに変更");

                // 移動処理
                if (selectedCharacter != null) // 下記処理でselectedCharacterがnullじゃなくなったとき
                {
                    //selectedCharacter.TryMoveTo(transform.position); // selectedCharacterに入ったキャラにCharacterMoverのTryMoveTo関数を実行
                    Debug.Log("動いてます");
                    selectedCharacter.Deselect(); // 処理後、選択解除
                    selectedCharacter = null; // selectedCharacterを空に
                }
                else
                {
                    Debug.Log("動いてねぇ");
                }
                return; // returnで処理を早期に終了
            }
            Vector2 point = new Vector2(mouseWorldPos.x, mouseWorldPos.y); // マウスカーソルのワールド座標をpoint変数に代入
            RaycastHit2D hit = Physics2D.Raycast(point, Vector2.zero); // マウスカーソルのワールド座標にレイキャスト判定を飛ばし、コライダーに当たるとhit変数に代入

            if (hit.collider != null) // hit変数がnullじゃなくなったとき
            {
                CharacterMover character = hit.collider.GetComponent<CharacterMover>();
                // hitの中にcharacterMoverコンポーネントがアタッチされているオブジェクトがあった場合、character変数に代入
                if (character != null) // character変数がnullじゃなくなったとき
                {
                    if (selectedCharacter != null) // すでにselectetdCharacterが参照されているとき
                    {
                        selectedCharacter.Deselect(); // 選択を取り消し
                    }
                    selectedCharacter = character; // まずselectedCharacterにcharacterを代入
                    selectedCharacter.Select(); // selectedCharacterに入ったキャラに対して、CharacterMoverのSelect関数を実行
                    hasJustSelected = true; //　一旦フレーム消費のため、hasJustSelectedをtrueに    
                }
            }
        }
        // ズーム機能
        float scroll = Input.GetAxis("Mouse ScrollWheel"); // マウススクロールしたら、設定されている値をscroll変数に代入
        if (scroll != 0f) // scroll変数に値が代入されたら
        {
            Camera.main.orthographicSize -= scroll * zoomSpeed; // orthographicSizeにscroll*zoomSpeedを引いた値を代入
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minZoom, maxZoom); // ズームしすぎないようMathf.Clampで制限
        }
    }

    public void SetControlEnabled(bool enabled) // カーソル操作のON/OFFを切り替えるメソッド
    {
        controlEnabled = enabled; // 他のスクリプトからCursorController.SetControlEnabled(true);等で呼び出せるように
    }
}
