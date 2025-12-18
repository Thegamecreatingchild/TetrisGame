using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject[] tetrominos;

    public GameObject currentTetromino;

    public GridScript gridScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tetrominos = Resources.LoadAll<GameObject>("Smart_Tetrominos");
        SpawnTetromino();
    }

    public void SpawnTetromino()
    {
        int randomIndex = Random.Range(0, tetrominos.Length);
        currentTetromino = Instantiate(tetrominos[randomIndex], new Vector3(5, 20, 0), Quaternion.identity);
        currentTetromino.name = randomIndex.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
