using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizAnswer : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;

    public void Answer() {
        if(isCorrect) {
            quizManager.CorrectAnswer();
        }
        else {
            quizManager.IncorrectAnswer();
        }
    }
}
