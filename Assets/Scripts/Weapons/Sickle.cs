using System.Collections;
using UnityEngine;

public class Sickle : Weapon
{
    [SerializeField] private float currentAngle = 0f;
    [SerializeField] private float radius = 1f;

    protected override IEnumerator Move()
    {
        transform.rotation = Quaternion.Euler(0, 0, -currentAngle);

        if (currentAngle < 360f)
        {
            float xPos = Mathf.Sin(currentAngle * Mathf.Deg2Rad);
            float yPos = Mathf.Cos(currentAngle * Mathf.Deg2Rad);

            transform.position = (Vector2)offsetTransform.position + new Vector2(xPos, yPos) * radius;
            currentAngle += Time.deltaTime * moveSpeed;

            yield return null;
        }
        else
            currentAngle = 0f;

        StartCoroutine(Move());
    }

    public void ChangeMoveSpeed(float movingRate)
    {
        moveSpeed *= movingRate;
    }

    protected override void OnCollide(Collider2D collision)
    {
    }
}
