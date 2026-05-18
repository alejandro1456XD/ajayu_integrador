using UnityEngine;

public class Enemy : Entity
{
    public Enemy_IdleState idleState;
    public Enemy_MoveState moveState;
    public Enemy_AttackState attackState;
    public Enemy_BattleState battleState;
    [Header("Movement details")]
    public float idleTime = 2;
    public float moveSpeed = 1.4f;
    [Range(0,2)]    
    public float moveAnimSpeedMultiplier = 1;
}