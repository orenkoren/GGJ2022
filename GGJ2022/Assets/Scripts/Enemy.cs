using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ElectricCharge orientation;
    public float speed;

    private PlayerManager playerManager;

    private void Start()
    {
        playerManager = GameWorld.Instance.GetManager<PlayerManager>();
    }

    private void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, playerManager.GetPlayerPosition(), step);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(orientation.ToString()))
            Destroy(gameObject);
    }
}


public enum ElectricCharge
{
    Positive,
    Negative
}