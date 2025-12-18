using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class TetrominoScript : MonoBehaviour
{
    [Header("Physics")]
    public float movementFrequency = 0.8f;
    public float passedTime = 0;

    [Header("Logic")]
    public bool isCurrentTetromino = false;
    public bool hasLanded = false;

    [Header("Script References")]
    [SerializeField] private GameManagerScript gameManager;
    [SerializeField] private GridScript gridScript;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        gridScript = GameObject.Find("Grid").GetComponent<GridScript>();
        isCurrentTetromino = true;
    }

    void UserInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gameObject.transform.position += Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gameObject.transform.position += Vector3.right;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.transform.position += Vector3.down;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            gameObject.transform.Rotate(0, 0, 90);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            movementFrequency = 0.005f;
        }
        else
        {
            movementFrequency = 0.8f;
        }
    }

    void Update()
    {
        if (!hasLanded)
        {
            UserInput();
            passedTime += Time.deltaTime;
            if (passedTime >= movementFrequency)
            {
                passedTime -= movementFrequency;
                gameObject.transform.position += Vector3.down;
            }
        } 
        else
        {
            isCurrentTetromino = false;
            gridScript.LandTetromino(gameObject.transform, gameObject.name);
            gameManager.SpawnTetromino();
        }
            
    }
}
