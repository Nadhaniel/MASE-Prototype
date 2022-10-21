using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    public GameObject Food;
    public int foodlimit = 50;
    public int foodcount = 0;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(FoodWave());
    }
    private void spawnFood() {
        GameObject obj = Instantiate(Food) as GameObject;
        obj.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), Random.Range(-screenBounds.y, screenBounds.y));  
    }

    IEnumerator FoodWave() {
        while (true) {
            yield return new WaitForSeconds(respawnTime);
            spawnFood();
        }
        
    }
}
