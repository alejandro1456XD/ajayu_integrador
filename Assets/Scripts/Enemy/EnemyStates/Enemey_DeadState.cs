using System.Collections;
using UnityEngine;

public class Enemey_DeadState : EnemyState
{
    public Enemey_DeadState(Enemy enemy, StateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        // Frenar el movimiento para que no resbale
        enemy.rb.linearVelocity = Vector2.zero;

        // Apagar la gravedad para que no caiga al vacío al quitarle la colisión
        enemy.rb.gravityScale = 0;

        //  Apagar la caja de colisión para que no estorbe al jugador
        Collider2D collider = enemy.GetComponent<Collider2D>();
        if (collider != null)
            collider.enabled = false;

        // Iniciar la secuencia de desaparición
        enemy.StartCoroutine(DesaparecerYDestruir());
    }

    private IEnumerator DesaparecerYDestruir()
    {
        // Esperamos 2 segundos para que se reproduzca la animación y se quede un rato en el piso
        yield return new WaitForSeconds(2f);

        // Buscamos el componente que dibuja al enemigo en pantalla
        SpriteRenderer sr = enemy.GetComponentInChildren<SpriteRenderer>();

        if (sr != null)
        {
            // Bucle para crear el efecto de parpadeo (lo hace 5 veces)
            for (int i = 0; i < 5; i++)
            {
                sr.enabled = false; // Se hace invisible
                yield return new WaitForSeconds(0.15f);

                sr.enabled = true;  // Vuelve a aparecer
                yield return new WaitForSeconds(0.15f);
            }
        }

        // Finalmente, destruimos el GameObject por completo para liberar la memoria
        GameObject.Destroy(enemy.gameObject);
    }
}