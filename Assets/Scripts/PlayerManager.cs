using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerManager : MonoBehaviour
{
    public Font font;
    public Tilemap tileMapFarmLand;

    public Tile FarmLand;
    private int seeds = 0;
    private int flowers = 0;

    public float GrowTime = 6.0f;
    public GameObject FlowerPref;



    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            var worldPoint = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);

            Vector3Int tpos = tileMapFarmLand.WorldToCell(worldPoint);

            TileBase tile = tileMapFarmLand.GetTile(tpos);
            Vector3 tposi = tpos + new Vector3(0.5f, 0.5f, 0f);

            if (tile && flowers > 0)
            {
                Instantiate(FlowerPref, tposi, Quaternion.identity);
                flowers--;
            }

        }
    }



    public void addFlower(int i)
    {
        flowers += i;
    }

    public void addSeed(int i)
    {
        seeds += i;
    }

    public int getSeeds()
    {
        return seeds;
    }
    void OnGUI()
    {
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.font = font;
        style.fontSize = 32;
        GUILayout.BeginVertical();
        GUILayout.Label("Seeds: " + seeds, style);
        GUILayout.Label("Flowers: " + flowers, style);
        GUILayout.Label("wasd to move, hold shift to sprint", style);
        GUILayout.EndVertical();
    }
}
