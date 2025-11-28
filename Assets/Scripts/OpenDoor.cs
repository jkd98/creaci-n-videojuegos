using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Para usar UI elements
using TMPro; // NECESARIO para usar TextMeshPro
using UnityEngine.SceneManagement; // Para cargar escenas

public class OpenDoor : MonoBehaviour
{
    public TextMeshProUGUI doorText;
    public string levelName;
    private bool inDoorZone = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            doorText.gameObject.SetActive(true);
            inDoorZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            doorText.gameObject.SetActive(false);
            inDoorZone = false;
        }
    }

    private void Update()
    {
        if (inDoorZone && Input.GetKey("e"))
        {
            // Cargar el nivel especificado
            SceneManager.LoadScene(levelName);
        }
    }

}
