using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaCollisionControl : MonoBehaviour
{
    public GameplayManager gameplayManager;
    public LauncherControl launcherControl;

    bool collidedAlready = false;

    void OnCollisionEnter(Collision collision)
    {
        if(!collidedAlready)
        {
            if (collision.collider.name.Equals("PizzaBox"))
            {
                collidedAlready = true;
                launcherControl.inAir = false;
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                gameplayManager.PizzaCaught(gameObject);
            }
            else if (collision.collider.name.Equals("WallAndGrass"))
            {
                collidedAlready = true;
                gameplayManager.PizzaDropped();
            }
        }
    }
}
