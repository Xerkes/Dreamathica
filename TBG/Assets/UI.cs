using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text problemText;                // text that displays the maths problem
    public Text[] answersTexts;             // array of the 4 answers texts
    public Image remainingTimeDial;         // remaining time image with radial fill
    private float remainingTimeDialRate;    // 1.0 / time per problem
    public Text endText;


    public static UI instance;
    void Awake()
    {
        // set instance to be this script
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetProblemText(Problem problem)
    {
        string operatorText = "";
        // convert the problem operator from an enum to an actual text symbol
        switch (problem.operation)
        {
            case Problem.MathsOperation.Addition: operatorText = "     "; break;
            case Problem.MathsOperation.Subtraction: operatorText = " "; break;
            case Problem.MathsOperation.Multiplication: operatorText = " "; break;
            case Problem.MathsOperation.Division: operatorText = "  "; break;
        }
        // set the problem text to display the problem
        problemText.text = problem.firstNumber + operatorText + problem.secondNumber;
        // set the answers texts to display the correct and incorrect answers
        for (int index = 0; index < answersTexts.Length; ++index)
        {
            answersTexts[index].text = problem.answers[index].ToString();
        }
    }
    public void SetEndText(bool win)
    {
        // enable the end text object
        endText.gameObject.SetActive(true);
        // did the player win?
        if (win)
        {
            endText.text = "You Win!";
            endText.color = Color.green;
        }
        // did the player lose?
        else
        {
            endText.text = "Game Over!";
            endText.color = Color.red;
        }
    }
}
