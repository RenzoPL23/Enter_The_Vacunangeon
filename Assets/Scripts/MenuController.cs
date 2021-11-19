using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public Button btnPlay;
    public Button btnIntegrantes;

    void Start()
    {

        btnPlay.onClick.AddListener(GoPlay);
        btnIntegrantes.onClick.AddListener(GoIntegrantes);
        
    }

    void GoPlay(){
        StateManager.changeScene("Game");
    }

    void GoIntegrantes(){
        StateManager.changeScene("Integrantes");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
