using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEvents : MonoBehaviour
{
    public event EventHandler<int> OnCollisionWithSameCharge;

    public void CollidedWithSameCharge(object sender, int damage) => OnCollisionWithSameCharge?.Invoke(sender, damage);
}
