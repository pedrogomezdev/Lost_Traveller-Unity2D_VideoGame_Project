using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    // Objetos
    public GameObject explosionPrefab;
    private BombSpawn bombSpawnScript;

    // Script del player
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        bombSpawnScript = FindObjectOfType<BombSpawn>();
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si la bomba colisiona con el player, reduce las vidas del player a 0
        if(collision.gameObject.tag == "Player")
        {
            playerController.totalLifes = 0;
        }

        // Colisione con lo que colisione:
        // Instancia el prefab de las part�culas de la explosi�n y la elimina una vez terminada. Adem�s ejecuta el sonido de la explosi�n
        // y destruye el objeto de la bomba.
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        ParticleSystem ps = explosion.GetComponent<ParticleSystem>();
        ps.Play();
        Destroy(explosion, ps.main.duration + 1.5f);

        bombSpawnScript.BombExplosion();
        Destroy(gameObject);
    }
}
