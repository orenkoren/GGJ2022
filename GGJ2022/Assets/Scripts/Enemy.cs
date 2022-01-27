using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ElectricCharge orientation;


    private void OnCollisionEnter(Collision other)
    {
        print(other.gameObject.tag);
        if (other.gameObject.CompareTag(orientation.ToString()))
            Destroy(gameObject);
    }
}


public enum ElectricCharge
{
    Positive,
    Negative
}