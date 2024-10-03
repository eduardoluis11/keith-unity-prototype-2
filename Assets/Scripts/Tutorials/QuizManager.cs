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

    private int questionIndex = 0; // Add this field to keep track of the current question index for the generateQuestion() method


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

    /* This generates the questions.

    Right now, this generates the questions at a random order. I DON'T WANT THAT. I want the questions to be shown at a fixed order.

    To modify the code so that the questions are displayed in a fixed order, you can iterate through the questions sequentially instead 
    of selecting them randomly. You can use an index to keep track of the current question and increment it each time a new question is 
    generated.

    Explanation:
    Add a Field:

    Added a private field questionIndex to keep track of the current question index.
    Sequential Question Selection:

    Instead of selecting a random question, the code now uses questionIndex to select the current question.
    If questionIndex exceeds the number of questions, it is reset to 0 to start from the beginning.
    Increment the Index:

    After setting the question text and answers, the questionIndex is incremented for the next question.
    This will ensure that the questions are displayed in a fixed order each time the player enters the scene.
    */
    void generateQuestion()
    {
        if(QnA.Count > 0)
        {

            if (questionIndex >= QnA.Count)
            {
                questionIndex = 0; // Reset the index if it exceeds the number of questions
            }

            QuestionTxt.text = QnA[questionIndex].Question;
            SetAnswers();

            //questionIndex++; // Increment the index for the next question. DON'T USE THIS, SINCE IT GENERATES A BUG.



            
            // currentQuestion = Random.Range(0, QnA.Count);

            // QuestionTxt.text = QnA[currentQuestion].Question;
            // SetAnswers();



        }
        else 
        {
            Debug.Log("Out of Questions");
            GameOver();
        }




    }

}
