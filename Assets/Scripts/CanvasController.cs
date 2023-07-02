using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    private PointsController pointsController;

    // Start is called before the first frame update
    void Start()
    {
        pointsController = FindAnyObjectByType<PointsController>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // Cuando se ejecute este m�todo, cargar� el nivel 1
    public void Restart()
    {
        SceneManager.LoadScene("Level_1");
    }

    // Cuando se ejecute este m�todo, saldr� de la aplicacion
    public void ExitGame() 
    {
        Application.Quit();
    }

    // Cuando se ejecute este m�todo llama al script de pointsController para poner la puntuaci�n m�xima guardada a 0
    public void ResetMaxScore()
    {
        pointsController.ResetMaxPoints();
    }
}
