using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kc390Flight : MonoBehaviour
{
    //input acceleration instead of thrust
    public float acceleration;
    private float thrust;
    private float aircraftMass;
    
    public GameObject kcModel;
    private Rigidbody kcRigidbody;
    

    // Start is called before the first frame update
    void Start()
    {
        kcRigidbody = kcModel.GetComponent<Rigidbody>();
        aircraftMass = kcRigidbody.mass;
        thrust = aircraftMass * acceleration;
    }

    // Update is called once per frame
    void Update()
    {
        // The minus sign is because relative coordinates of aircraft 3d model 
        // is weird 
        kcRigidbody.AddRelativeForce(-Vector3.forward * thrust);
    }
}
