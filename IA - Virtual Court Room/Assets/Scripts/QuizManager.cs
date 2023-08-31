using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswer> QnA;
    public GameObject[] options;
    public int currentQuestion = 0;

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;

    public Text questionText;

    private void Start() {
        generateQuestion();    
    }

    void generateQuestion() {
        if(currentQuestion >= 11) {
            questionText.text = "You answered all questions correctly!";
            button1.SetActive(false);
            button2.SetActive(false);
            button3.SetActive(false);
            button4.SetActive(false);
        }
        else {
            questionText.text = QnA[currentQuestion].question;
            SetAnswers();
        }
    }

    void SetAnswers() {
        for (int i = 0; i < options.Length; i++) {
            options[i].GetComponent<QuizAnswer>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].answers[i];

            if(QnA[currentQuestion].correctAnswer == i+1) {
                options[i].GetComponent<QuizAnswer>().isCorrect = true;
            }
        }
    }

    public void CorrectAnswer() {
        Debug.Log("Correct");
        questionText.text = "Correct!";
        currentQuestion++;
        StartCoroutine(waiter());
    }
    public void IncorrectAnswer() {
        Debug.Log("Incorrect");
        questionText.text = "Incorrect!";
        StartCoroutine(waiter());
    }
    IEnumerator waiter() {
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(false);
        yield return new WaitForSeconds(2);
        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);
        button4.SetActive(true);
        generateQuestion();
    }
}
