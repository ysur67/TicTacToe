using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T3Controller : MonoBehaviour
{
    [SerializeField] private Tile originalTile;
    [SerializeField] private Sprite image;

    public int gridCols = 3;
    public int gridRows = 3;

    public float offsetX = 2.0f;
    public float offsetY = 2.5f;

    private void Start()
    {
        Vector3 startPos = originalTile.transform.position;
        SetUpGrid(startPos);
    }
    private void SetUpGrid(Vector3 startPos)
    {
        int index = 0;
        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                Tile tile;
                if (i == 0 && j == 0)
                    tile = originalTile;
                else
                    tile = Instantiate(originalTile) as Tile;
                index++;
                tile.SetTile(index, image);

                float posX = (offsetX * i) + startPos.x;
                float posY = (offsetY * j) + startPos.y;
                tile.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }
    }

    private void Awake()
    {
        Messenger.AddListener(GameEvent.PLAYER_TURN, OnPlayerTurn);
    }


    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.PLAYER_TURN, OnPlayerTurn);
    }

    private void OnPlayerTurn()
    {

    }

}
