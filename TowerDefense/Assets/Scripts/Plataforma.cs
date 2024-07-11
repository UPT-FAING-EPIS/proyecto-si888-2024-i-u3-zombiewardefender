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

        // Obtener referencia al bot�n de compra
        //comprarButton.onClick.AddListener(ActivarConstruccion);

    }

    // M�todo para activar la construcci�n cuando se presiona el bot�n
    /*void ActivarConstruccion()
    {
        constructionActive = true;
        Debug.Log("Construction activated");
    }*/

    // Update is called once per frame
    void Update()
    {
        // Detectar si se presiona la tecla ESC para desactivar la construcci�n
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

        // Asegurarnos de actualizar el texto de dinero despu�s de gastar monedas
        gameManager.UpdateMoneyText();


    }

}
