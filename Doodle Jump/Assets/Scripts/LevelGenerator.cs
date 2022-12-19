using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
	public GameObject platformPrefab;
	public int numberOfPlatforms = 10;
	public float levelwidth = 3f;
	public float minY = .2f;
	public float maxY = 1.5f;

	private float temp = 0;
    private float Distanse = 0;

    public Transform player;

    void Start()
    {

		Vector3 spawnPosition = new Vector3();

		for (int i = 0; i < 20; i++) {
			spawnPosition.y += Random.Range (minY, maxY);
			spawnPosition.x = Random.Range (-levelwidth, levelwidth);
			Instantiate (platformPrefab, spawnPosition, Quaternion.identity);
		}
        
    }

     void Update()
    {
            Distanse = player.position.y - temp;
            Debug.Log(Distanse);
            if (Distanse >= 8f)
            {
                CreatePlatform();
                temp = player.position.y;
            }
    }

    public void CreatePlatform()
    {
    	Vector3 spawnPosition = new Vector3();
    	spawnPosition.y = player.position.y + 8f;
    	for (int i = 0; i < numberOfPlatforms; i++) {
			spawnPosition.y += Random.Range (minY, maxY);
			spawnPosition.x = Random.Range (-levelwidth, levelwidth);
			Instantiate (platformPrefab, spawnPosition, Quaternion.identity);
		}
    }
}