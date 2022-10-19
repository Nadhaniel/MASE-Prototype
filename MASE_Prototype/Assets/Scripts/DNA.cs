using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA : MonoBehaviour
{
    public Dictionary<bool, float> genes;
    int dnaLength;

    public DNA()
    {
        genes = new Dictionary<bool, float>();
        SetRandom();
    }

    public void SetRandom() 
    {
        genes.Clear();
        genes.Add(false, Random.Range(-90, 91));
        genes.Add(true, Random.Range(-90, 91));
        dnaLength = genes.Count;
    }

    public void Combine(DNA d1, DNA d2)
    {
        int i = 0;
        Dictionary<bool, float> combinedGenes = new Dictionary<bool, float>();
        foreach (KeyValuePair<bool, float> gene in genes)
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

    public float getGene(bool front)
    {
        return genes[front];
    }
}
