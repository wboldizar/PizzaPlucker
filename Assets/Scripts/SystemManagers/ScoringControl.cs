using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringControl : MonoBehaviour
{
    [SerializeField]
    private GameplayManager gameplayManager;
    [SerializeField]
    private UIManager uiManager;
    [SerializeField]
    private PlayerAnimation playerAnimation;

    private int caughtCount = 0;
    public int currentScore = 0;
    private int catchValue = 1;

    private void Start()
    {
        uiManager.UpdateScore(currentScore);
    }

    public IEnumerator ScoreCatch(GameObject caughtPizza)
    {
        playerAnimation.CatchPizza();
        yield return new WaitForSeconds(0.5f);
        Destroy(caughtPizza);

        caughtCount++;
        currentScore += catchValue;
        uiManager.UpdateScore(currentScore);

        if (caughtCount % 5 == 0)
        {
            catchValue++;
            uiManager.UpdateValue(catchValue);
        }

        yield return new WaitUntil(() => playerAnimation.boxAnim.GetCurrentAnimatorStateInfo(0).IsName("IdleOpen"));
        gameplayManager.pizzaScored = true;
    }

    public void ScoreDrop()
    {
        gameplayManager.EndGame();
    }
}
