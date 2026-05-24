using UnityEngine;

public class Enemey_DeadState : EnemyState
{
    public Enemey_DeadState(Enemy enemy, StateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }
}
