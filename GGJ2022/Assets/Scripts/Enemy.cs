using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ElectricCharge orientation;
    public float Speed;
    public float PatrolRadius;

    private Vector3 startPosition;
    private PlayerManager playerManager;
    private bool shouldMove = true;
    private bool moveRight = true;

    private void Start()
    {
        startPosition = transform.localPosition;
    }

    private void Update()
    {
        var step = Speed * Time.deltaTime;
        if (moveRight)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition,
                new Vector3(transform.localPosition.x + 0.5f, transform.localPosition.y, transform.localPosition.z), step);
        }
        else
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition,
                new Vector3(transform.localPosition.x - 0.5f, transform.localPosition.y, transform.localPosition.z), step);
        }
        moveDirection();
    }

    private void moveDirection()
    {
        if (transform.localPosition.x >= startPosition.x + PatrolRadius)
        {
            moveRight = false;
        }
        else if (transform.localPosition.x <= startPosition.x - PatrolRadius)
        {
            moveRight = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(orientation.ToString()))
            GetComponent<EnemyEvents>().CollidedWithSameCharge(this, 0);
        if (GameWorld.Instance.CollidedWithOpoositeCharge(orientation, other.gameObject))
        {
            GameWorld.Instance.GetManager<RespawnManager>().AddObjectToRespawnList(transform.position, transform.tag);
            Destroy(gameObject);
        }
            
        moveRight = !moveRight;
    }
}


public enum ElectricCharge
{
    Positive,
    Negative
}