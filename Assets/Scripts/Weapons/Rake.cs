using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rake : Weapon
{
    private Camera _mainCam;

    [SerializeField] private float movingDuration = 1f;

    protected override void Awake()
    {
        base.Awake();
        _mainCam = Camera.main;
    }

    protected override IEnumerator Move()
    {
        Vector2 targetPos = _mainCam.ScreenToWorldPoint(Input.mousePosition);
        float harfDuration = movingDuration * 0.5f;
        float elapsedTime = 0f;
        float normalizedRatio = 0f;
        Vector2 targetRot = (targetPos - (Vector2)transform.position).normalized;

        transform.up = targetRot;

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
            transform.position = Vector2.Lerp(transform.position, offsetTransform.position, normalizedRatio);
            yield return null;
        }

        StartCoroutine(Move());
    }

    protected override void OnCollide(Collider2D collision)
    {
        base.OnCollide(collision);
    }

    public void ChangeScale(float value)
    {
        Vector3 tempScale = transform.localScale;
        tempScale += new Vector3(value, value, value);
        transform.localScale = tempScale;

        float increasingRate = (transform.localScale.x + value) / transform.localScale.x;
        collider.size *= increasingRate;
    }
}
