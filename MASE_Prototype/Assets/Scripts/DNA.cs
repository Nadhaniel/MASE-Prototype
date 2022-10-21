using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA : MonoBehaviour
{
    public Dictionary<(bool left, bool forward, bool right), float> genes;
    int dnaLength;

    public DNA()
    {
        genes = new Dictionary<(bool left, bool forward, bool right), float>();
        SetRandom();
    }

    public void SetRandom() 
    {
        genes.Clear();
        genes.Add((false, false, false), Random.Range(-90, 91));
        genes.Add((false, false, true), Random.Range(-90, 91));
        genes.Add((false, true, true), Random.Range(-90, 91));
        genes.Add((true, true, true), Random.Range(-90, 91));
        genes.Add((true, false, false), Random.Range(-90, 91));
        genes.Add((true, false, true), Random.Range(-90, 91));
        genes.Add((false, true, false), Random.Range(-90, 91));
        genes.Add((true, true, false), Random.Range(-90, 91));
        dnaLength = genes.Count;
    }

    public void Combine(DNA d1, DNA d2)
    {
        int i = 0;
        Dictionary<(bool left, bool forward, bool right), float> combinedGenes = new Dictionary<(bool left, bool forward, bool right), float>();
        foreach (KeyValuePair<(bool left, bool forward, bool right), float> gene in genes)
        {
            if (i < dnaLength / 2)
            {
                combinedGenes.Add(gene.Key, d1.genes[gene.Key]);
            }
            else
            {
                combinedGenes.Add(gene.Key, d2.genes[gene.Key]);
            }
            i++;
        }
        genes = combinedGenes;
    }

    public float getGene((bool left, bool forward, bool right) seeWall)
    {
        return genes[seeWall];
    }
}
