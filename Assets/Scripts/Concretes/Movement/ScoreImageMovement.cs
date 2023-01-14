using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreImageMovement : MonoBehaviour
{
    GameObject finalDestination;
    private void Awake()
    {
        finalDestination = GameObject.Find("ScoreDestination");
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, finalDestination.transform.position, Time.deltaTime * 12);
        if(transform.position == finalDestination.transform.position)
        {
            UISignals.Instance.onScorePoint?.Invoke();
            Destroy(this.gameObject);
        }
    }
}
