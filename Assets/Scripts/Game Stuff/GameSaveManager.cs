using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSaveManager : MonoBehaviour
{
    public static GameSaveManager gameSave;
    private void Awake()
    {
        if (gameSave == null)
        {
            gameSave = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void Start()
    {

    }
    void Update()
    {

    }
}
