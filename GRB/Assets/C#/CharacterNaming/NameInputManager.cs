using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NameInputManager : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public CharacterStatus characterStatus; // 主人公のオブジェクト（事前にシーンに置くかScriptableObjectなど）

    public void OnClickConfirm()
    {
        string enteredName = nameInputField.text.Trim();

        if (string.IsNullOrEmpty(enteredName))
        {
            Debug.LogWarning("名前が空です！");
            return;
        }

        characterStatus.name = enteredName;
        Debug.Log("名前設定完了：" + enteredName);

        // 次のシーンに進む
        SceneManager.LoadScene("CharacterCreateScene");
    }
}
