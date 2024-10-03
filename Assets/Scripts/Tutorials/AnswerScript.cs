using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Source of most of this code: The Game Guy from https://youtu.be/G9QDFB2RQGA?si=_Psb92iJnkPlg55W , and from 
https://youtu.be/POUemIGCyr0?si=9CaczUgu_pd0FgyS

*/

/* This is one of the 3 scripts that allowed me to create the quiz puzzle for the puzzle wall scene.
*/

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    
    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct!");
            quizManager.correct();
        }
        else
        {
            Debug.Log("Wrong Answer");
            quizManager.wrong();
        }
    }
}
