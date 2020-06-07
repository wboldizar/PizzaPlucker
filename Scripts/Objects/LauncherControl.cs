using JetBrains.Annotations;
using System;
using System.IO;
using UnityEngine;

public class LauncherControl : MonoBehaviour
{
    public GameplayManager gameplayManager;

    /**** Launcher Objects and Variables ****/
    [SerializeField]
    private LaunchData[] launchData;

    System.Random randomGenerator = new System.Random();
    Vector3 launchVelocity;
    Color orbColor;

    /**** Pizza Objects and Variables ****/
    public GameObject pizzaPrefab;
    Rigidbody pizzaRigid;

    [SerializeField]
    private float pizzaGravity;
    public bool inAir = false;

    [SerializeField]
    private Material orbMaterial;

    //Parses Launch Data from files 
    void Start()
    {
        var slowLaunchText = Resources.Load<TextAsset>("SlowLaunchData");
        var mediumLaunchText = Resources.Load<TextAsset>("MediumLaunchData");
        var fastLaunchText = Resources.Load<TextAsset>("FastLaunchData");

        launchData = new LaunchData[3];
        launchData[0] = JsonUtility.FromJson<SlowLaunchData>(slowLaunchText.text);
        launchData[1] = JsonUtility.FromJson<MediumLaunchData>(mediumLaunchText.text);
        launchData[2] = JsonUtility.FromJson<FastLaunchData>(fastLaunchText.text);
    }


    public void LaunchPizza()
    {
        GameObject pizza = MakePizza();
        pizzaRigid = pizza.GetComponent<Rigidbody>();

        int pizzaSelect = randomGenerator.Next(3);
        launchVelocity = new Vector3(launchData[pizzaSelect].launchVelocity[0], launchData[pizzaSelect].launchVelocity[1], launchData[pizzaSelect].launchVelocity[2]);
        orbColor = new Color(launchData[pizzaSelect].glowColor[0], launchData[pizzaSelect].glowColor[1],
                             launchData[pizzaSelect].glowColor[2], launchData[pizzaSelect].glowColor[3]);

        orbMaterial.SetColor("OrbShaderColor", orbColor);
        pizzaRigid.AddForce(launchVelocity, ForceMode.VelocityChange);
        inAir = true;
    }

    private GameObject MakePizza()
    {
        GameObject pizza = Instantiate(pizzaPrefab, transform.position, Quaternion.Euler(-90, 0, 0), transform);
        PizzaCollisionControl pizzaControl = pizza.GetComponent<PizzaCollisionControl>();
        pizzaControl.gameplayManager = gameplayManager;
        pizzaControl.launcherControl = this;

        return pizza;
    }

    private void FixedUpdate()
    {
        if(inAir && pizzaRigid != null)
        {
            pizzaRigid.AddForce(new Vector3(0f, pizzaGravity, 0f), ForceMode.Acceleration);
        }
        else if(pizzaRigid != null)
        {
            pizzaRigid.AddForce(Vector3.zero, ForceMode.VelocityChange);
            pizzaRigid.isKinematic = true;
        }
    }
}
