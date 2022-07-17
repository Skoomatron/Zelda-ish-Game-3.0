using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSaveManager : MonoBehaviour
{
    public static GameSaveManager gameSave;
    public List<ScriptableObject> objects = new List<ScriptableObject>();
    private void Awake()
    {
        // singleton pattern
        if (gameSave == null)
        {
            gameSave = this;
        }
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this.gameObject);
        // end of singleton pattern
    }
    void Start()
    {

    }
    void Update()
    {

    }
}
