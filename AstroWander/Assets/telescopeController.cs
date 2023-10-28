using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class telescopeController : MonoBehaviour
{
    public GameObject Rings;
    public GameObject Moon1;
    public GameObject Moon2;
    public GameObject Saturn;
    public GameObject Telescope;
    public GameObject pad;
    private bool isRingsActive;
    public MeshRenderer telescopeRenderer;

    private XRGrabInteractable interactable;
    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<XRGrabInteractable>();
        interactable.onSelectEntered.AddListener(OnClick);
        isRingsActive = Rings.activeSelf;
        telescopeRenderer = GetComponentInChildren<MeshRenderer>();

    }
    private void OnClick(XRBaseInteractor interactor)
    {
        // This function will be called when the object is clicked
        // Add your desired behavior here
        //Debug.Log("Object clicked!");
        isRingsActive = !isRingsActive;
        Rings.SetActive(isRingsActive);
        Saturn.SetActive(isRingsActive);
        pad.SetActive(isRingsActive);
        Moon1.SetActive(!isRingsActive);
        Moon2.SetActive(!isRingsActive);
        telescopeRenderer.enabled = !telescopeRenderer.enabled;

    }
    // Update is called once per frame
    void Update()
    {

    }
}
