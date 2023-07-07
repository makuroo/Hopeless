using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Finish : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.ChangeScene(SceneManager.GetActiveScene().buildIndex+1);
            GameManager.Instance.ChangeLevel(GameManager.Instance.levelCurrent+1);
        }
    }
}
