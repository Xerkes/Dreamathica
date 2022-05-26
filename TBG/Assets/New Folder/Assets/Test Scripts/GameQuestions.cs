using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameQuestions : MonoBehaviour
{
    public Text Questions;
    public Text Answers;
    public Text[] buttons;

    private int Left;                                       //Variable for Left integer of the question
    private int Right;                                      //Variable for Right integer of the question
    private int CorrectAnswer;                              //Variable for the right answer
    private int WrongAnswer;
    private int Operator;


    void Start()
    {
        SetQuestions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetQuestions()
    {
        Right = Random.Range(0, 10);                          //Set the right side of the question to a random between 0 and 10
        Left = Random.Range(0, 10);                          //Set the left side of the question to a random between -10 and 10
        //Operator = Random.Range(1, 4);    
        Operator = 3;    //Set the operator of the question to a random between 1 and 4

        switch (Operator)
        {

            case 1:                                                     //If operator is 1
                CorrectAnswer = Left * Right;                          //Multiply the integers on the left and right 
                WrongAnswer = CorrectAnswer + Random.Range(-1, 1);     //Add a number between -1 and 1 to the correct answer and set it to the wrong answer        
                Questions.GetComponent<Text>().text = Left.ToString() + "  *  " + Right.ToString() + "  =  ";          //Display the question
                break;                                                  //Break the switch


            case 2:                                                                     //If operator is 2
                CorrectAnswer = Left - Right;                                           //Subtract 
                WrongAnswer = CorrectAnswer + Random.Range(-1, 1);                      //Add a number between -1 and 1 to the correct answer and set it to the wrong answer
                Questions.GetComponent<Text>().text = Left.ToString() + "  -  " + Right.ToString() + "  =  ";               //Display the question
                break;                                                  //Break the switch


            case 3:                                                         //If operator is 3
                CorrectAnswer = Left + Right;                               //Add
                WrongAnswer = CorrectAnswer + Random.Range(-1, 1);          //Add a number between -1 and 1 to the correct answer and set it to the wrong answer
                Questions.GetComponent<Text>().text = Left.ToString() + "  +  " + Right.ToString() + "  =  ";                   //Display the question
                break;                                                       //Break the switch

            default:
                break;
        }

        Answers.GetComponent<Text>().text = WrongAnswer.ToString();                               //Display wrong answer
                                //Display score
    }
    public void CorrectButtonpressed()
    {
        if (CorrectAnswer == WrongAnswer)                                   //If the choice is right
        {
            SetQuestions();                                                 //Call function to display another question
        }
    }
}
