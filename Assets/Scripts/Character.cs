using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private float health = 100f;

    public float Health { get { return health; } set { health = value; } }

    public virtual void TakeDamage(float damage)
    {
        Health -= damage;
        Health = Mathf.Max(health, 0);
    }
}

public class Player : Character
{
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        gameObject.GetComponent<PlayerController>().UpdateUI();
    }
}

public class Enemy : Character
{
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        gameObject.GetComponent<EnemyController>().UpdateHealth();
    }

}