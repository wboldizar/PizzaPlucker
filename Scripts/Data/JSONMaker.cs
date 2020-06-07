using UnityEngine;
using System.IO;

public class JSONMaker : MonoBehaviour
{
    public void MakeJsons()
    {
        LaunchData SlowLaunch = new SlowLaunchData();
        LaunchData MediumLaunch = new MediumLaunchData();
        LaunchData FastLaunch = new FastLaunchData();

        string slowLaunchText = JsonUtility.ToJson(SlowLaunch);
        File.WriteAllText("Assets/Scripts/Data/Resources/SlowLaunchData.json", slowLaunchText);

        string mediumLaunchText = JsonUtility.ToJson(MediumLaunch);
        File.WriteAllText("Assets/Scripts/Data/Resources/MediumLaunchData.json", mediumLaunchText);

        string fastLaunchText = JsonUtility.ToJson(FastLaunch);
        File.WriteAllText("Assets/Scripts/Data/Resources/FastLaunchData.json", fastLaunchText);
    }
  
    public void TestJsons()
    {
        string slowLaunchText = File.ReadAllText("Assets/Scripts/Data/Resources/SlowLaunchData.json");
        Debug.Log(slowLaunchText);

        string mediumLaunchText = File.ReadAllText("Assets/Scripts/Data/Resources/MediumLaunchData.json");
        Debug.Log(mediumLaunchText);

        string fastLaunchText = File.ReadAllText("Assets/Scripts/Data/Resources/FastLaunchData.json");
        Debug.Log(fastLaunchText);
    }
}
