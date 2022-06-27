using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextClue : MonoBehaviour
{
    public GameObject contextClue;
    public void EnableClue()
    {
        contextClue.SetActive(true);
    }
    public void DisableClue()
    {
        contextClue.SetActive(false);
    }
}
