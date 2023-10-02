using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Magnet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("ÀÚ¼®È¹µæ");
            collision.gameObject.GetComponentInChildren<MagnetField>().magnetTime = true;
            gameObject.SetActive(false);
        }
    }
}
