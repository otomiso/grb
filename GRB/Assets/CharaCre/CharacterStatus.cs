using UnityEngine;
using System.Collections.Generic;  // List を使うには必要

public class CharacterStatus: MonoBehaviour
{
  public int rarity;//レアリティ
  public string attribute;//属性
  public string name;//名前
  public List<string>  equipableWeapons;//装備可能武器種
  public string skillName;//特性の名前
  public string skillDescription;//特性の説明
  public int mobility;//移動力
  public int MAXHP;//最大HP
  public int MAXMP;//最大MP
  public int attack;//攻撃力
  public int block;//防御力
  public int defense;//魔防力
  public int speed;//素早さ
  public string skillA;//MP使用技A
  public string skillB;//MP使用技B
  public string skillC;//MP使用技C
  public string skillADescription;//MP使用技Aの説明
  public string skillBDescription;//MP使用技Bの説明
  public string skillCDescription;//MP使用技Cの説明

  public int HP;//現在HP
  public int MP;//現在MP
  public int LV;//現在レベル
  public int EXP;//累計経験値
  public bool poison;//どく
  public bool paralysis;//まひ
  public bool burn;//やけど
  public bool sleep;//ねむり
  public bool ice;//こおり
  public bool stan;//行動不能
  public bool actionDone;//行動済みフラグ
  public string roleType;// 敵・味方・ボス・主人公を判別
  List<string> items = new List<string>();//所持アイテム
  public string equippedWeapon;//装備中の武器

}
