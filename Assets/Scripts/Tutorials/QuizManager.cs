using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // This lets us use TextMeshPro to display text
using UnityEngine.SceneManagement; // This lets us use SceneManager to change scenes

/* Source of most of this code: The Game Guy from https://youtu.be/G9QDFB2RQGA?si=_Psb92iJnkPlg55W , and from 
https://youtu.be/POUemIGCyr0?si=9CaczUgu_pd0FgyS

*/

/* This script lets me create all the questions and their respective answers for the quiz for the puzzle wall scene.

This script pretty much handles all of the gameplay mechanics for the Quiz Puzzle.

This is one of the 3 scripts that allowed me to create the quiz puzzle for the puzzle wall scene.

You will be able to attach Game Objects to this script, such as the "Quiz Panel" and the "Go Panel". Well, I will modify 
this script so that you can also attach a new panel called "Victory Quiz Panel" to this script.

The "Go Panel" will show the "Retry" button and a message saying "you lost. Try again." if you lose the quiz. Meanwhile, the "Victory Quiz Panel"
will show the "Ok" button and a message saying "you won. Good job!" if you win the quiz.
*/

public class QuizManager : MonoBehaviour
{

    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject Quizpanel;

    // Game Over (or "Go") Panel. This will make it so that you can attach the "Go Panel" Game Object to the script.
    public GameObject GoPanel;

    // Victory Quiz Panel. This will make it so that you can attach the "Victory Quiz Panel" Game Object to the script.
    public GameObject VictoryQuizPanel;

    public TMP_Text QuestionTxt;
    public TMP_Text ScoreTxt;

    int totalQuestions = 0;
    public int score;

    // Add this field to keep track of the current question index for the generateQuestion() method
    private int questionIndex = 0;


    private void Start()
    {
        totalQuestions = QnA.Count;
        GoPanel.SetActive(false);
        generateQuestion();
        
    }

    /* This will reload the Quiz Puzzle so that you can try to solve the puzzle once again from scratch (from the very first question) when 
    you click on the "Retry" button in the "Game Over Panel" when you answer the quiz wrong and lose. 
    */
    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /* This will confirm that you won the Quiz Puzzle, and will send the player from the Quiz Scene to the Main scene, and unlock the door when 
    you click on the "Ok" button in the "Victory Quiz Panel" when you answer the quiz correctly and win.
    */
    public void confirmVictoryAndUnlockDoorButton()
    {
        SceneManager.LoadScene("Main");
    }

    /* Once the quiz ends (when you answer all the questions, this will display the final result (how many questions
    you answered correctly) and the total number of questions.

    Well, there are 2 things that I want to fix here: 1) I don't want to show the player how many answers he got
    correctly. Otherwise, they could just guess the solution to the puzzle (they could guess the correct order of the
    books easily). 2) I want the player to only beat the puzzle if they get all 4 answers correctly. If they
    have ate last 1 answer wrong, I will display them an error message telling them that they didn't beat the puzzle,
    and I will ask them to try again.

    And it's only this function / method: I may need to also edit the correct(), wrong(), and SetAnswers "functions"
    to make this happen.

    To modify the `GameOver` method to display a success message if all questions are answered correctly and an error
    message if at least one question is answered incorrectly, you can use a conditional statement to check the player's
    score against the total number of questions.

    This code checks if the player's score is equal to the total number of questions. If they match, it displays the
    success message. Otherwise, it displays the error message.

    I think that "Go Panel" means the "Game Over Panel", which should display the message that says if you won or not, as well as the "Retry"
    button. 

    If that's the case, here's where I need to add a snippet that says that, if you lost the quiz, that the "Retry" button should show up. Meanwhile,
    if you win the quiz, the "Ok" button should show up, whereas the "Retry" button should be invisible.
    */
    void GameOver()
    {

        // This makes the Questions and the buttons with the answers to disappear
        Quizpanel.SetActive(false);



        // This will display a message depending on the score.
        // The player will only beat the puzzle if they get all the answers correctly.
        if (score == totalQuestions)
        {

            // This makes the Victory Quiz Panel appear (the one that displays the "Ok" button.)
            VictoryQuizPanel.SetActive(true);

            ScoreTxt.text = "Congrats! You've beaten the puzzle! The door has now been unlocked. Press 'Ok' to continue.";
        }
        // If the player gets at least 1 answer wrong, they will not beat the puzzle.
        else
        {
            // This makes the Game Over Panel appear (the one that says if you won or not, as well as the "Retry" button)
            GoPanel.SetActive(true);

            // // This displays the total score. I WON'T NEED THIS FOR THE TIME BEING.
            // ScoreTxt.text = score + "/" + totalQuestions;

            ScoreTxt.text = "Sorry, the books are not in the correct chronological order. Please, try again.";
        }
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
