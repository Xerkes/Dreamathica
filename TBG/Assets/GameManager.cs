using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Problem[] problems;      // list of all problems
    public int curProblem;          // current problem the player needs to solve
    public float timePerProblem;    // time allowed to answer each problem
    public float remainingTime;     // time remaining for the current problem
    public PlayerController player;

    public static GameManager instance;
    void Awake()
    {
        // set instance to this script.
        instance = this;
    }
    void Start()
    {
        SetProblem(0);
    }

    // Update is called once per frame

    void Win()
    {
        Time.timeScale = 0.0f;
        UI.instance.SetEndText(true);
        // set UI text
    }
    // called if the remaining time on a problem reaches 0
    void Lose()
    {
        Time.timeScale = 0.0f;
        UI.instance.SetEndText(false);
        // set UI text
    }

    void SetProblem(int problem)
    {
        curProblem = problem;
        remainingTime = timePerProblem;
        UI.instance.SetProblemText(problems[curProblem]);
        // set UI text to show problem and answers
    }
    void CorrectAnswer()
    {
        // is this the last problem?
        if (problems.Length - 1 == curProblem)
            Win();
        else
            SetProblem(curProblem + 1);
    }
    // called when the player enters the incorrect tube
    void IncorrectAnswer()
    {
        
    }

    public void OnPlayerEnterTube(int tube)
    {
        // did they enter the correct tube?
        if (tube == problems[curProblem].correctTube)
            CorrectAnswer();
        else
            IncorrectAnswer();
    }
    void Update()
    {
        remainingTime -= Time.deltaTime;
        // has the remaining time ran out?
        if (remainingTime <= 0.0f)
        {
            Lose();
        }
    }
}
