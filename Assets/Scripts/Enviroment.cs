using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enviroment : MonoBehaviour
{
    [SerializeField]
    private GameObject m_WallObj;
    [SerializeField]
    GameObject GrassTile;
    [SerializeField]
    GameObject DirtTile;
    private float m_TileSpacing;
    [SerializeField]
    private int m_TileWidth;
    [SerializeField]
    private int m_TileHeight;

    private GameObject CurrentTile;

    // Start is called before the first frame update
    void Start()
    {

        m_TileSpacing = 0.249f; // calculated after manually comparing positions between two adjacent tiles
        for (int x = 0; x < m_TileWidth; x++)
        {


            for (int y = 0; y < m_TileHeight; y++)
            {
                if (y == 0)
                {
                    CurrentTile = GrassTile;
                }
                else
                {
                    CurrentTile = DirtTile;
                }
                GameObject newTile = Instantiate(CurrentTile, (new Vector3(GrassTile.transform.position.x +
                    (m_TileSpacing * x),
                GrassTile.transform.position.y - (m_TileSpacing * y),
                GrassTile.transform.position.z)), new Quaternion(0, 0, 0, 0), m_WallObj.transform);
                newTile.name = x + "," + y;
            }
        }
        Destroy(GrassTile);
    }
}

