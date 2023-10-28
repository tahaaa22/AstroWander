using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    
    public GameObject Rings;
    public GameObject Moon1;
    public GameObject Moon2;
    public GameObject Saturn;
    public GameObject Telescope;
    public GameObject pad;
    private bool isRingsActive;
    public MeshRenderer telescopeRenderer;
    public TextMeshPro enceladus_label;
    public TextMeshPro titan_label;

    void Start()
    {
        isRingsActive = Rings.activeSelf;
        telescopeRenderer = GetComponentInChildren<MeshRenderer>();
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            isRingsActive = !isRingsActive;
            Rings.SetActive(isRingsActive);
            Saturn.SetActive(isRingsActive);
            pad.SetActive(isRingsActive);
            Moon1.SetActive(!isRingsActive);
            Moon2.SetActive(!isRingsActive);
            enceladus_label.enabled = isRingsActive;
            titan_label.enabled = isRingsActive;
            telescopeRenderer.enabled = !telescopeRenderer.enabled;
        }
    }

    
}
