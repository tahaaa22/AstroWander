using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class click_option : MonoBehaviour
{
    void Update()
    {

  
         var inputDevices = new List<UnityEngine.XR.InputDevice>();
         UnityEngine.XR.InputDevices.GetDevices(inputDevices);

        foreach (var device in inputDevices)
        {
            Debug.Log(string.Format("Device found with name '{0}' and role '{1}'", device.name, device.role.ToString()));
        }
    }
}
