using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    public enum Player { Frog, VirtualGuy, PinkMan };
    public Player selectedPlayer;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public RuntimeAnimatorController[] playersController;
    public Sprite[] playersSprite;


    void Start()
    {
        switch (selectedPlayer)
        {
            case Player.Frog:
                animator.runtimeAnimatorController = playersController[0];
                spriteRenderer.sprite = playersSprite[0];
                break;
            case Player.PinkMan:
                animator.runtimeAnimatorController = playersController[1];
                spriteRenderer.sprite = playersSprite[1];
                break;
            case Player.VirtualGuy:
                animator.runtimeAnimatorController = playersController[2];
                spriteRenderer.sprite = playersSprite[2];
                break;
        }
    }

}
