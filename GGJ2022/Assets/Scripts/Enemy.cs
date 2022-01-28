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
            bool isPositive = true;
            if(transform.CompareTag("NegativeEnemy"))
            {
                isPositive = false;
            }
            var all = FindObjectsOfType<GameObject>();
            foreach (var item in all)
            {
                if (item.transform.CompareTag("Manager"))
                {
                    item.GetComponent<EnemiesRespawnManager>().AddEnemyToRespawnList(transform.position, isPositive);
                }
            }
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