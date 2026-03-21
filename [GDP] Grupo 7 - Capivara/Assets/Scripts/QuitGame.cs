using UnityEngine;

public class QuitGane : MonoBehaviour 
{
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Saiu");
    }    
}