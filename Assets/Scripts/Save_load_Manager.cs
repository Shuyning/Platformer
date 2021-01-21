using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Save_Load_Manager : MonoBehaviour
{
    [System.Serializable]
    public class Setters
    {
        public int levelComplete;
        public float volumeSound;
    }

    public void Save()
    {
        Setters set = new Setters();
        set.levelComplete = PlayerPrefs.GetInt("LevelComplete");
        set.volumeSound = PlayerPrefs.GetFloat("VolumeSound");

        if(!Directory.Exists(Application.dataPath + "/data_save"))
        {
            Directory.CreateDirectory(Application.dataPath + "/data_save");
        }

        FileStream fs = new FileStream(Application.dataPath + "/data_save/save.fs", FileMode.Create);
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(fs, set);
        fs.Close();
    }

    public void load()
    {
        if(File.Exists(Application.dataPath + "/data_save/save.fs"))
        {
            FileStream fs = new FileStream(Application.dataPath + "/data_save/save.fs", FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();

            try
            {
                Setters set = (Setters)formatter.Deserialize(fs);
                PlayerPrefs.SetInt("LevelComplete", set.levelComplete);
                PlayerPrefs.SetFloat("VolumeSound", set.volumeSound);
            }
            catch (System.Exception ex)
            {
                Debug.Log(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }
        else
        {
            Application.Quit();
        }
    }
}
