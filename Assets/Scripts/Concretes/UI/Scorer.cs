using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorer : MonoBehaviour
{
    [SerializeField] GameObject scoreSprite;
    private void OnEnable()
    {
        PlayerSignals.Instance.onScoreImageCreate += OnPointInitialize;
    }
    private void OnDisable()
    {
        PlayerSignals.Instance.onScoreImageCreate -= OnPointInitialize;
    }
    private void OnPointInitialize(Transform _transform)
    {
        Instantiate(scoreSprite, _transform.position, transform.rotation);
    }
}
