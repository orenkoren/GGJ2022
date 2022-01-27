using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ElectricCharge orientation;


    private void OnCollisionEnter(Collision other)
    {
        print(other.gameObject.name);
        if (orientation == ElectricCharge.Positive && other.gameObject.CompareTag("Positive"))
            Destroy(gameObject);
    }
}


public enum ElectricCharge
{
    Positive,
    Negative
}