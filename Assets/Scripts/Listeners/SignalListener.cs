using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SignalListener : MonoBehaviour
{
    public SignalClass signalSender;
    public UnityEvent signalEvent;
    public void OnSignalRaised()
    {
        signalEvent.Invoke();
    }
    private void OnEnable()
    {
        signalSender.RegisterListener(this);
    }
    private void OnDisable()
    {
        signalSender.DeregisterListener(this);
    }
}
