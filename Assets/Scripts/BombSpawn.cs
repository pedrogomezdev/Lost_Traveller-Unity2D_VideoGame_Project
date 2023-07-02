using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawn : MonoBehaviour
{
    
    private float waitSecondsToSpawn = 2f;            // Segundos entre spawn y spawn de bomba
    public AudioSource audioSource;                     
    public AudioClip explosionSound, bombAppearSound;
    public GameObject bombPrefab;
    // Start is called before the first frame update
    void Start()
    {
        // Ejecuta la corrutina que spawnea las bombas
        StartCoroutine("SpawnBombs");
    }

    // Update is called once per frame
    void Update()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // De forma permanente se instanciar� una bomba cada segundo y medio en la posici�n del spawn
    IEnumerator SpawnBombs()
    {
        while (true)
        {
            Instantiate(bombPrefab, transform.position, Quaternion.identity);

            yield return new WaitForSeconds(waitSecondsToSpawn);
        }
    }

    // M�todo que al ser llamado reproducir� el sonido de la explosi�n
    public void BombExplosion()
    {
        audioSource.PlayOneShot(explosionSound);
    }


}
