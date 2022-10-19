using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Population : MonoBehaviour
{
    public GameObject creature;
    public GameObject[] startingPos;
    public int popSize = 50;
    List<GameObject> population = new List<GameObject>();
    public static float elapsed = 0;
    public float trialTime = 10;
    public float timeScale = 2;
    int generation = 1;

    GUIStyle guiStyle = new GUIStyle();

    void OnGUI()
    {
        guiStyle.fontSize = 25;
        guiStyle.normal.textColor = Color.black;
        GUI.BeginGroup(new Rect(10, 10, 250, 150));
        GUI.Box(new Rect(0, 0, 140, 140), "Stats", guiStyle);
        GUI.Label(new Rect(10, 25, 200, 30), "Gen: " + generation, guiStyle);
        GUI.Label(new Rect(10, 50, 200, 30), string.Format("Time : {0:0.00}", elapsed), guiStyle);
        GUI.Label(new Rect(10, 75, 200, 30), "Population: " + population.Count, guiStyle);
        GUI.EndGroup();
    }

    private void Start()
    {
        for (int i = 0; i < popSize; i++)
        {
            GameObject b = Instantiate(creature, this.transform.position, this.transform.rotation);
            b.transform.Rotate(0, Mathf.Round(Random.Range(-90, 91) / 90) * 90, 0);
            population.Add(b);
        }
        Time.timeScale = timeScale;
    }

    GameObject Breed(GameObject parent1, GameObject parent2)
    {
        return null;
    }

    void BreedNewPopulation()
    {
        
    }


    private void FixedUpdate()
    {
        
    }
}
