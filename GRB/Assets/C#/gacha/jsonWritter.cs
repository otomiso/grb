using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Schema;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using UnityEngine;

[System.Serializable]
public class CharacterList//ガチャキャラクターをさらに配列に格納するための変数宣言するクラス
{
    public List<InitialData> characters;

}
[System.Serializable]
public class InitialData//最初のDBに入っている1体分のガチャキャラクター配列クラス
{
    public int id;//ID
    public int rarity;//レアリティ
    public string attribute;//属性  
    public string name;//名前
    public string[] equipableWeapons;//装備可能武器種
    public string skillName;//特性の名前
    public string skillDescription;//特性の説明
    public int mobility;//移動力
    public int maxHP;//HP
    public int maxMP;//MP
    public int attack;//攻撃力
    public int block;//防御力
    public int defense;//魔防力
    public int speed;//素早さ
    public string mpAttack;//MP使用技
    public string mpAttackDescription;//MP使用技の説明

    public int level;//レベル
    public int totalXP;//トータル経験値
    public string belongGroup;//所属団
    public List<string> haveItems;//所持アイテム
    public string haveWeapon;//装備武器


    // public InitialData(int id, int rarity, string attribute, string name, string[] equipableWeapons, string skillName, string skillDescription,
    // int mobility, int maxHP, int maxMP, int attack, int block, int defense, int speed, string mpAttack, string mpAttackDescription)//将来ゴミになる？
    // {
    //     this.id = id;
    //     this.rarity = rarity;
    //     this.attribute = attribute;
    //     this.name = name;
    //     this.equipableWeapons = equipableWeapons;
    //     this.skillName = skillName;
    //     this.skillDescription = skillDescription;
    //     this.mobility = mobility;
    //     this.maxHP = maxHP;
    //     this.maxMP = maxMP;
    //     this.attack = attack;
    //     this.block = block;
    //     this.defense = defense;
    //     this.speed = speed;
    //     this.mpAttack = mpAttack;
    //     this.mpAttackDescription = mpAttackDescription;
    // }
}

[System.Serializable]
public class GachaData//ガチャキャラクターを保存するために追加するクラス
{
    private string saveFilePath;

