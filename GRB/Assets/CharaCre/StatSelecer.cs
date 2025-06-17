using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
public class StatSelecter : MonoBehaviour
{
    public TMP_Dropdown  dropdownHP;
    public TMP_Dropdown  dropdownMP;
    public TMP_Dropdown  dropdownAttack;
    public TMP_Dropdown  dropdownBlock;
    public TMP_Dropdown  dropdownDefense;
    public TMP_Dropdown  dropdownSpeed;

    public Button confirmButton;
    public CharacterStatus characterStatus;

    private List<TMP_Dropdown> allDropdowns;

    private const int minValue = 30;
    private const int maxValue = 300;
    private const int step = 10;
    private const int totalMax = 550;

    void Start()
    {
        allDropdowns = new List<TMP_Dropdown> {
            dropdownHP, dropdownMP, dropdownAttack, dropdownBlock, dropdownDefense, dropdownSpeed
        };

        foreach (TMP_Dropdown dropdown in allDropdowns)
        {
            dropdown.ClearOptions();
            List<string> options = new List<string>();
            for (int i = minValue; i <= maxValue; i += step)
            {
                options.Add(i.ToString());
            }
            dropdown.AddOptions(options);
            dropdown.onValueChanged.AddListener(delegate { ValidateTotal(); });
        }

        confirmButton.onClick.AddListener(ApplyStats);
        ValidateTotal(); // 初期状態でボタン有効/無効化
    }

    void ValidateTotal()
    {
        int total = 0;
        foreach (TMP_Dropdown dropdown in allDropdowns)
        {
            total += minValue + dropdown.value * step;
        }

        confirmButton.interactable = total <= totalMax;
    }

    void ApplyStats()
    {
        if (!confirmButton.interactable) return;

        characterStatus.MAXHP = GetDropdownValue(dropdownHP);
        characterStatus.MAXMP = GetDropdownValue(dropdownMP);
        characterStatus.attack = GetDropdownValue(dropdownAttack);
        characterStatus.block = GetDropdownValue(dropdownBlock);
        characterStatus.defense = GetDropdownValue(dropdownDefense);
        characterStatus.speed = GetDropdownValue(dropdownSpeed);

        Debug.Log("ステータスを設定しました！");
        Debug.Log(characterStatus.MAXHP);
        Debug.Log(characterStatus.MAXMP);
        Debug.Log(characterStatus.attack);
        Debug.Log(characterStatus.block);
        Debug.Log(characterStatus.defense);
        Debug.Log(characterStatus.speed);
    }

    int GetDropdownValue(TMP_Dropdown dropdown)
    {
        return minValue + dropdown.value * step;
    }
}
