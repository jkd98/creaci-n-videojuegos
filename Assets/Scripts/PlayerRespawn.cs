using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    //Guardar posición del jugador para saber si uso el checkpoint
    private float checkpointPositionX, checkpointPositionY; // Para guardar player prefs
    public Animator animator;

    void Start()
    {
        //Detecta si ya se ha guardado una posición de checkpoint
        if(PlayerPrefs.GetFloat("checkPointPositionX") != 0)
        {
            checkpointPositionX = PlayerPrefs.GetFloat("checkPointPositionX");
            checkpointPositionY = PlayerPrefs.GetFloat("checkPointPositionY");
            transform.position = new Vector2(checkpointPositionX, checkpointPositionY); //Al dar play se mueve a la posición del checkpoint guardada
        }
    }

    public void ReachedCheckpoint(float x, float y)
    {
        PlayerPrefs.SetFloat("checkPointPositionX", x);
        PlayerPrefs.SetFloat("checkPointPositionY", y);
    }

    public void PlayerDamage(){
        animator.Play("Hit");//Animación de daño
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Recarga la escena actual
    }
}
