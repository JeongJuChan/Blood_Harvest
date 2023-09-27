using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rake : Weapon
{
    private Transform _offsetTransform;
    private Camera _mainCam;

    protected override void Awake()
    {
        base.Awake();
        _mainCam = Camera.main;
    }

    protected override IEnumerator Move()
    {
        Vector2 targetPos = _mainCam.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(targetPos);
        float harfDuration = movingDuration * 0.5f;
        float elapsedTime = 0f;
        float normalizedRatio = 0f;

        while (elapsedTime < harfDuration)
        {
            elapsedTime += Time.deltaTime;
            normalizedRatio = elapsedTime / harfDuration;
            transform.position = Vector2.Lerp(transform.position, targetPos, normalizedRatio);
            yield return null;
        }

        elapsedTime = 0f;

        while (elapsedTime < harfDuration)
        {
            elapsedTime += Time.deltaTime;
            normalizedRatio = elapsedTime / harfDuration;
            transform.position = Vector2.Lerp(transform.position, _offsetTransform.position, normalizedRatio);
            yield return null;
        }

        StartCoroutine(Move());
    }

    protected override void OnCollide(Collider2D collision)
    {
        base.OnCollide(collision);
    }

    public void SetOffsetTransform(Transform shooterTrans)
    {
        _offsetTransform = shooterTrans;
    }
}
