[System.Serializable]
public abstract class LaunchData
{
    public float[] glowColor;
    public float[] launchVelocity;
}


[System.Serializable]
public class SlowLaunchData : LaunchData
{
    public SlowLaunchData()
    {
        glowColor = new float[4] { 1, 0, 0, 1 };
        launchVelocity = new float[3] { 0, 3, 2f};
    }
}

[System.Serializable]
public class MediumLaunchData : LaunchData
{
    public MediumLaunchData()
    {
        glowColor = new float[4] {0, 1, 0, 1};
        launchVelocity = new float[3] { 0, 3, 4};
    }
}

[System.Serializable]
public class FastLaunchData : LaunchData
{
    public FastLaunchData()
    {
        glowColor = new float[4] { 0, 0, 1, 1 };
        launchVelocity = new float[3] { 0, 3, 6f};
    }
}

