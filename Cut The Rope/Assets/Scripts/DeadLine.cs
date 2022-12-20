using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadLine : MonoBehaviour
{
    [SerializeField] private Transform Left;
    [SerializeField] private Transform Right;
    [SerializeField] private Transform Down;
    [SerializeField] private Transform Ball;

    void Update()
    {
        if(Left.position.x > Ball.position.x || Right.position.x < Ball.position.x || Down.position.y > Ball.position.y)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
}
