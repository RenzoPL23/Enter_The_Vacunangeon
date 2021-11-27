using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void GoPlay(){
        StateManager.changeScene("PlatformerTestScene");
    }

    public void GoIntegrantes(){
        StateManager.changeScene("Integrantes");
    }
}
