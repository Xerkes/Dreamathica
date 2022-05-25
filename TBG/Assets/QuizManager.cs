using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public Text questiontext;
    public Text[] answersTexts;
    int firstnumber;
    int secondnumber;

    public static UI instance;
    public void RandomQuestion()
    {
        firstnumber = Random.Range(1, 10);
        secondnumber = Random.Range(1, 10);
        questiontext.text = firstnumber.ToString() + " + " + secondnumber.ToString();
        Debug.Log(questiontext);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
