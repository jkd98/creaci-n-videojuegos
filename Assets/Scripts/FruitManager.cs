using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Para usar UI elements
using TMPro; // NECESARIO para usar TextMeshPro

public class FruitManager : MonoBehaviour
{
    public TextMeshProUGUI fruitText; // Texto UI para mostrar las frutas recogidas
    public GameObject transitionLevel;
    private void Update()
    {
        AllFruitsCollected();
    }
    // Preguntar si quedan frutas
    public void AllFruitsCollected()
    {
        // se comprueba 1, pues es la que queda antes de ser destruida
        if (transform.childCount == 0)
        {
            Debug.Log("Ya no hay frutas");

            fruitText.gameObject.SetActive(true); // Activa el texto de frutas recogidas
            transitionLevel.SetActive(true); // Activa la transición de nivel
            Invoke("ChangeScene", 2f); // Cambia de escena tras 2 segundos

        }
    }

    public void ChangeScene()
    {
        //Toma la escena en la que estamos del buildIndex y sumale 1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
