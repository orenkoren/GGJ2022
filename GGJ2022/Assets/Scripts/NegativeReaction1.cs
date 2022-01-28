using System.Collections;
using UnityEngine;

public class NegativeReaction1 : MonoBehaviour
{
    private EnemyEvents events;
    public float duration = 1.0f;
    public int pushbackForce = 1000;

    private bool isBerzerk = false;
    private bool shouldApplyBerzerkEffect = false;
    void Start()
    {
        events = GetComponent<EnemyEvents>();
        events.OnCollisionWithSameCharge += Berzerk;
    }

    private void Berzerk(object sender, int e)
    {
        isBerzerk = true;
        gameObject.transform.localScale *= 2;
        StartCoroutine(BerzerkDuration());
        GetComponent<Enemy>().SetMoving(false);
        shouldApplyBerzerkEffect = true;
    }

    private void Update()
    {
        if (shouldApplyBerzerkEffect)
        {
            var lookDir = GetComponent<Enemy>().GetLookDirection();
            GetComponent<Rigidbody>().AddForce(new Vector3(lookDir == LookDirection.Left ? pushbackForce : pushbackForce * -1, 0, 0));
        }
        shouldApplyBerzerkEffect = false;
    }

    private IEnumerator BerzerkDuration()
    {
        float counter = 0;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            yield return null;
        }
        isBerzerk = false;
        gameObject.transform.localScale /= 2;
        GetComponent<Enemy>().SetMoving(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isBerzerk && collision.gameObject.CompareTag("PositiveEnemy"))
            Destroy(collision.gameObject);
    }
}
