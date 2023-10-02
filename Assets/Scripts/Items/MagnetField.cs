using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetField : MonoBehaviour
{
    public bool magnetTime = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Exp exp) && magnetTime)
        {
            Debug.Log("��������");
            StartCoroutine(MagnetLimit(exp));
        }
    }


    IEnumerator MagnetLimit(Exp exp)
    {
        int callCoroutain = 0;
        Debug.Log("�ڷ�ƾ ȣ�� : " + ++callCoroutain);
        exp.magnetTime = true;
        yield return new WaitForSecondsRealtime(1.5f);
        exp.magnetTime = false;
        magnetTime = false;
    }
}
