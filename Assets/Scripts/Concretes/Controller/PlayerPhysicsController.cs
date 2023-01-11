using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysicsController : MonoBehaviour
{
    PlayerManager player;
    protected internal BoxCollider2D playerCollider;
    private void Awake()
    {
        player = GetComponent<PlayerManager>();
        playerCollider = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LazerTag"))
        {
            Debug.Log("LazerTag");
        }
    }

    public void SetCollider(bool value)
    {
        playerCollider.enabled = value;
    }
}
