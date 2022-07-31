using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class InventorySaver : MonoBehaviour
{
    [SerializeField] private PlayerInventory myInventory;
    private void OnEnable()
    {
        LoadScriptables();
    }
    private void OnDisable()
    {
        SaveScriptables();
    }
    public void ResetScriptables() {
        for (int i = 0; i < myInventory.myInventory.Count; i++)
        {
            if (File.Exists(Application.persistentDataPath + string.Format("/{0}.inv", i)))
            {
                File.Delete(Application.persistentDataPath + string.Format("/{0}.inv", i));
            }
        }
    }
    public void SaveScriptables()
    {
        for (int i = 0; i < myInventory.myInventory.Count; i++)
        {
            FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}.inv", i));
            BinaryFormatter binary = new BinaryFormatter();
            var json = JsonUtility.ToJson(myInventory[i]);
            binary.Serialize(file, json);
            file.Close();
        }
    }
    public void LoadScriptables()
    {
        for (int i = 0; i < myInventory.myInventory.Count; i++)
        {
            if (File.Exists(Application.persistentDataPath + string.Format("/{0}.inv", i)))
            {
                FileStream file = File.Open(Application.persistentDataPath + string.Format("/{0}.inv", i), FileMode.Open);
                BinaryFormatter binary = new BinaryFormatter();
                JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file), myInventory[i]);
                file.Close();
            }
        }
    }
}
