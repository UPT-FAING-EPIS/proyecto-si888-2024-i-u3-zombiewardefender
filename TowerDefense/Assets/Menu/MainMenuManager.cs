using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;


public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    public Dropdown categoryDropdown;

    private const string PlayerPrefsKey = "SelectedCategory";

    private void Start()
    {
        if (categoryDropdown != null)
        {
            int savedCategoryIndex = PlayerPrefs.GetInt(PlayerPrefsKey, 0);
            categoryDropdown.value = savedCategoryIndex;
            categoryDropdown.onValueChanged.AddListener(OnDropdownValueChanged);

            // Establecer la categoría seleccionada en el QuestionManager (si es una referencia directa)
            // QuestionManager.Instance.selectedCategory = (QuestionManager.QuestionCategory)savedCategoryIndex;
        }
        else
        {
            UnityEngine.Debug.LogError("Dropdown is not assigned to MainMenuManager.");
        }
    }

    private void OnDropdownValueChanged(int index)
    {
        PlayerPrefs.SetInt(PlayerPrefsKey, index);
        UnityEngine.Debug.Log("Selected category index: " + index);
    }


}
