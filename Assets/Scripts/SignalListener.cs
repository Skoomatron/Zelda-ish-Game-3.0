using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEnging.Events;
public class SignalListener : MonoBehaviour
{
    public Signal signal;
    public UnityEvent signalEvent;
    public void OnSignalRaised()
    {
        signalEvent.Invoke();
    }
}
