using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapController : MonoBehaviour
{
    [SerializeField] TileBase tileBase;
    [SerializeField] TileBase testTile;
    [SerializeField] bool useTestTile = false;
    TileBase tileInUse;
    Tilemap tilemap;
    Grid grid;
    Player player;
    Vector3Int lastVisitTile;
    Vector3Int sizeToFill;
    void Awake() {
        tilemap = GetComponent<Tilemap>();
        grid = transform.parent.GetComponent<Grid>();
        tileInUse = useTestTile?testTile:tileBase;
    }
    void Start() {
        player = Player.Instance;
        RuleTile rule = tileInUse as RuleTile;
        rule.m_TilingRules.First().m_PerlinScale = UnityEngine.Random.Range(0f,1f);
        tilemap.RefreshAllTiles();
    }
    void Update() {
        paintCellMk2();
    }
    void paintCellMk2(){
        GameManager.ScreenPosition screenPos = GameManager.Instance.ScreenPos;
        Vector3Int leftMostCell = grid.WorldToCell(screenPos.bottomLeft);
        Vector3Int rightMostCell = grid.WorldToCell(screenPos.topRight);
        for (int i = leftMostCell.x ; i <= rightMostCell.x;i++){
            for(int y = leftMostCell.y; y <= rightMostCell.y; y++){
                TileBase tile = tilemap.GetTile(new Vector3Int(i,y));
                if (tile != tileInUse || true){
                    tilemap.SetTile(new Vector3Int(i,y),tileInUse);
                }
            } 
        }
    }
}
