using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class CommandUI : MonoBehaviour
{
    public static CommandUI Instance; // CharacterMoverのSelect関数でInstanceで呼び出し
    public RectTransform panel; // UIのフレーム的な
    public Button moveButton; // ボタン
    public Button attackButton; // ボタン
    public Button cancelButton; // ボタン
    public Button waitButton; // ボタン
    public Button skillButton; // ボタン
    private CharacterMover currentCharacter;
        void Awake()
    {
        Instance = this; // Instance変数に自身を代入的な
        panel.gameObject.SetActive(false); // 最初はfalseに   
    }
    public void Show(CharacterMover character, bool afterMove = false) // CharacterMoverのSelect関数で呼び出されたら
    {
        currentCharacter = character; // currentCharacter変数にcharacter(selectedCharacter)を代入
        panel.gameObject.SetActive(true); // UIを表示
        moveButton.gameObject.SetActive(!afterMove);
        attackButton.gameObject.SetActive(true);
        cancelButton.gameObject.SetActive(true);
        waitButton.gameObject.SetActive(true);
        skillButton.gameObject.SetActive(true);
        panel.anchoredPosition = new Vector2(80f, -50f);
    }
    public void Hide() // CharacterMoverに呼び出されたら
    {
        panel.gameObject.SetActive(false); // UI非表示
    }
    void Start()
    {
        moveButton.onClick.AddListener(OnMove); // moveButtonが左クリックされたらOnMove関数呼び出し
        attackButton.onClick.AddListener(OnAttack); // 同上Attack版
        cancelButton.onClick.AddListener(OnCancel); // 同上Cansel版
        waitButton.onClick.AddListener(OnWait); // 同上Wait版
        skillButton.onClick.AddListener(OnSkill);
    }
    void OnMove()
    {
        currentCharacter.StartMoveMode(); // CharacterMoverのStartMoveMode関数呼び出し
        Hide(); // 非表示
    }
    void OnAttack()
    {
        Debug.Log("攻撃モード準備中...");
        Hide();
    }
    void OnCancel() // キャンセルボタン押下で呼び出し
    {
        if (currentCharacter != null) // currentCharacterが参照されているとき
        {
            currentCharacter.CancelMove(); // currentCharacterにCharacterMoverのCancelMove関数を実行
            currentCharacter.Deselect();
            Hide();
        }
    }
    public void OnWait() // Waitボタン押下で呼び出し
    {
        if (currentCharacter != null) // currentCharacterが参照されたとき
        {
            currentCharacter.Wait(); // currentCharacterにCharacterMoverのWaitメソッドを実行
            Hide();
        }
    }
    public void OnSkill()
    {
        Debug.Log("スキルモード準備中...");
        Hide();
    }
    void Update()
    {
        
    }
}
