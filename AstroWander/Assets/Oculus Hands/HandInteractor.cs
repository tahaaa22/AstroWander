using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class HandInteractor : XRBaseInteractor
{
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        // Perform your custom action here
        // You can use args.interactable to access the interactable object (if needed).
        // You can also access the GameObject associated with this interactor using this.gameObject.
        Debug.Log("Object clicked!");

    }
}
