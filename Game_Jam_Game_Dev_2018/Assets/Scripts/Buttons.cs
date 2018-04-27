using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Buttons : MonoBehaviour
{
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
