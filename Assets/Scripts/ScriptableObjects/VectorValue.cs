using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class VectorValue : ScriptableObject, ISerializationCallbackReceiver
{
    [Header("Value Running In Game")]
    public Vector2 initialValue;
    [Header("Default Starting Value")]
    public Vector2 defaultValue;
    public void OnAfterDeserialize()
    {
        initialValue = defaultValue;
    }
    public void OnBeforeSerialize()
    {

    }
}
