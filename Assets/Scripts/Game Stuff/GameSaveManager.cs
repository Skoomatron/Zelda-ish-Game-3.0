using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSaveManager : MonoBehaviour
{
    public static GameSaveManager gameSave;
    public List<ScriptableObject> objects = new List<ScriptableObject>();
    // private void Awake()
    // {
    //     // singleton pattern
    //     if (gameSave == null)
    //     {
    //         gameSave = this;
    //     }
    //     else
    //     {
    //         Destroy(this.gameObject);
    //     }
    //     DontDestroyOnLoad(this);
    //     // end of singleton pattern
    // }
    // void Start()
    // {

    // }
    // void Update()
    // {

    // }
    public void SaveScriptables()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}.dat", i));
            BinaryFormatter binary = new BinaryFormatter();
            var json = JsonUtility.ToJson(objects[i]);
            binary.Serialize(file, json);
            file.Close();
        }
    }
    public void LoadScriptables()
    {

    }
}
