using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ElectricCharge orientation;
    public float speed;

    private PlayerManager playerManager;
    private bool shouldMove = true;

    private void Start()
    {
        playerManager = GameWorld.Instance.GetManager<PlayerManager>();
    }

    private void Update()
    {
        var step = speed * Time.deltaTime;
        if (shouldMove)
            transform.position = Vector3.MoveTowards(transform.position, playerManager.GetPlayerPosition(), step);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(orientation.ToString()))
            GetComponent<EnemyEvents>().CollidedWithSameCharge(this, 0);
        if (GameWorld.Instance.CollidedWithOpoositeCharge(orientation, other.gameObject))
            Destroy(gameObject);

    }

    public void SetMoving(bool shouldBeMoving)
    {
        shouldMove = shouldBeMoving;
    }

    public LookDirection GetLookDirection()
    {
        return (playerManager.GetPlayerPosition() - transform.position).normalized.x > 0 ? LookDirection.Right : LookDirection.Left;
    }
}


public enum ElectricCharge
{
    Positive,
    Negative
}