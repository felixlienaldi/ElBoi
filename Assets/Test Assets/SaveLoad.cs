using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class SaveLoad : MonoBehaviour {
    public  static GameSystem savedgame;
    public static string Files;

    public static  void Overwrite() {
        savedgame = GameSystem.current;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/info.dat");
        bf.Serialize(file, savedgame);
        file.Close();
    }

    public static  void New()
    {
        savedgame = new GameSystem();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/info.dat");
        bf.Serialize(file, savedgame);
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Path.Combine(Application.persistentDataPath+"/info.dat", Files))){
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath+"/info.dat", FileMode.Open);
            savedgame = (GameSystem)bf.Deserialize(file);
            file.Close();
        }
    }



}
