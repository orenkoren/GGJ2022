using UnityEngine;

public class Elevator : MonoBehaviour
{
    public ElectricCharge charge;
    public Transform top;
    public Transform bottom;
    public float speed = 5f;

    private bool shouldMove = false;
    private PlayerManager playerManager;

    void Start()
    {
        playerManager = GameWorld.Instance.GetManager<PlayerManager>();
    }

    void Update()
    {
        if (shouldMove)
        {
            var step = speed * Time.deltaTime;
            if (playerManager.GetPlayerCurrentCharge() != charge)
            {
                transform.position = Vector3.MoveTowards(transform.position, bottom.position, step);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, top.position, step);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            shouldMove = true;
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            shouldMove = false;
            collision.transform.SetParent(null);
        }
    }
}
