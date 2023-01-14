using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPhysics : MonoBehaviour
{
    AIManager manager;
    private void Awake()
    {
        manager = GetComponent<AIManager>();
    }
    //Hangi tarafta olduðunu anlamak için
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("LeftFieldLayer"))
        {
            manager.SetLayer = false;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("RightFieldLayer"))
        {
            manager.SetLayer = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LazerTag"))
        {
            manager.LeftSideBool = false;
            manager.RightSideBool = false;
        }
    }
}
