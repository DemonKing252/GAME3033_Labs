using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Canvas menuCanvas;

    // Start is called before the first frame update
    void Start()
    {
    }
    public void OnStartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
