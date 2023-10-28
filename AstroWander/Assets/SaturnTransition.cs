using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class SaturnTransition : MonoBehaviour
{
    private XRGrabInteractable interactable;
    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<XRGrabInteractable>();
        interactable.onSelectEntered.AddListener(OnClick);

    }
    private void OnClick(XRBaseInteractor interactor)
    {
        // This function will be called when the object is clicked
        // Add your desired behavior here
        //Debug.Log("Object clicked!");

        SceneManager.LoadScene(2);

    }
    // Update is called once per frame
    void Update()
    {

    }
}
