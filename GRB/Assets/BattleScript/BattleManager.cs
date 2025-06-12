public class BattleManager : MonoBehaviour
{
    public CharacterSpawner spawner; // Unityでアタッチしておく
    public CursorController cursorController;

    public List<GameObject> playerUnits;

    void Start()
    {
        // スポーン済みキャラを取得
        playerUnits = spawner.GetSpawnedCharacters(); // または spawner.SpawnedCharacters

        StartPlayerTurn();
    }

    // 以下は先ほどと同じ
    void StartPlayerTurn()
    {
        GameObject leadUnit = GetLeadUnit(playerUnits);
        if (leadUnit != null)
        {
            cursorController.ShowCursor();
            cursorController.SetCursorPosition(leadUnit.transform.position);
        }
    }

    GameObject GetLeadUnit(List<GameObject> units)
    {
        if (units == null || units.Count == 0) return null;
        GameObject lead = units[0];
        float minY = lead.transform.position.y;
        foreach (var unit in units)
        {
            if (unit.transform.position.y < minY)
            {
                minY = unit.transform.position.y;
                lead = unit;
            }
        }
        return lead;
    }
}
