using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class MarsSeneTransition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnSelect() 
    {
        SceneManager.LoadScene("Mars");
    }
    private void Update()
    {
        // Check for left controller X button press
       
    }
   
}
