using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoreSignals : Singleton<CoreSignals>
{
    public UnityAction onGameBegin = delegate { };
    public UnityAction onGameEnded = delegate { };
    public UnityAction onRightSide = delegate { };
    public UnityAction onLeftSide = delegate { };
    public UnityAction onGameRestart = delegate { };
}
