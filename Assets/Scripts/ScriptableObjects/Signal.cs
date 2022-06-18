using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Signal : ScriptableObject
{
    public List <SignalListener> listeners = new List<SignalListener>();
}
