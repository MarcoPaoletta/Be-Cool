using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveAndLoadShopManager
{
    public static void SaveShopManager(ShopManager shopManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/shopData.txt";
        FileStream stream = new FileStream(path, FileMode.Create);
        ShopData data = new ShopData(shopManager);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static ShopData LoadShopManager()
    {
        string path = Application.persistentDataPath + "/shopData.txt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            ShopData shopData = formatter.Deserialize(stream) as ShopData;
            stream.Close();
            return shopData;
        }
        else
        {
            return null;
        }
    }
}