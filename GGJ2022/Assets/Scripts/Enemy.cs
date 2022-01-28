using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ElectricCharge orientation;
    public float Speed;
    public float PatrolRadius;

    private new Vector3 startPosition;
    private PlayerManager playerManager;
    private bool shouldMove = true;
    private bool moveRight = true;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        var step = Speed * Time.deltaTime;
        if (moveRight)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), step);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z), step);
        }
        moveDirection();
    }

    private void moveDirection()
    {
        if (transform.position.x >= startPosition.x + PatrolRadius)
        {
            moveRight = false;
        }
        else if (transform.position.x <= startPosition.x - PatrolRadius)
        {
            moveRight = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(orientation.ToString()))
            GetComponent<EnemyEvents>().CollidedWithSameCharge(this, 0);
        if (GameWorld.Instance.CollidedWithOpoositeCharge(orientation, other.gameObject))
            Destroy(gameObject);

    }
}


public enum ElectricCharge
{
    Positive,
    Negative
}