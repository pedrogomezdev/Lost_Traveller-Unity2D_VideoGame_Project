using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMov : MonoBehaviour
{
    
    public Transform targetPlatform;    // Posici�n objetivo que alternar� con la original del objeto para que la plataforma haga un movimiento de ida y de venida.
    private float speed = 3f;           // Velocidad a la que se mueve la plataforma.
    private Vector3 start, end;         // Variables que nos ayudar�n a alternar la posici�n del target con la inicial del objeto.



    void Start()
    {
        start = transform.position;
        end = targetPlatform.position;
    }

    
    void Update()
    {
        // Movimiento de la plataforma. La plataforma se mover� hacia la posici�n objetivo. Cuando llegue, la posici�n objetivo cambiar� de lugar y
        // se situar� en la situaci�n de partida haciendo que la plataforma regrese. Cuando llegue, volver� a cambiar a la posici�n objetivo, y
        // as� sucesivamente.
        transform.position = Vector3.MoveTowards(transform.position, targetPlatform.position, speed * Time.deltaTime);

        if(transform.position == targetPlatform.position)
        {

            if (targetPlatform.position == end)
            {
                targetPlatform.position = start;
            }
            else
            {
                targetPlatform.position = end;
            }
        }
    }

    
    // Si un objeto colisiona con la plataforma, pasar� a ser hijo de esta (haciendo que siga su movimiento)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.parent = transform;
    }

    // Si un objeto deja la colisi�n con la plataforma, dejar� de ser hijo de esta (haciendo que siga su movimiento)
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.parent = null;
    }
}
