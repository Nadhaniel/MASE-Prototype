using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            b.GetComponent<Brain>().Init();
            population.Add(b);
        }
        Time.timeScale = timeScale;
    }

    GameObject Breed(GameObject parent1, GameObject parent2)
    {
        GameObject offspring = Instantiate(creature, this.transform.position, this.transform.rotation);
        offspring.transform.Rotate(0, Mathf.Round(Random.Range(-90, 91) / 90) * 90, 0);
        Brain b = offspring.GetComponent<Brain>();
        if (Random.Range(0, 100) == 1) //mutate
        {
            b.Init();
        }
        else {
            b.Init();
            b.dna.Combine(parent1.GetComponent<Brain>().dna, parent2.GetComponent<Brain>().dna);
        }
        return offspring;
    }

    void BreedNewPopulation()
    {
        List<GameObject> sortedlist = population.OrderByDescending(o => o.GetComponent<Brain>().FoodFound).ToList();

        string foodfound = "Generation: " + generation;
        foreach (GameObject g in sortedlist)
        {
            foodfound += ", " + g.GetComponent<Brain>().FoodFound;
        }
        Debug.Log("Food: " + foodfound);
        population.Clear();

        while (population.Count < popSize)
        {
            int bestParentCutoff = sortedlist.Count / 4;
            for (int i = 0; i < bestParentCutoff - 1; i++) {
                for(int j = 1; j < bestParentCutoff; j++)
                {
                    population.Add(Breed(sortedlist[i], sortedlist[j]));
                    if (population.Count == popSize) break;
                    population.Add(Breed(sortedlist[j], sortedlist[i]));
                    if (population.Count == popSize) break;
                }
                if (population.Count == popSize) break;
            }
        }
        for(int i = 0; i < sortedlist.Count; i++)
        {
            Destroy(sortedlist[i]);
        }
        generation++;
    }


    private void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= trialTime)
        {
            BreedNewPopulation();
            elapsed = 0;
        }
    }
}
