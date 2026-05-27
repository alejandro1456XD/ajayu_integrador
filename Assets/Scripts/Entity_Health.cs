using System;
using Unity.VisualScripting;
using UnityEngine;

public class Entity_Health : MonoBehaviour
{
    private Entiy_VFX entiy_VFX;
    private Entity entity;

    [SerializeField] protected float currentHp;
    [SerializeField] protected float maxHp = 100;
    [SerializeField] protected bool isDead;

    [Header("on Dmage KnockBack")]
    [SerializeField] private Vector2 knockbackPower = new Vector2(1.5f, 2.5f);
    [SerializeField] private Vector2 heavyknockbackPower = new Vector2(7, 7);
    [SerializeField] private float knockbackDuration = .2f;
    [SerializeField] private float heavyknockbackDuration = .5f;

    [Header("On heavy Damage")]
    [SerializeField] private float heacyDamageThreshold = .3f;

    protected virtual void Awake()
    {
        entiy_VFX = GetComponent<Entiy_VFX>();
        entity = GetComponent<Entity>();

        currentHp = maxHp;
    }

    public virtual void TakeDamage(float damage, Transform damageDealer)
    {
        if (isDead)
            return;

        Vector2 knockback = CalculateKnockbac(damage, damageDealer);
        float duration = CalculateDuration(damage);

        entity?.ReciveKnockback(knockback, duration);  
        entiy_VFX?.PlayOnDamageVfx();
        ReduceHp(damage);
    }

    protected void ReduceHp(float damage)
    {
        currentHp -= damage;  

        if (currentHp <= 0)   
            Die();
    }

    private void Die()
    {
        isDead = true;
        entity.EntiityDeath();
    }

    private Vector2 CalculateKnockbac(float damage, Transform damageDealer)
    {
        int direction = transform.position.x > damageDealer.position.x ? 1 : -1;
        Vector2 knockback = IsHeavyDamage(damage) ? heavyknockbackPower : knockbackPower;
        knockback.x = knockback.x * direction;
        return knockback;
    }

    private float CalculateDuration(float damage) => IsHeavyDamage(damage) ? heavyknockbackDuration : knockbackDuration;

    private bool IsHeavyDamage(float damage) => damage / maxHp > heacyDamageThreshold;
}