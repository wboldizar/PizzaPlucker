using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherManager : MonoBehaviour
{
    [SerializeField]
    private LauncherControl[] Launchers;

    System.Random randomGenerator = new System.Random();

    public void ActivateLauncher()
    {
        int launcherSelect = randomGenerator.Next(3);
        Launchers[launcherSelect].LaunchPizza();
    }
}
