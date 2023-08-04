using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageReciever
{

    public void Die();

    public void TakeDamage(float amount);

    public float hp { get; set; }
}
