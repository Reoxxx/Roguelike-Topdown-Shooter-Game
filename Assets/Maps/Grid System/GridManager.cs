using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;
using roadTypes = Tile.roadTypes;
using freezoneTypes = Tile.freezoneTypes;
using tileTypes = Tile.tileTypes;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width, _height;
    static int _x = 10, _y = 10;
    [SerializeField] private Tile tilePrefab;
    private Tile[,] tiles = new Tile[_x * 3, _y * 3];
    Grid grid;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GenerateGrid()
    {
        for (int y = 0; y < _y * 3; y++)
        {
            for (int x = 0; x < _x * 3; x++)
            {
                var tile = Instantiate(tilePrefab, new Vector2(x * _width, y * _height), Quaternion.identity);
                tile.name = "Tile(" + x + "," + y + ")";
                tile.CreateTile(x * _width, y * _height, _width, _height, x, y);
                tiles[x, y] = tile;
            }
        }
    }

    public void DrawRoad(int x, int y, roadTypes roadType)
    {
        GameObject road = new GameObject();
        var spriteRenderer = road.AddComponent<SpriteRenderer>();
        var sprite = Resources.Load<Sprite>("Sprites/RoadSprites/A");
        int coordX = x * 3, coordY = y * 3;

        tiles[coordX + 1, coordY + 1].updateType(tileTypes.road);
        tiles[coordX + 1, coordY + 1].road = roadType;
        if (roadType == roadTypes.Srrl)
        {
            tiles[coordX + 1, coordY].updateType(tileTypes.road);
            tiles[coordX + 1, coordY].road = roadType;

            tiles[coordX + 2, coordY + 1].updateType(tileTypes.road);
            tiles[coordX + 2, coordY + 1].road = roadType;

            sprite = Resources.Load<Sprite>("Sprites/RoadSprites/O");
        }
        else if(roadType == roadTypes.Srtb)
        {
            tiles[coordX, coordY + 1].updateType(tileTypes.road);
            tiles[coordX, coordY + 1].road = roadType;

            tiles[coordX + 1, coordY + 2].updateType(tileTypes.road);
            tiles[coordX + 1, coordY + 2].road = roadType;

            sprite = Resources.Load<Sprite>("Sprites/RoadSprites/N");
        }
        else if (roadType == roadTypes.Drl)
        {
            tiles[coordX + 1, coordY].updateType(tileTypes.road);
            tiles[coordX + 1, coordY].road = roadType;

            sprite = Resources.Load<Sprite>("Sprites/RoadSprites/L");
        }
        else if (roadType == roadTypes.Drr)
        {
            tiles[coordX + 2, coordY + 1].updateType(tileTypes.road);
            tiles[coordX + 2, coordY + 1].road = roadType;

            sprite = Resources.Load<Sprite>("Sprites/RoadSprites/K");
        }
        else if (roadType == roadTypes.Drb)
        {
            tiles[coordX, coordY + 1].updateType(tileTypes.road);
            tiles[coordX, coordY + 1].road = roadType;

            sprite = Resources.Load<Sprite>("Sprites/RoadSprites/M");
        }
        else if (roadType == roadTypes.Drt)
        {
            tiles[coordX + 1, coordY + 2].updateType(tileTypes.road);
            tiles[coordX + 1, coordY + 2].road = roadType;

            sprite = Resources.Load<Sprite>("Sprites/RoadSprites/J");
        }
        else if (roadType == roadTypes.Lrlb)
        {
            tiles[coordX + 1, coordY].updateType(tileTypes.road);
            tiles[coordX + 1, coordY].road = roadType;

            tiles[coordX, coordY + 1].updateType(tileTypes.road);
            tiles[coordX, coordY + 1].road = roadType;

            sprite = Resources.Load<Sprite>("Sprites/RoadSprites/G");
        }
        else if (roadType == roadTypes.Lrlt)
        {
            tiles[coordX + 1, coordY].updateType(tileTypes.road);
            tiles[coordX + 1, coordY].road = roadType;

            tiles[coordX + 1, coordY + 2].updateType(tileTypes.road);
            tiles[coordX + 1, coordY + 2].road = roadType;

            sprite = Resources.Load<Sprite>("Sprites/RoadSprites/H");
        }
        else if (roadType == roadTypes.Lrrt)
        {
            tiles[coordX + 2, coordY + 1].updateType(tileTypes.road);
            tiles[coordX + 2, coordY + 1].road = roadType;

            tiles[coordX + 1, coordY + 2].updateType(tileTypes.road);
            tiles[coordX + 1, coordY + 2].road = roadType;

            sprite = Resources.Load<Sprite>("Sprites/RoadSprites/I");
        }
        else if (roadType == roadTypes.Lrrb)
        {
            tiles[coordX, coordY + 1].updateType(tileTypes.road);
            tiles[coordX, coordY + 1].road = roadType;

            tiles[coordX + 2, coordY + 1].updateType(tileTypes.road);
            tiles[coordX + 2, coordY + 1].road = roadType;

            sprite = Resources.Load<Sprite>("Sprites/RoadSprites/F");
        }
        else if (roadType == roadTypes.Trl)
        {
            tiles[coordX + 1, coordY].updateType(tileTypes.road);
            tiles[coordX + 1, coordY].road = roadType;

            tiles[coordX, coordY + 1].updateType(tileTypes.road);
            tiles[coordX, coordY + 1].road = roadType;

            tiles[coordX + 1, coordY + 2].updateType(tileTypes.road);
            tiles[coordX + 1, coordY + 2].road = roadType;

            sprite = Resources.Load<Sprite>("Sprites/RoadSprites/C");
        }
        else if (roadType == roadTypes.Trb)
        {
            tiles[coordX + 1, coordY].updateType(tileTypes.road);
            tiles[coordX + 1, coordY].road = roadType;

            tiles[coordX, coordY + 1].updateType(tileTypes.road);
            tiles[coordX, coordY + 1].road = roadType;

            tiles[coordX + 2, coordY + 1].updateType(tileTypes.road);
            tiles[coordX + 2, coordY + 1].road = roadType;

            sprite = Resources.Load<Sprite>("Sprites/RoadSprites/E");
        }
        else if (roadType == roadTypes.Trr)
        {
            tiles[coordX, coordY + 1].updateType(tileTypes.road);
            tiles[coordX, coordY + 1].road = roadType;

            tiles[coordX + 2, coordY + 1].updateType(tileTypes.road);
            tiles[coordX + 2, coordY + 1].road = roadType;

            tiles[coordX + 1, coordY + 2].updateType(tileTypes.road);
            tiles[coordX + 1, coordY + 2].road = roadType;

            sprite = Resources.Load<Sprite>("Sprites/RoadSprites/B");
        }
        else if (roadType == roadTypes.Trt)
        {
            tiles[coordX + 1, coordY].updateType(tileTypes.road);
            tiles[coordX + 1, coordY].road = roadType;

            tiles[coordX + 2, coordY + 1].updateType(tileTypes.road);
            tiles[coordX + 2, coordY + 1].road = roadType;

            tiles[coordX + 1, coordY + 2].updateType(tileTypes.road);
            tiles[coordX + 1, coordY + 2].road = roadType;

            sprite = Resources.Load<Sprite>("Sprites/RoadSprites/D");
        }
        else if (roadType == roadTypes.Fr)
        {
            tiles[coordX + 1, coordY].updateType(tileTypes.road);
            tiles[coordX + 1, coordY].road = roadType;

            tiles[coordX, coordY + 1].updateType(tileTypes.road);
            tiles[coordX, coordY + 1].road = roadType;

            tiles[coordX + 2, coordY + 1].updateType(tileTypes.road);
            tiles[coordX + 2, coordY + 1].road = roadType;

            tiles[coordX + 1, coordY + 2].updateType(tileTypes.road);
            tiles[coordX + 1, coordY + 2].road = roadType;

            sprite = Resources.Load<Sprite>("Sprites/RoadSprites/A.png");
        }
        else//?
        {
                    
        }
        spriteRenderer.sprite = sprite;
        Instantiate(road, new Vector2(x * 150, y * 150), Quaternion.identity);
    }
    public void GenerateMap()
    {
        for (int y = 0; y < _y * 3; y++)
        {
            for (int x = 0; x < _x * 3; x++)
            {
                if (mod(x) == 0 && mod(y) == 0 && x > 0 && y > 0)
                {
                    leftBottom(x, y);
                }
                else if (mod(x) == 1 && mod(y) == 0 && x > 0 && y > 0)
                {
                    midBottom(x, y);
                }
                else if (mod(x) == 2 && mod(y) == 0 && x > 0 && y > 0)
                {
                    rightBottom(x, y);
                }
                else if (mod(x) == 0 && mod(y) == 1 && x > 0 && y > 0)
                {
                    leftMid(x, y);
                }
                else if (mod(x) == 1 && mod(y) == 1 && x > 0 && y > 0)
                {
                    midMid(x, y);
                }
                else if (mod(x) == 2 && mod(y) == 1 && x > 0 && y > 0)
                {
                    rightMid(x, y);
                }
                else if (mod(x) == 0 && mod(y) == 2 && x > 0 && y > 0)
                {
                    leftTop(x, y);
                }
                else if (mod(x) == 1 && mod(y) == 2 && x > 0 && y > 0)
                {
                    midTop(x, y);
                }
                else if (mod(x) == 2 && mod(y) == 2 && x > 0 && y > 0)
                {
                    rightTop(x, y);
                }
                else
                {
                    tiles[x, y].type = tileTypes.none;
                }
                //Fill edges
                if (x == 0 || y == 0 || x == 29 || y == 29)
                {
                    tiles[x, y].type = tileTypes.building;
                }
            }
        }
    }

    void leftBottom(int x, int y)
    {
        if (tiles[x - 1, y].type == tileTypes.freezone)
        {
            if (tiles[x - 1, y].freezone == freezoneTypes.ltCorner)
            {
                tiles[x, y].updateType(tileTypes.freezone);
                if (tiles[x, y - 1].freezone == freezoneTypes.horizontalSide)
                {
                    tiles[x, y].freezone = freezoneTypes.horizontalSide;
                }
                else//?
                {
                    tiles[x, y].freezone = freezoneTypes.rtCorner;
                }
            }
            else if (tiles[x - 1, y].freezone == freezoneTypes.lbCorner)
            {
                tiles[x, y].updateType(tileTypes.freezone);
                tiles[x, y].freezone = freezoneTypes.rbCorner;
            }
            else if (tiles[x - 1, y].freezone == freezoneTypes.rtCorner)
            {
                tiles[x, y].updateType(tileTypes.building);
            }
            else if (tiles[x - 1, y].freezone == freezoneTypes.rbCorner)
            {
                tiles[x, y].updateType(tileTypes.building);
            }
            else if (tiles[x - 1, y].freezone == freezoneTypes.verticalSide)
            {
                tiles[x, y].updateType(tileTypes.freezone);
                tiles[x, y].freezone = freezoneTypes.verticalSide;
            }
            else if (tiles[x - 1, y].freezone == freezoneTypes.horizontalSide)
            {
                tiles[x, y].updateType(tileTypes.freezone);
                if (tiles[x, y - 1].freezone == freezoneTypes.horizontalSide)
                {
                    tiles[x, y].freezone = freezoneTypes.horizontalSide;
                }
                else//?
                {
                    tiles[x, y].freezone = freezoneTypes.rtCorner;
                }
            }
        }
        else if (tiles[x, y - 1].type == tileTypes.freezone)
        {
            if (tiles[x, y - 1].freezone == freezoneTypes.lbCorner)
            {
                tiles[x, y].updateType(tileTypes.freezone);
                tiles[x, y].freezone = freezoneTypes.ltCorner;
            }
            else
            {
                tiles[x, y].updateType(tileTypes.building);
            }
        }
        else
        {
            tiles[x, y].updateType(tileTypes.building);
        }
    }
    void midBottom(int x, int y)
    {
        if (tiles[x - 1, y].type == tileTypes.freezone)
        {
            if (tiles[x - 1, y].freezone == freezoneTypes.ltCorner)
            {
                tiles[x, y].updateType(tileTypes.freezone);
                if (tiles[x, y - 1].freezone == freezoneTypes.horizontalSide)
                {
                    tiles[x, y].freezone = freezoneTypes.horizontalSide;
                }
                else//?
                {
                    tiles[x, y].freezone = freezoneTypes.rtCorner;
                }
            }
            else if (tiles[x - 1, y].freezone == freezoneTypes.lbCorner)//?
            {
                tiles[x, y].updateType(tileTypes.building);
            }
            else if (tiles[x - 1, y].freezone == freezoneTypes.rtCorner)
            {
                tiles[x, y].updateType(tileTypes.building);
            }
            else if (tiles[x - 1, y].freezone == freezoneTypes.rbCorner)
            {
                tiles[x, y].updateType(tileTypes.building);
            }
            else if (tiles[x - 1, y].freezone == freezoneTypes.verticalSide)
            {
                tiles[x, y].updateType(tileTypes.building);
            }
            else if (tiles[x - 1, y].freezone == freezoneTypes.horizontalSide)
            {
                tiles[x, y].updateType(tileTypes.freezone);
                if (tiles[x, y - 1].freezone == freezoneTypes.horizontalSide)
                {
                    tiles[x, y].freezone = freezoneTypes.horizontalSide;
                }
                else//?
                {
                    tiles[x, y].freezone = freezoneTypes.rtCorner;
                }
            }
        }
        else if (tiles[x, y - 1].type == tileTypes.freezone)
        {
            if (tiles[x, y - 1].freezone == freezoneTypes.lbCorner)
            {
                tiles[x, y].updateType(tileTypes.freezone);
                tiles[x, y].freezone = freezoneTypes.ltCorner;
            }
            else//?
            {
                tiles[x, y].updateType(tileTypes.building);
            }
        }
        else
        {
            tiles[x, y].updateType(tileTypes.building);
        }
    }
    void rightBottom(int x, int y)
    {
        if (tiles[x - 1, y].type == tileTypes.freezone)
        {
            if (tiles[x - 1, y].freezone == freezoneTypes.ltCorner)
            {
                tiles[x, y].updateType(tileTypes.freezone);
                if (tiles[x, y - 1].freezone == freezoneTypes.horizontalSide)
                {
                    tiles[x, y].freezone = freezoneTypes.horizontalSide;
                }
                else//?
                {
                    tiles[x, y].freezone = freezoneTypes.rtCorner;
                }
            }
            else if (tiles[x - 1, y].freezone == freezoneTypes.lbCorner)//?
            {
                tiles[x, y].updateType(tileTypes.building);
            }
            else if (tiles[x - 1, y].freezone == freezoneTypes.rtCorner)
            {
                tiles[x, y].updateType(tileTypes.building);
            }
            else if (tiles[x - 1, y].freezone == freezoneTypes.rbCorner)
            {
                tiles[x, y].updateType(tileTypes.building);
            }
            else if (tiles[x - 1, y].freezone == freezoneTypes.verticalSide)//?
            {
                tiles[x, y].updateType(tileTypes.building);
            }
            else if (tiles[x - 1, y].freezone == freezoneTypes.horizontalSide)
            {
                tiles[x, y].updateType(tileTypes.freezone);
                if (tiles[x, y - 1].freezone == freezoneTypes.horizontalSide)
                {
                    tiles[x, y].freezone = freezoneTypes.horizontalSide;
                }
                else//?
                {
                    tiles[x, y].freezone = freezoneTypes.rtCorner;
                }
            }
        }
        else if (tiles[x, y - 1].type == tileTypes.freezone)
        {
            if (tiles[x, y - 1].freezone == freezoneTypes.lbCorner)
            {
                int random = Random.Range(0, 10);
                tiles[x, y].updateType(tileTypes.freezone);
                if(random > 3)
                {
                    tiles[x, y].freezone = freezoneTypes.ltCorner;
                }
                else
                {
                    tiles[x, y].freezone = freezoneTypes.verticalSide;
                }
            }
            else if(tiles[x, y - 1].freezone == freezoneTypes.verticalSide)
            {
                int random = Random.Range(0, 10);
                tiles[x, y].updateType(tileTypes.freezone);
                if (random > 1)
                {
                    tiles[x, y].freezone = freezoneTypes.ltCorner;
                }
                else
                {
                    tiles[x, y].freezone = freezoneTypes.verticalSide;
                }
            }
            else
            {
                tiles[x, y].updateType(tileTypes.building);
            }
        }
        else
        {
            int random = Random.Range(0, 10);
            if (random > 2)
            {
                tiles[x, y].updateType(tileTypes.building);
            }
            else
            {
                tiles[x, y].updateType(tileTypes.freezone);
                tiles[x, y].freezone = freezoneTypes.lbCorner;
            }
        }
    }
    void leftMid(int x, int y)
    {
        if (tiles[x - 1, y].type == tileTypes.freezone)
        {
            if (tiles[x - 1, y].freezone == freezoneTypes.ltCorner)
            {
                tiles[x, y].updateType(tileTypes.freezone);
                if (tiles[x, y - 1].freezone == freezoneTypes.horizontalSide)
                {
                    tiles[x, y].freezone = freezoneTypes.horizontalSide;
                }
                else//?
                {
                    tiles[x, y].freezone = freezoneTypes.rtCorner;
                }
            }
            else if (tiles[x - 1, y].freezone == freezoneTypes.lbCorner)
            {
                tiles[x, y].updateType(tileTypes.freezone);
                tiles[x, y].freezone = freezoneTypes.rbCorner;
            }
            else if (tiles[x - 1, y].freezone == freezoneTypes.rtCorner)
            {
                tiles[x, y].updateType(tileTypes.building);
            }
            else if (tiles[x - 1, y].freezone == freezoneTypes.rbCorner)
            {
                tiles[x, y].updateType(tileTypes.building);
            }
            else if (tiles[x - 1, y].freezone == freezoneTypes.verticalSide)
            {
                tiles[x, y].updateType(tileTypes.freezone);
                tiles[x, y].freezone = freezoneTypes.verticalSide;
            }
            else if (tiles[x - 1, y].freezone == freezoneTypes.horizontalSide)
            {
                tiles[x, y].updateType(tileTypes.building);
            }
        }
        else
        {
          tiles[x, y].updateType(tileTypes.building);
        }
    }
    void midMid(int x, int y)
    {
        tiles[x, y].type = tileTypes.road;
    }
    void rightMid(int x, int y)
    {
        if (tiles[x, y - 1].type == tileTypes.freezone)
        {
            if (tiles[x, y - 1].freezone == freezoneTypes.ltCorner)
            {
                tiles[x, y].updateType(tileTypes.building);
            }
            else if (tiles[x, y - 1].freezone == freezoneTypes.lbCorner)
            {
                int random = Random.Range(0, 10);
                if (random > 3)
                {
                    tiles[x, y].updateType(tileTypes.freezone);
                    tiles[x, y].freezone = freezoneTypes.ltCorner;
                }
                else
                {
                    tiles[x, y].updateType(tileTypes.freezone);
                    tiles[x, y].freezone = freezoneTypes.verticalSide;
                }
            }
            else if (tiles[x, y - 1].freezone == freezoneTypes.rtCorner)
            {
                tiles[x, y].updateType(tileTypes.building);
            }
            else if (tiles[x, y - 1].freezone == freezoneTypes.rbCorner)//?
            {
                tiles[x, y].updateType(tileTypes.building);
            }
            else if (tiles[x, y - 1].freezone == freezoneTypes.verticalSide)
            {
                int random = Random.Range(0, 10);
                if (random > 2)
                {
                    tiles[x, y].updateType(tileTypes.freezone);
                    tiles[x, y].freezone = freezoneTypes.ltCorner;
                }
                else
                {
                    tiles[x, y].updateType(tileTypes.freezone);
                    tiles[x, y].freezone = freezoneTypes.verticalSide;
                }
            }
            else if (tiles[x, y - 1].freezone == freezoneTypes.horizontalSide)
            {
                tiles[x, y].updateType(tileTypes.building);
            }
        }
        else
        {
            int random = Random.Range(0, 10);
            if (random > 2)
            {
                tiles[x, y].updateType(tileTypes.building);
            }
            else
            {
                tiles[x, y].updateType(tileTypes.freezone);
                tiles[x, y].freezone = freezoneTypes.lbCorner;
            }
        }
    }
    void leftTop(int x, int y)
    {

    }
    void midTop(int x, int y)
    {

    }
    void rightTop(int x, int y)
    {

    }
    int mod(int number)
    {
        return (number % 3);
    }

    public void brushTiles()
    {
        Color color1 = new Color(0.46f, 0.58f, 0.33f);
        Color color2 = new Color(0.48f, 0.70f, 0.65f);
        Color color3 = new Color(0.93f, 0.93f, 0.82f);
        Color color4 = new Color(0.99f, 1.0f, 0.83f);
        int a = 0;
        int b = 0;
        for (int x = 0; x < _x; x++)
        {
            for (int y = 0; y < _y; y++)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (b % 2 == 0)
                        {
                            if (a % 2 == 0)
                            {
                                tiles[x * 3 + i, y * 3 + j].GetComponent<SpriteRenderer>().color = color1;
                            }
                            else
                            {
                                tiles[x * 3 + i, y * 3 + j].GetComponent<SpriteRenderer>().color = color2;
                            }
                        }
                        else
                        {
                            if (a % 2 == 0)
                            {
                                tiles[x * 3 + i, y * 3 + j].GetComponent<SpriteRenderer>().color = color3;
                            }
                            else
                            {
                                tiles[x * 3 + i, y * 3 + j].GetComponent<SpriteRenderer>().color = color4;
                            }
                        }
                        b++;
                    }
                }
                a++;
            }
            a++;
            b++;
        }

    }
}
