using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Biblioteca para uso do controlador de cenas.
using UnityEngine.SceneManagement;

public class InterfaceController : MonoBehaviour
{

    public void SetSceneToGo(string param) => SceneManager.LoadSceneAsync(param);
    public void QuitGame()
    {
        Application.Quit();
    }
}
