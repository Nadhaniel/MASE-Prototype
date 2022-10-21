using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    public DNA dna;
    public GameObject Agent;
    bool seeFood;
    (bool left, bool forward, bool right) seeWall;
    public float FoodFound = 0;
    LayerMask ignore = 6;
    bool canMove = false;

    public void Init()
    {
        dna = new DNA();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("apple"))
        {    
            FoodFound++;
            Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        seeWall = (false, false, false);
        bool left = false;
        bool front = false;
        bool right = false;
        canMove = true;
        Debug.DrawRay(Agent.transform.position, Agent.transform.right * 1f, Color.black);
        RaycastHit2D hitr = Physics2D.Raycast(Agent.transform.position, Agent.transform.right, 1f, ~ignore);
        RaycastHit2D hitl = Physics2D.Raycast(Agent.transform.position, -Agent.transform.right, 1f, ~ignore);
        RaycastHit2D hit = Physics2D.Raycast(Agent.transform.position, Agent.transform.up, 1f, ~ignore);
        if (hitr.collider != null)
        {
            if (hitr.collider.CompareTag("wall"))
            {
                right = true;
            }
        }
        if (hitl.collider != null)
        {
            if (hitl.collider.CompareTag("wall"))
            {
                left = true;
            }
        }
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("wall"))
            {
                front = true;
                canMove = false;
            }
        }
        seeWall = (left, front, right);
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
