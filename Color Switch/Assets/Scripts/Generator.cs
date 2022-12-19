using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject Lines;
    public GameObject ReverseLines;
    public GameObject SmallCircle;
    public GameObject BigCircle;
    public GameObject ColorChanger;
     public GameObject Bonus;
    private float temp = 0;
    private float Distanse = 0;

    public Transform player;

    void Start()
    {
        Instantiate(SmallCircle, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(Bonus, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(ColorChanger, new Vector3(0, 4f, 0), Quaternion.identity);
        Instantiate(BigCircle, new Vector3(0, 8f, 0), Quaternion.identity);
        Instantiate(Bonus, new Vector3(0, 8f, 0), Quaternion.identity);
        Instantiate(ColorChanger, new Vector3(0, 12f, 0), Quaternion.identity);
    }

    void Update()
    {
            Distanse = player.position.y - temp;
            
            if (Distanse >= 8f)
            {
                CreateObject();
                temp = player.position.y;
            }
    }

    public void CreateObject()
    {
        switch (Random.Range(0, 5))
            {
                 case 0:
                    Instantiate(SmallCircle, new Vector3(0, player.position.y + 8f, 0), Quaternion.identity);
                 break;
                 case 1:
                    Instantiate(BigCircle, new Vector3(0, player.position.y + 8f, 0), Quaternion.identity);
                 break;
                 case 2:
                    Instantiate(Lines, new Vector3(-1.3f, player.position.y + 8f, 0), Quaternion.identity);
                 break;
                 case 3:
                    Instantiate(ReverseLines, new Vector3(1.3f, player.position.y + 8f, 0), Quaternion.identity);
                 break;
                 case 4:
                    Instantiate(Lines, new Vector3(- 1.8f, player.position.y + 8f, 0), Quaternion.identity);
                    Instantiate(ReverseLines, new Vector3(1.8f, player.position.y + 8f, 0), Quaternion.identity);
                 break;
            }
        Instantiate(Bonus, new Vector3(0, player.position.y + 8f, 0), Quaternion.identity);
        Instantiate(ColorChanger, new Vector3(0, player.position.y + 12f, 0), Quaternion.identity);
    }
}
