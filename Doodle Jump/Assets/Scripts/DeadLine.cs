using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadLine : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
            Debug.Log ("GAME OVER!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