    //引いたガチャキャラクターの情報をjsonファイルで保存
    public void SaveGachaJsonData(InitialData character)
    {
        CharacterList gachaCharacterList;
        character.level = 1;
        character.totalXP = 1;
        character.belongGroup = null;
        character.haveItems = null;
        character.haveWeapon = null;
        Debug.Log("キャラの名前"+character.name);
        Debug.Log("キャラのレベル"+character.level);

        saveFilePath = Application.dataPath + "/characterJson/gachaCharacter.json";
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            gachaCharacterList = JsonUtility.FromJson<CharacterList>(json);
            gachaCharacterList.characters.Add(character);
            string updateJson = JsonUtility.ToJson(gachaCharacterList, true);
            File.WriteAllText(saveFilePath, updateJson); // JSONデータを書き込み
            Debug.Log($"最初以外のガチャデータ保存完了: {saveFilePath}");
        }
        else
        {
            //ガチャの結果のキャラクターの配列を作る
            gachaCharacterList = new CharacterList { characters = new List<InitialData>() };
            gachaCharacterList.characters.Add(character);
            string json = JsonUtility.ToJson(gachaCharacterList, true);
            File.WriteAllText(saveFilePath, json); // JSONデータを書き込み
            Debug.Log($"最初のガチャデータ保存完了: {saveFilePath}");
        }
    }
}
public class jsonWritter : ScriptableObject
{
    private string filePath;
    void Start()
    {
        // 保存先のファイルパスを指定
        //filePath = Application.dataPath + "/characterJson/character.json";
        //string[] weapons1 = { "剣", "斧" };

        // サンプルデータの保存と読み込み
        // SaveJsonData(new DataToSave(1, 1, "久宝寺", "仮太郎", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(2,1,"久宝寺","仮太郎2",weapons1,"長瀬デビル","相手に最大HPの2割分の固定ダメージ",6,70,20,70,50,40,50,"鶏の寄り道","自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(3, 1, "久宝寺", "仮太郎3", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(4, 1, "久宝寺", "仮太郎4", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(5, 1, "久宝寺", "仮太郎5", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(6, 1, "久宝寺", "仮太郎6", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(7, 1, "久宝寺", "仮太郎7", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(8, 1, "久宝寺", "仮太郎8", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(9, 1, "久宝寺", "仮太郎9", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(10, 1, "久宝寺", "仮太郎10", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(11, 1, "久宝寺", "仮太郎11", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(12, 1, "久宝寺", "仮太郎12", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(13, 1, "久宝寺", "仮太郎13", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(14, 1, "久宝寺", "仮太郎14", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(15, 1, "久宝寺", "仮太郎15", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(16, 1, "久宝寺", "仮太郎16", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(17, 1, "久宝寺", "仮太郎17", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(18, 1, "久宝寺", "仮太郎18", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(19, 1, "久宝寺", "仮太郎19", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(20, 1, "久宝寺", "仮太郎20", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(21, 1, "久宝寺", "仮太郎21", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(22, 1, "久宝寺", "仮太郎22", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(23, 1, "久宝寺", "仮太郎23", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(24, 1, "久宝寺", "仮太郎24", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(25, 1, "久宝寺", "仮太郎25", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(26, 1, "久宝寺", "仮太郎26", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(27, 1, "久宝寺", "仮太郎27", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(28, 1, "久宝寺", "仮太郎28", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(29, 1, "久宝寺", "仮太郎29", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(30, 1, "久宝寺", "仮太郎30", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(31, 1, "久宝寺", "仮太郎31", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(32, 1, "久宝寺", "仮太郎32", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(33, 1, "久宝寺", "仮太郎33", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(34, 1, "久宝寺", "仮太郎34", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(35, 1, "久宝寺", "仮太郎35", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(36, 1, "久宝寺", "仮太郎36", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(37, 1, "久宝寺", "仮太郎37", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(38, 1, "久宝寺", "仮太郎38", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(39, 1, "久宝寺", "仮太郎39", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(40, 1, "久宝寺", "仮太郎40", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(41, 1, "久宝寺", "仮太郎41", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(42, 1, "久宝寺", "仮太郎42", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(43, 1, "久宝寺", "仮太郎43", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(44, 1, "久宝寺", "仮太郎44", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(45, 1, "久宝寺", "仮太郎45", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(46, 1, "久宝寺", "仮太郎46", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(47, 1, "久宝寺", "仮太郎47", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(48, 1, "久宝寺", "仮太郎48", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(49, 1, "久宝寺", "仮太郎49", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(50, 1, "久宝寺", "仮太郎50", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(51, 1, "久宝寺", "仮太郎51", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(52, 1, "久宝寺", "仮太郎52", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(53, 1, "久宝寺", "仮太郎53", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(54, 1, "久宝寺", "仮太郎54", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(55, 1, "久宝寺", "仮太郎55", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(56, 1, "久宝寺", "仮太郎56", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(57, 1, "久宝寺", "仮太郎57", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(58, 1, "久宝寺", "仮太郎58", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(59, 1, "久宝寺", "仮太郎59", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(60, 1, "久宝寺", "仮太郎60", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(61, 1, "久宝寺", "仮太郎61", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(62, 1, "久宝寺", "仮太郎62", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(63, 1, "久宝寺", "仮太郎63", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(64, 1, "久宝寺", "仮太郎64", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(65, 1, "久宝寺", "仮太郎65", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(66, 1, "久宝寺", "仮太郎66", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(67, 1, "久宝寺", "仮太郎67", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(68, 1, "久宝寺", "仮太郎68", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(69, 1, "久宝寺", "仮太郎69", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(70, 1, "久宝寺", "仮太郎70", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(71, 1, "久宝寺", "仮太郎71", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(72, 1, "久宝寺", "仮太郎72", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(73, 1, "久宝寺", "仮太郎73", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(74, 1, "久宝寺", "仮太郎74", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(75, 1, "久宝寺", "仮太郎75", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(76, 1, "久宝寺", "仮太郎76", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(77, 1, "久宝寺", "仮太郎77", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(78, 1, "久宝寺", "仮太郎78", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(79, 1, "久宝寺", "仮太郎79", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(80, 1, "久宝寺", "仮太郎80", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(81, 1, "久宝寺", "仮太郎81", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(82, 1, "久宝寺", "仮太郎82", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(83, 1, "久宝寺", "仮太郎83", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(84, 1, "久宝寺", "仮太郎84", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(85, 1, "久宝寺", "仮太郎85", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(86, 1, "久宝寺", "仮太郎86", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(87, 1, "久宝寺", "仮太郎87", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(88, 1, "久宝寺", "仮太郎88", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(89, 1, "久宝寺", "仮太郎89", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(90, 1, "久宝寺", "仮太郎90", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(91, 1, "久宝寺", "仮太郎91", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(92, 1, "久宝寺", "仮太郎92", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(93, 1, "久宝寺", "仮太郎93", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(94, 1, "久宝寺", "仮太郎94", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(95, 1, "久宝寺", "仮太郎95", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(96, 1, "久宝寺", "仮太郎96", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(97, 1, "久宝寺", "仮太郎97", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(98, 1, "久宝寺", "仮太郎98", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(99, 1, "久宝寺", "仮太郎99", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));
        // SaveJsonData(new DataToSave(100, 1, "久宝寺", "仮太郎100", weapons1, "長瀬デビル", "相手に最大HPの2割分の固定ダメージ", 6, 70, 20, 70, 50, 40, 50, "鶏の寄り道", "自分の攻撃力を1.5倍する"));

        //LoadJsonData();
    }

    // void SaveJsonData(InitialData data)
    // {
    //     CharacterList characterList;
    //     if (File.Exists(filePath))
    //     {
    //         string json = File.ReadAllText(filePath);
    //         characterList = JsonUtility.FromJson<CharacterList>(json);
    //         characterList.characters.Add(data);
    //         Debug.Log(data.name);
    //         string updateJson = JsonUtility.ToJson(characterList, true);
    //         File.WriteAllText(filePath, updateJson); // JSONデータを書き込み
    //         Debug.Log($"データ保存完了: {filePath}");
    //     }
    //     else
    //     {
    //         //ガチャの結果のキャラクターの配列を作る
    //         string json = JsonUtility.ToJson(data, true);
    //         File.WriteAllText(filePath, json); // JSONデータを書き込み
    //         Debug.Log($"データ保存完了: {filePath}");
    //     }
    // }

    public void LoadJsonData(int index)
    {
        GachaData gachaData = new GachaData();
        filePath = Application.dataPath + "/characterJson/character.json";
        CharacterList loadedList;
        Debug.Log(filePath);
        //Debug.Log("ガチャID: " + index);
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath); // JSONデータを読み込み
            loadedList = JsonUtility.FromJson<CharacterList>(json);
            foreach (var character in loadedList.characters)
            {
                if (character.id == index)
                {
                    Debug.Log($"データ読み込み完了: ガチャID={character.id},名前={character.name}, 最大HP={character.maxHP}");
                    gachaData.SaveGachaJsonData(character);
                    break;
                }
            }
        }
        else
        {
            Debug.LogWarning("保存ファイルが見つかりませんでした！");
        }
    }
}

