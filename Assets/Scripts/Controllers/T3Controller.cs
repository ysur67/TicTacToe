using UnityEngine;
using UnityEngine.SceneManagement;

public class T3Controller : MonoBehaviour
{
    [SerializeField] private Tile originalTile;
    [SerializeField] private Sprite image;
    [SerializeField] private GameOverMenu gameOverMenu;

    public int gridCols = 3;
    public int gridRows = 3;

    public float offsetX = 2.0f;
    public float offsetY = 2.5f;

    public void RaiseWin(PlayerBase player)
    {
        gameOverMenu.Open();
        gameOverMenu.SetTitle($"Player {player.username} has won the game!");
    }
    
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void Start()
    {
        SetUpGrid();
        gameOverMenu.Close();
    }

    private void SetUpGrid()
    {
        Vector3 startPos = originalTile.transform.position;
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
                Vector2 gridPosition = new Vector2(j, i);
                tile.SetTile(index, image, gridPosition);
                float posX = (offsetX * i) + startPos.x;
                float posY = (offsetY * j) + startPos.y;
                tile.transform.position = new Vector3(posX, posY, startPos.z);
                index++;
            }
        }
    }
}
