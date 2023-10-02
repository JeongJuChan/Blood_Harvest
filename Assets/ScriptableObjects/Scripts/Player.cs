using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // public RuntimeAnimatorController animController;
    public GameObject MainSprite;

    Animator anim;
    private void Awake()
    {
        anim = MainSprite.GetComponent<Animator>();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        DamageManager.instance.playerHealth -= 10 * Time.deltaTime;
        Debug.Log(DamageManager.instance.playerHealth);

        if (DamageManager.instance.playerHealth < 0)
        {
            anim.SetTrigger("IsDead");
        }
    }
}
