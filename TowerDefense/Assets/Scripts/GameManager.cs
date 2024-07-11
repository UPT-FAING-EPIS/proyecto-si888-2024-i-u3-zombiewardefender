using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public int lifes = 4;
    public int money = 50;
    public int enemiesDestroyed = 0;
    public Text lifesText;
    public Text moneyText;
    public Text enemiesDestroyedText;

    public GameObject Panel_GameOver;

    public GameObject questionPanel; 
    public Text questionText; 
    public Button trueButton; 
    public Button falseButton; 
    private bool correctAnswer;

    private QuestionManager questionManager;

    public GameObject Panel_win;


    // Start is called before the first frame update
    void Start()
    {
        questionManager = FindObjectOfType<QuestionManager>();
        if (questionManager == null)
        {
            UnityEngine.Debug.LogError("QuestionManager is not found in the scene. Please add it.");
            return;
        }


        lifes = 4;
        UpdateLifesText();
        UpdateMoneyText();
        UpdateEnemiesDestroyedText();

        if (questionPanel != null)
        {
            questionPanel.SetActive(false); 
        }
        else
        {
            Debug.LogWarning("questionPanel is not assigned. Make sure to assign it in the Inspector.");
        }

        if (trueButton != null)
        {
            trueButton.onClick.AddListener(() => CheckAnswer(true));
        }
        else
        {
            UnityEngine.Debug.LogWarning("TrueButton is not assigned. Make sure to assign it in the Inspector.");
        }

        if (falseButton != null)
        {
            falseButton.onClick.AddListener(() => CheckAnswer(false));
        }
        else
        {
            UnityEngine.Debug.LogWarning("FalseButton is not assigned. Make sure to assign it in the Inspector.");
        }

        if (Panel_GameOver != null)
        {
            Panel_GameOver.SetActive(false);
        }
        else
        {
            UnityEngine.Debug.LogWarning("Panel_GameOver is not assigned. Make sure to assign it in the Inspector.");
        }


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeALife()
    {
        lifes--;
        UpdateMoneyText();
        UpdateLifesText();
        if (lifes <= 1)
        {
            
            if (questionPanel != null)
            {
                ShowQuestionPanel();
            }
            else
            {
                UnityEngine.Debug.LogError("questionPanel is not assigned. Cannot show GameOver panel.");
            }


            UnityEngine.Debug.Log("GameOver");
        }
        UpdateMoneyText();
        UpdateLifesText();

        UnityEngine.Debug.Log(lifes);
    }

    void UpdateLifesText()
    {
        // Actualiza el texto del objeto de texto de las vidas
        if (lifesText != null)
        {
            lifesText.text = "Lifes: " + lifes.ToString();
        }
        else
        {
            UnityEngine.Debug.LogWarning("LifesText no está asignado. Asegúrese de asignarlo en el Inspector.");
        }
    }


    public void AddMoney(int amount)
    {
        money += amount;
        UpdateMoneyText(); // Actualiza el texto después de cambiar el número de monedas
    }


    public void UpdateMoneyText()
    {
        // Actualiza el texto del objeto de texto de las monedas
        if (moneyText != null)
        {
            moneyText.text = "Coins: " + money.ToString();
        }
        else
        {
            Debug.LogWarning("MoneyText no está asignado. Asegúrese de asignarlo en el Inspector.");
        }
    }

    public void UpdateEnemiesDestroyedText()
    {
        if (enemiesDestroyedText != null)
        {
            enemiesDestroyedText.text = "Kill: " + enemiesDestroyed.ToString();
        }
        else
        {
            UnityEngine.Debug.LogWarning("EnemiesDestroyedText no está asignado. Asegúrese de asignarlo en el Inspector.");
        }
    }



    void ShowQuestionPanel()
    {
        (string question, bool answer) = questionManager.GetRandomQuestion();
        correctAnswer = answer;        

        // Muestra la pregunta en el panel de preguntas
        if (questionText != null)
        {
            questionText.text = question;
        }

        // Activa el panel de preguntas
        if (questionPanel != null)
        {
            questionPanel.SetActive(true);
        }
    }

    void CheckAnswer(bool answer)
    {
        if (answer == correctAnswer)
        {
            // Respuesta correcta, agregar una vida
            lifes += 1;
            UnityEngine.Debug.Log("Tienes: " + lifes);
            UpdateLifesText();
        }
        else
        {
            // Respuesta incorrecta, mostrar el panel de Game Over
            if (Panel_GameOver != null)
            {
                Panel_GameOver.SetActive(true);
                StartCoroutine(GameOverCoroutine());
            }
            else
            {
                UnityEngine.Debug.LogWarning("Panel_GameOver no está asignado. Asegúrese de asignarlo en el Inspector.");
            }
        }

        // Ocultar el panel de preguntas
        if (questionPanel != null)
        {
            questionPanel.SetActive(false);
        }
    }

    IEnumerator GameOverCoroutine()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Main");
    }

    public void WinLevel()
    {
        Panel_win.SetActive(true);

    }

}
