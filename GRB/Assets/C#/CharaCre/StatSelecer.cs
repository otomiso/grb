using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

public class StatSelecter : MonoBehaviour
{
    [Header("ステータス表示UI")]
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI mpText;
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI blockText;
    public TextMeshProUGUI defenseText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI totalText;
    [Header("確定ボタン")]
    public Button confirmButton;

    [Header("キャラクターステータス")]
    public CharacterStatus characterStatus;

    private List<TextMeshProUGUI> statTexts;
    private int selectedIndex = 0;

    private const int minValue = 30;
    private const int step = 10;
    private const int totalMax = 600;

    private int hp = 30;
    private int mp = 30;
    private int attack = 30;
    private int block = 30;
    private int defense = 30;
    private int speed = 30;
    private int total;


    // public TMP_Dropdown dropdownHP;
    // public TMP_Dropdown  dropdownMP;
    // public TMP_Dropdown  dropdownAttack;
    // public TMP_Dropdown  dropdownBlock;
    // public TMP_Dropdown  dropdownDefense;
    // public TMP_Dropdown  dropdownSpeed;

    // public Button confirmButton;
    // public CharacterStatus characterStatus;

    // private List<TMP_Dropdown> allDropdowns;

    // private const int minValue = 30;
    // private const int maxValue = 300;
    // private const int step = 10;
    // private const int totalMax = 550;

    // void Start()
    // {
    //     allDropdowns = new List<TMP_Dropdown> {
    //         dropdownHP, dropdownMP, dropdownAttack, dropdownBlock, dropdownDefense, dropdownSpeed
    //     };

    //     foreach (TMP_Dropdown dropdown in allDropdowns)
    //     {
    //         dropdown.ClearOptions();
    //         List<string> options = new List<string>();
    //         for (int i = minValue; i <= maxValue; i += step)
    //         {
    //             options.Add(i.ToString());
    //         }
    //         dropdown.AddOptions(options);
    //         dropdown.onValueChanged.AddListener(delegate { ValidateTotal(); });
    //     }

    //     confirmButton.onClick.AddListener(ApplyStats);
    //     ValidateTotal(); // 初期状態でボタン有効/無効化
    // }

    // void Update()
    // {
    //     HandleInput();
    // }
    // void ValidateTotal()
    // {
    //     int total = 0;
    //     foreach (TMP_Dropdown dropdown in allDropdowns)
    //     {
    //         total += minValue + dropdown.value * step;
    //     }

    //     confirmButton.interactable = total <= totalMax;
    // }

    // void ApplyStats()
    // {
    //     if (!confirmButton.interactable) return;

    //     // characterStatus.MAXHP = GetDropdownValue(dropdownHP);
    //     // characterStatus.MAXMP = GetDropdownValue(dropdownMP);
    //     // characterStatus.attack = GetDropdownValue(dropdownAttack);
    //     // characterStatus.block = GetDropdownValue(dropdownBlock);
    //     // characterStatus.defense = GetDropdownValue(dropdownDefense);
    //     // characterStatus.speed = GetDropdownValue(dropdownSpeed);

    //     characterStatus.MAXHP = hp;
    //     characterStatus.MAXMP = mp;
    //     characterStatus.attack = attack;
    //     characterStatus.block = block;
    //     characterStatus.defense = defense;
    //     characterStatus.speed = speed;

    //     Debug.Log("ステータスを設定しました！");
    //     Debug.Log(characterStatus.MAXHP);
    //     Debug.Log(characterStatus.MAXMP);
    //     Debug.Log(characterStatus.attack);
    //     Debug.Log(characterStatus.block);
    //     Debug.Log(characterStatus.defense);
    //     Debug.Log(characterStatus.speed);
    // }

    // int GetDropdownValue(TMP_Dropdown dropdown)
    // {
    //     return minValue + dropdown.value * step;
    // }
       void Start()
    {
        statTexts = new List<TextMeshProUGUI> { hpText, mpText, attackText, blockText, defenseText, speedText , totalText};
        UpdateUI();
        // confirmButton.onClick.AddListener(ApplyStats);
    }

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        // --- W / S で選択移動 ---
        if (Input.GetKeyDown(KeyCode.W))
        {
            selectedIndex = (selectedIndex - 1 + statTexts.Count) % statTexts.Count;
            UpdateUI();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            selectedIndex = (selectedIndex + 1) % statTexts.Count;
            UpdateUI();
        }

        // --- A / D で増減 ---
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeStat(-step);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            ChangeStat(+step);
        }
    }

    void ChangeStat(int amount)
    {
        int currentTotal = hp + mp + attack + block + defense + speed;
        // total = currentTotal;

        switch (selectedIndex)
        {
            case 0: // HP
                if (hp + amount >= minValue && currentTotal + amount <= totalMax) hp += amount;
                break;
            case 1: // MP
                if (mp + amount >= minValue && currentTotal + amount <= totalMax) mp += amount;
                break;
            case 2: // Attack
                if (attack + amount >= minValue && currentTotal + amount <= totalMax) attack += amount;
                break;
            case 3: // Block
                if (block + amount >= minValue && currentTotal + amount <= totalMax) block += amount;
                break;
            case 4: // Defense
                if (defense + amount >= minValue && currentTotal + amount <= totalMax) defense += amount;
                break;
            case 5: // Speed
                if (speed + amount >= minValue && currentTotal + amount <= totalMax) speed += amount;
                break;
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        // 表示更新
        hpText.text = $"HP: {hp}";
        mpText.text = $"MP: {mp}";
        attackText.text = $"Attack: {attack}";
        blockText.text = $"Block: {block}";
        defenseText.text = $"Defense: {defense}";
        speedText.text = $"Speed: {speed}";

        total = hp + mp + attack + block + defense + speed;
        totalText.text = $"Total: {total}";

        // 選択中のステータスを強調表示
        for (int i = 0; i < statTexts.Count; i++)
        {
            statTexts[i].color = (i == selectedIndex) ? Color.yellow : Color.white;
        }

        characterStatus.MAXHP = hp;
        characterStatus.MAXMP = mp;
        characterStatus.attack = attack;
        characterStatus.block = block;
        characterStatus.defense = defense;
        characterStatus.speed = speed;

        // confirmButton.interactable = total <= totalMax;
        if(total == totalMax)
        {
            // 次のシーンに進む
            SceneManager.LoadScene("CharacterNamingScene");
        }
    }

    // void ApplyStats()
    // {
    //     characterStatus.MAXHP = hp;
    //     characterStatus.MAXMP = mp;
    //     characterStatus.attack = attack;
    //     characterStatus.block = block;
    //     characterStatus.defense = defense;
    //     characterStatus.speed = speed;

    //     Debug.Log("ステータスを確定しました！");
    //     Debug.Log($"HP:{hp}, MP:{mp}, Attack:{attack}, Block:{block}, Defense:{defense}, Speed:{speed}");
    // }
}
