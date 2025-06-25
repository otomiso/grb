using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Tilemaps;
[CreateAssetMenu(fileName =  "NewCostTile", menuName =  "Tiles/CostTile")]
public class CostTile : Tile
{
    public int moveCost = 1; // 移動コスト
}
