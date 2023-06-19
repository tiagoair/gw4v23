using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashController : MonoBehaviour
{
    [SerializeField] private float splashTime;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadMainMenu", splashTime);
    }

    private void LoadMainMenu()
    {
        GameManager.Instance.LoadScene("MainMenu");
    }
}
