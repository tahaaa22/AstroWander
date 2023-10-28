using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsOrbit : MonoBehaviour
{
    [SerializeField] float orbit_speed = 100f;
    Vector3 rotation_direction = new Vector3(0, 1, 0);

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(orbit_speed * Time.deltaTime * rotation_direction);
    }
}
