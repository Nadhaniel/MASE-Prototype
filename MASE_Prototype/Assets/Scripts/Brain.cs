using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    public DNA dna;
    public GameObject Agent;
    bool seeFood;
    bool seeWall;
    public float FoodFound = 0;
    LayerMask ignore = 6;
    bool canMove = false;

    private void Start()
    {
        dna = new DNA();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("apple"))
        {
            FoodFound++;
            other.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        seeWall = false;
        canMove = true;
        Debug.DrawRay(Agent.transform.position, Agent.transform.right * 1f, Color.black);
        RaycastHit2D hit = Physics2D.Raycast(Agent.transform.position, Agent.transform.right, 1f);
        Debug.Log(hit.collider.gameObject.tag);
        if (hit.collider.gameObject.CompareTag("wall"))
        {
            seeWall = true;
            canMove = false;
        }
    }
    private void FixedUpdate()
    {
        this.transform.Rotate(0, 0, dna.genes[seeWall]);
        if (canMove)
        {
            this.transform.Translate(0.05f, 0, 0);
        }
    }
}
