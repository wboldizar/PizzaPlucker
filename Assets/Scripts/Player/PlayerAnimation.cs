using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    public Animator boxAnim;

    public void CatchPizza()
    {
        boxAnim.SetTrigger("CatchPizza");
    }
}
