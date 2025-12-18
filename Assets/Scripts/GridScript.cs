using UnityEngine;

public class GridScript : MonoBehaviour
{
    public int width, height;
    public Transform[,] grid;
    public GameObject[] dumb_tetrominos;

    public GameManagerScript gameManager;
    public void LandTetromino(Transform finalPosition, string tetrominoName)
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (grid[x, y] != null)
                {
                    if (grid[x, y].parent == gameManager.currentTetromino)
                    {

                    }
                }
            }
        }
        foreach (Transform brick in gameManager.currentTetromino.transform)
        {
            int x = Mathf.RoundToInt(brick.position.x);
            int y = Mathf.RoundToInt(brick.position.y);
            grid[x, y] = brick;
        }
        
        Destroy(gameManager.currentTetromino);
        Instantiate(dumb_tetrominos[int.Parse(tetrominoName)], finalPosition.position, finalPosition.rotation);
        Debug.Log(grid);

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dumb_tetrominos = Resources.LoadAll<GameObject>("Tetrominos");
        grid = new Transform[10, 20];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
