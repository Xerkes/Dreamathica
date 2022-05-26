using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GenerateQuestions : MonoBehaviour
{
    public Text[] buttons;
    public Text equationText;
    private int equationIndex;
    private int correctButtonIndex;
    public string[] expressions;
    public int[] answers;


    private void Start()
    {
        GetRandomEquationIndex();
        SetEquationText();
        SetButtonAnswers();
    }
    public void CheckAnswer()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i == correctButtonIndex)
            {
                buttons[i].GetComponentInParent<Image>().color = Color.green;
            }
            else
            {
                buttons[i].GetComponentInParent<Image>().color = Color.red;
            }
            buttons[i].GetComponentInParent<Button>().interactable = false;
        }
        StartCoroutine(GetNewEquation());
    }
    private IEnumerator GetNewEquation()
    {
        yield return new WaitForSeconds(2);
        GetRandomEquationIndex();
        SetButtonAnswers();
        SetEquationText();
    }
    private void ResetButtons()
    {
        foreach (Text item in buttons)
        {
            item.GetComponentInParent<Button>().interactable = true;
            item.GetComponentInParent<Image>().color = Color.blue;
        }
    }
    private void SetButtonAnswers()
    {
        int answer = answers[equationIndex]; //the answer to the equation
        correctButtonIndex = Random.Range(0, 3); //choose random button to assign correct answer
        int[] answerDeviations = GetDeviations();
        int deviationCounter = 0;
        answerDeviations[0] += answer;
        answerDeviations[1] += answer;
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i == correctButtonIndex)
            {
                buttons[i].text = "" + answer;
            }
            else
            {
                buttons[i].text = "" + answerDeviations[deviationCounter++];
            }
        }
    }
    private int[] GetDeviations()
    {
        int[] deviations = new int[2];
        int[] numbersToChooseFrom = { 1, 2, 3 };
        deviations[0] = numbersToChooseFrom[Random.Range(0, numbersToChooseFrom.Length)];
        while (true)
        {
            deviations[1] = numbersToChooseFrom[Random.Range(0, numbersToChooseFrom.Length)];
            if (deviations[1] != deviations[0])
            {
                break;
            }
        }
        return deviations;
    }

    private void GetRandomEquationIndex()
    {
        equationIndex = 0;
    }
    private void SetEquationText()
    {
        equationText.text = expressions[equationIndex] + " = ?";
    }
}
