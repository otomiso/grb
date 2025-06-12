using UnityEngine;
using System.Collections.Generic; // リスト用

public class CharacterSpawner : MonoBehaviour
{
    [System.Serializable]
    public class CharacterSpawnData // 各キャラのプレハブと出現座標をセット扱う
    {
        public GameObject characterPrefab; // キャラを生成するためのプレハブ
        public Vector3Int spawnPosition;   // キャラをタイルマップ上のどこに出現させるかを整数ベースの座標を指定
    }

    public List<CharacterSpawnData> charactersToSpawn = new List<CharacterSpawnData>(); // 配置するキャラのリスト

    private List<GameObject> spawnedCharacters = new List<GameObject>(); // 生成済みキャラの参照を保持
    public List<GameObject> GetSpawnedCharacters()
    {
        return spawnedCharacters;
    }

    void Start()
    {
        foreach (var data in charactersToSpawn) // リストに登録されている各キャラの情報を順番に取り出して処理
        {
            // TileMapの座標をワールド座標に変換、+0.5fすることでタイルの中心にキャラを配置
            Vector3 worldPosition = new Vector3(data.spawnPosition.x + 0.5f, data.spawnPosition.y + 0.5f, 0);
            GameObject instance = Instantiate(data.characterPrefab, worldPosition, Quaternion.identity);
            // キャラのプレハブをワールド座標に生成(インスタンス化)、Quaternion.identitは回転なしで(初期状態)で配置する意味
            spawnedCharacters.Add(instance); // 生成したキャラをスポーンキャラクターリストに追加して記録
        }
    }
}
