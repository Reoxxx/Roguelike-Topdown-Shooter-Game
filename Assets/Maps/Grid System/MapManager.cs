using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Tile;
using Random = UnityEngine.Random;

public class MapManager : MonoBehaviour
{
    // Start is called before the first frame update    
    public List<Tile.roadTypes> roads;
    public List<Tile.roadTypes> lastRow;
    public GridManager gridManager;
    void Start()
    {
        roads = new List<Tile.roadTypes>();
        lastRow = new List<Tile.roadTypes>();
        createRoads();
        gridManager.GetComponent<GridManager>().GenerateGrid();
        gridManager.GetComponent<GridManager>().brushTiles();
        gridManager.GetComponent<GridManager>().GenerateMap();
    }

    private void createRoads()
    {     
        for (int y = 0; y < 10; y++)
        {
            List<Tile.roadTypes> roadLine = new List<Tile.roadTypes>(); ;
            for (int x = 0; x < 10; x++)
            {
                if (y == 0)
                {
                    if (x == 0)
                    {
                        roadLine.Add(roadTypes.Lrrt);
                        DrawRoad(roadLine.Last(), x, y);
                    }                      
                    else if (x == 9)
                        roadLine.Add(roadTypes.Lrlt);
                    else
                    {
                        if (roadLine.Last() == roadTypes.Lrrt || roadLine.Last() == roadTypes.Trt || roadLine.Last() == roadTypes.Drr || roadLine.Last() == roadTypes.Srrl)
                        {
                            if (roadLine.Last() == roadTypes.Drr)
                            {
                                List<roadTypes> types = new List<roadTypes>
                                {
                                roadTypes.Lrlt,
                                roadTypes.Srrl,
                                roadTypes.Trt,
                                };
                                roadLine.Add(randomMap(types));
                            }
                            else
                            {
                                List<roadTypes> types = new List<roadTypes>
                                {
                                roadTypes.Lrlt,
                                roadTypes.Srrl,
                                roadTypes.Trt,
                                roadTypes.Drl
                                };
                                roadLine.Add(randomMap(types));

                            }
                        }
                        else if (roadLine.Last() == roadTypes.Drl || roadLine.Last() == roadTypes.Lrlt || roadLine.Last() == roadTypes.Drt)
                        {
                            List<roadTypes> types = new List<roadTypes>
                                {                                
                                roadTypes.Lrrt,
                                roadTypes.Fr,
                                roadTypes.Drr
                                };
                            roadLine.Add(randomMap(types));
                        }
                        else
                        {
                            List<roadTypes> types = new List<roadTypes>
                                {
                                roadTypes.Trt,
                                roadTypes.Lrrt,
                                roadTypes.Lrlt,
                                roadTypes.Drr,
                                roadTypes.Drl,
                                roadTypes.Drt,
                                roadTypes.Srrl,
                                };
                            roadLine.Add(randomMap(types));
                        }
                    }
                }
            }

            roads = roadLine;
            lastRow = roadLine;
        }        
    }

    private void DrawRoad(roadTypes roadTypes, int x, int y)
    {
<<<<<<< Updated upstream
        throw new NotImplementedException();
=======
        gridManager.GetComponent<GridManager>().DrawRoad(x, y, roadType);      
>>>>>>> Stashed changes
    }

    public static roadTypes randomMap(List<roadTypes> roadTypes)
    {     
        var index = Random.Range(0, roadTypes.Count);
        return roadTypes[index];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
