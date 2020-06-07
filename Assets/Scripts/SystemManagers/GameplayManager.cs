using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    [SerializeField]
    private LauncherManager launcherManager;
    [SerializeField]
    private ScoringControl scoringControl;

    public bool pizzaScored;//Set by Scoring Control


    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }


    public void StartGame()
    {
        StartCoroutine(GameSequence());
    }

    IEnumerator GameSequence()
    {
        while(true)
        {
            launcherManager.ActivateLauncher();
            pizzaScored = false;
            yield return new WaitUntil(() => pizzaScored == true);
            yield return new WaitForSeconds(0.4f);
        }    
    }

    public void EndGame()
    {
        SceneManager.LoadScene("ScoreScene"); 
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene("PlayScene");
        Destroy(gameObject);//Get rid of old system manager that this is attached to
    }


    /***** Pizza Final State Handling *****/
    //PizzaCollisionControl calls these to ensure coroutine continuation with pizza destruction

    public void PizzaCaught(GameObject caughtPizza)
    {
        StartCoroutine(scoringControl.ScoreCatch(caughtPizza));
    }

    public void PizzaDropped()
    {
        scoringControl.ScoreDrop();
    }
}
