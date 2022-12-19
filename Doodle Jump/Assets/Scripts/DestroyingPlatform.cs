using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyingPlatform : MonoBehaviour
{
   public GameObject player;

    void Start()
    {
        player = GameObject.Find("Doodler");
    }

    void Update()
    {
        if ((player.transform.position.y - transform.position.y) > 8) 
        {
            Destroy(gameObject);
        }
    }
}
