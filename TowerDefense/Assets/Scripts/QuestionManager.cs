using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{

    public enum QuestionCategory
    {
        GeneralKnowledge,
        Science,
        History,
        Math
    }

    public QuestionCategory selectedCategory;

    private Dictionary<QuestionCategory, List<(string question, bool answer)>> questionsDatabase =
        new Dictionary<QuestionCategory, List<(string question, bool answer)>>()
    {
        { QuestionCategory.GeneralKnowledge, new List<(string question, bool answer)> {
            ("¿El agua hierve a 100 grados Celsius?", true),
            ("¿La Gran Muralla China es visible desde el espacio?", false),
            ("¿La capital de Francia es París?", true)
        }},
        { QuestionCategory.Science, new List<(string question, bool answer)> {
            ("¿La fotosíntesis es el proceso por el cual las plantas producen su alimento?", true),
            ("¿El sonido viaja más rápido en el agua que en el aire?", true),
            ("¿El sol gira alrededor de la Tierra?", false)
        }},
        { QuestionCategory.History, new List<(string question, bool answer)> {
            ("¿La Primera Guerra Mundial comenzó en 1914?", true),
            ("¿Cleopatra era la reina de Roma?", false),
            ("¿La Revolución Francesa ocurrió en el siglo XVIII?", true)
        }},
        { QuestionCategory.Math, new List<(string question, bool answer)> {
            ("¿2 + 2 es igual a 4?", true),
            ("¿El número π (pi) es aproximadamente 3.14159?", true),
            ("¿5 x 5 es igual a 20?", false)
        }}
    };

    public (string question, bool answer) GetRandomQuestion()
    {
        List<(string question, bool answer)> selectedQuestions = questionsDatabase[selectedCategory];
        int randomIndex = Random.Range(0, selectedQuestions.Count);
        return selectedQuestions[randomIndex];
    }

    /*
    private static QuestionManager instance;
    public static QuestionManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<QuestionManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        // Mantener este objeto vivo entre escenas
        DontDestroyOnLoad(gameObject);
    }*/


}
