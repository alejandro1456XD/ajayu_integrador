using UnityEngine;

public class Enemy_Health : Entity_Health
{
    public override void TakeDamage(float damage)
    {

        //entra en modo batalla
        base.TakeDamage(damage);
    }
}
