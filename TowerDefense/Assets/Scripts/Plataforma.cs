using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Plataforma : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    private Renderer renderer;
    public Color starColor;

    public GameObject turret;

    public GameObject standartTurretPrefab;

    

    /*private bool constructionActive = true;

    public Button comprarButton;*/



    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        starColor = renderer.material.color;

        // Obtener referencia al botón de compra
        //comprarButton.onClick.AddListener(ActivarConstruccion);

    }

    // Método para activar la construcción cuando se presiona el botón
    /*void ActivarConstruccion()
    {
        constructionActive = true;
        Debug.Log("Construction activated");
    }*/

    // Update is called once per frame
    void Update()
    {
        // Detectar si se presiona la tecla ESC para desactivar la construcción
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            constructionActive = false;
            Debug.Log("Construction deactivated");
        }*/

    }

    private void OnMouseEnter()
    {
        //if (constructionActive)
            renderer.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        renderer.material.color = starColor;
    }

    private void OnMouseDown()
    {

        // Build a turret
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager.money < 10)
        {
            renderer.material.color = notEnoughMoneyColor;
            return;
        }

        turret = (GameObject)Instantiate(standartTurretPrefab, transform.position + positionOffset, transform.rotation);
        gameManager.money -= 10;

        // Asegurarnos de actualizar el texto de dinero después de gastar monedas
        gameManager.UpdateMoneyText();


    }

}
