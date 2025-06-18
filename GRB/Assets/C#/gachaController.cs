using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class gachaController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    //ガチャの処理
    //ランダムで番号を取り出し、番号を引数としてjsonWritterのLoadJsonDataでキャラクター情報を呼び出す。
    //番号とキャラクターのidが紐づく。
    private string filePath;
    private string deleteFilePath;
    void gachaSelection()
    {
        
        deleteFilePath = Application.dataPath + "/characterJson/gachaCharacter.json";
        File.Delete(deleteFilePath);

        filePath = Application.dataPath + "/characterJson/character.json";
        jsonWritter loadJson = ScriptableObject.CreateInstance<jsonWritter>();
        //1~100の数字をリストに入れる
        List<int> numbers = new List<int>();
        for (int i = 1; i <= 100; i++)
        {
            numbers.Add(i);
        }

        for (int i = 0; i < 10; i++)
        {
            //ランダムで数字を一つ選出
            int index = Random.Range(0, numbers.Count);
            int randomNumber = numbers[index];

            //選出された数字をリストから削除
            numbers.RemoveAt(index);
            loadJson.LoadJsonData(index);
        }
        
    }
}
