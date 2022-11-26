using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ParachutePhysics;

public class ParachuteFall: MonoBehaviour
{

    public Rigidbody parachuteAndCrateRB;
    public float CD;

    float bodyMass, dragForceMag;
    Vector3 gravityForce, dragForceVector, velocity;
    

    public void Start()
    {
        bodyMass = parachuteAndCrateRB.mass;
        gravityForce = ParachutePhysics.CrateGravForce(crateMass: bodyMass);
    }


    public void Update()
    {   
        velocity = parachuteAndCrateRB.velocity;

        dragForceMag = ParachutePhysics.DragForce(fallVelocityY: velocity.y, CD: CD);
        dragForceVector = new Vector3(0.0f, dragForceMag, 0.0f);

        parachuteAndCrateRB.AddRelativeForce(dragForceVector);
        parachuteAndCrateRB.AddForce(gravityForce);


    }

}