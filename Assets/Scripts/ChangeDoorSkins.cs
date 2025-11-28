using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDoorSkins : MonoBehaviour
{
    public GameObject skinsPanel;
    private bool inDoor = false;

    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inDoor = true;
            skinsPanel.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inDoor = false;
            skinsPanel.gameObject.SetActive(false);

        }
    }

    public void SetPlayerFrog()
    {
        PlayerPrefs.SetString("playerSkin", "Frog");
        ResetPlayerSkin();
    }
    public void SetPlayerPinkMan()
    {
        PlayerPrefs.SetString("playerSkin", "PinkMan");
        ResetPlayerSkin();
    }
    public void SetPlayerVirtualGuy()
    {
        PlayerPrefs.SetString("playerSkin", "VirtualGuy");
        ResetPlayerSkin();
    }

    void ResetPlayerSkin()
    {
        skinsPanel.gameObject.SetActive(false);
        player.GetComponent<PlayerSelect>().ChangePlayerInMenu();
    }
}
