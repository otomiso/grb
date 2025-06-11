using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<GameObject> playerUnits; // 自軍ユニット一覧
    public GameObject cursor; // カーソル
    private GameObject currentUnit; // カーソル対象キャラ
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentUnit != null && cursor.activeSelf) // カーソル追従
        {
            cursor.transform.position = currentUnit.transform.position + new Vector3(0, 0.5f, 0);
        }
    }
    void OnPlayerTurnStart()
    {
        if (playerUnits.Count == 0) return;

        GameObject leadUnit = playerUnits[0];
        float minY = leadUnit.transform.position.y;

        // 一番前にいるユニットを探す

        foreach (GameObject unit in playerUnits)
        {
            float y = unit.transform.position.y;
            if (y < minY)
            {
                minY = y;
                leadUnit = unit;
            }
        }

        // カーソルを先頭ユニットの上に配置
        cursor.SetActive(true);
        cursor.transform.position = leadUnit.transform.position + new Vector3(0, 0.5f, 0);

        currentUnit = leadUnit;
    }
}
