using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPointPhysicsController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LazerTag"))
        {
            UISignals.Instance.onScoreImageCreate?.Invoke();
            PlayerSignals.Instance.onScoreImageCreate?.Invoke(this.gameObject.transform);
            FindObjectOfType<AudioManager>().Play("PointSound");
        }
    }

}
