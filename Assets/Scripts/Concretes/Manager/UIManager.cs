using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Button jumpButton;

    private void OnEnable()
    {
        //UISignals.Instance.onJumpButton += JumpButton;
    }
    public void JumpButton()
    {
        PlayerSignals.Instance.onJumpAction?.Invoke();
    }
}
