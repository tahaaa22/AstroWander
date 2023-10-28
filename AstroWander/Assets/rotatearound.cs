using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class rotatearound : MonoBehaviour
{
    public Transform targetObject; // The object to rotate around
    public float rotationSpeed = 10f;
    private bool isRotating = true;

    // Update is called once per frame
    void Update()
    {
        if (isRotating)
        transform.RotateAround(targetObject.position, Vector3.up, rotationSpeed * Time.deltaTime);
        //if(rotation.isMoving == false)
        //    isRotating = false;

    }
    
}
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //   // RaycastHit hit;
        //    //if (Physics.Raycast(ray, out hit))
        //    //{
        //    //    if (hit.transform == jupiter.transform)
        //    //    {

        //    //        isRotating = false;
        //    //        warningLogo.SetActive(true); // Show the warning logo
        //    //        StartCoroutine(ShowObjectAndHideWarning());
        //    //    }
        //    //}
        //}
   // }

    //IEnumerator ShowObjectAndHideWarning()
    //{
    //    yield return new WaitForSeconds(delay);
    //    warningLogo.SetActive(false); // Hide the warning logo
    //    //objectToEnter.SetActive(true); // Show the object
    //}
//}