using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusController : MonoBehaviour
{

    public Transform target;                // Posici�n objetivo que alternar� con la original del objeto para que el enemigo haga un movimiento de ida y de venida.
    public bool isHurt = false;             // Indica si el enemigo ha sido da�ado.
    private float speed = 4f;               // Velocidad de movimiento del enemigo.
    private Vector3 start, end;             // Variables que nos ayudar�n a alternar la posici�n del target con la inicial del objeto.
    private SpriteRenderer spriteRenderer;  // Usaremos el componente SpriteRenderer para activar su opci�n flip, para volvear al enemigo.

    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        end = target.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movimiento del enemigo. El enemigo se mover� hacia la posici�n objetivo. Cuando llegue, la posici�n objetivo cambiar� de lugar y
        // se situar� en la situaci�n de partida haciendo que la plataforma regrese. Cuando llegue, volver� a cambiar a la posici�n objetivo, y
        // as� sucesivamente.
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (transform.position == target.position)
        {

            if (target.position == end)
            {
                target.position = start;
                spriteRenderer.flipX = true;    // Volteamos en la X el sprite.
            }
            else
            {
                target.position = end;
                spriteRenderer.flipX = false;

            }
        }
    }
}

