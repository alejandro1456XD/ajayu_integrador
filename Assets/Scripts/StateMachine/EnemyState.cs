using UnityEngine;

public class EnemyState : EntityState
{
    protected Enemy enemy;

    public EnemyState(Enemy enemy, StateMachine stateMachine, string animBoolName) : base(stateMachine, animBoolName)
    {
        this.enemy = enemy;

        rb = enemy.rb;
        anim = enemy.anim;
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.F))
        {
            // CORREGIDO: 'attackState' con 'a' minúscula
            stateMachine.ChangeState(enemy.attackState);
        }

        anim.SetFloat("moveAnimSpeedMultiplier", enemy.moveAnimSpeedMultiplier);
    }
}