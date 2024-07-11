using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class option_game : MonoBehaviour
{

    public void RegresarMenu(string NombreNivel)
    {
        
        SceneManager.LoadScene(NombreNivel);
    }
}
