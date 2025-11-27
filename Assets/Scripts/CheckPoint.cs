using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    //Detecta cuando el jugador entra en el checkpoint 2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Actualiza la posición de respawn del jugador al checkpoint actual
            collision.GetComponent<PlayerRespawn>().ReachedCheckpoint(transform.position.x, transform.position.y); // posicion del checkpoint

            GetComponent<Animator>().enabled = true; // Activa la animación del checkpoint
        }
    }
}
