using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private int _x, _y;
    private int posX, posY;
    private int _width, _height;
    private SpriteRenderer _renderer;

    public bool isRoad;
    public bool isFreezone;

    public enum tileTypes
    {
        none, road, freezone, building
    }
    public enum roadTypes
    {
        none,
        Fr, 
        Trt, 
        Trb, 
        Trr, 
        Trl, 
        Lrrb, 
        Lrrt, 
        Lrlb, 
        Lrlt, 
        Drt, 
        Drb,
        Drl,
        Drr,
        Srrl,
        Srtb,
    }
    public enum freezoneTypes
    {
        none, lbCorner, rbCorner, ltCorner, rtCorner, verticalSide, horizontalSide
    }

    public tileTypes type;
    public roadTypes road;
    public freezoneTypes freezone;
    public void CreateTile(int posx, int posy, int width, int height, int x, int y)
    {
        posX = posx;
        posY = posy;
        _width = width;
        _height = height;
        _x = x;
        _y = y;
    }

    public void updateType(tileTypes tileType)
    {
        type = tileType;
        if(type == tileTypes.building)
        {
            road = roadTypes.none;
            freezone = freezoneTypes.none;
        }
        else if(type == tileTypes.road) 
        {
            freezone = freezoneTypes.none;
        }
        else if(type == tileTypes.freezone)
        {
            road = roadTypes.none;
        }
    }
}
