using UnityEngine;

public class BrickScript : MonoBehaviour
{
    private TetrominoScript tetrominoScript;

    private void Start()
    {
        tetrominoScript = GetComponentInParent<TetrominoScript>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("Collision detected with " + collision.gameObject.name);
        if (collision.gameObject.tag == "Ground")
        {
            try
            {
                tetrominoScript.hasLanded = true;
            }
            catch (System.NullReferenceException)
            {
                collision.gameObject.GetComponentInParent<TetrominoScript>().hasLanded = true;
                collision.gameObject.GetComponentInParent<TetrominoScript>().isCurrentTetromino = false;
            }

        }
    }
}
