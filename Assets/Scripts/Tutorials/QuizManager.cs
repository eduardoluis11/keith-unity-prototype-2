using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // This lets us use TextMeshPro to display text
using UnityEngine.SceneManagement; // This lets us use SceneManager to change scenes

/* Source of most of this code: The Game Guy from https://youtu.be/G9QDFB2RQGA?si=_Psb92iJnkPlg55W , and from 
https://youtu.be/POUemIGCyr0?si=9CaczUgu_pd0FgyS

*/

/* This script lets me create all the questions and their respective answers for the quiz for the puzzle wall scene.

This is one of the 3 scripts tthat allowed me to create the quiz puzzle for the puzzle wall scene.
*/

public class QuizManager : MonoBehaviour
{

    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject Quizpanel;
    public GameObject GoPanel;

    public TMP_Text QuestionTxt;
    public TMP_Text ScoreTxt;

    int totalQuestions = 0;
    public int score;

    private void Start()
    {
        totalQuestions = QnA.Count;
        GoPanel.SetActive(false);
        generateQuestion();
        
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GameOver()
    {
        Quizpanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreTxt.text = score + "/" + totalQuestions;
    }

    public void correct()
    {
        // When you answer correctly
        score++;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void wrong()
    {
        // When you answer wrong
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnA[currentQuestion].Answers[i];

            if(QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if(QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else 
        {
            Debug.Log("Out of Questions");
            GameOver();
        }




    }

}
