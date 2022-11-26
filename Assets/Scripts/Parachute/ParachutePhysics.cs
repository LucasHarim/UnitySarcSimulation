using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class ParachutePhysics
    {

        // float crateMass, drag, angularDrag;
        // Vector3 bracoAlavancaVector;

        // public ParachuteFall(float crateMass, float drag, float angularDrag)
        // {
        //     this.crateMass = crateMass;
        //     this.drag = drag;
        //     this.angularDrag = angularDrag;
        //     this.bracoAlavancaVector = new Vector3(0.0f, 2.0f, 0.0f); // 2m acima do CG

        // }

        public static Vector3 CrateGravForce(float crateMass)
        {
            float gravity = -9.81f; // Para baixo
            Vector3 force = new Vector3(0.0f, gravity*crateMass, 0.0f);

            return force;
        }


        public static float DragForce(float fallVelocityY, float CD)
        {
            float dragForce = CD * fallVelocityY * fallVelocityY;
            return dragForce;
        }

        public static Vector3 TorqueRestaurador(Vector3 bracoAlavancaVector, Vector3 perpendicularCrateWeightComponent)
        {
            Vector3 torque;

            torque = Vector3.Cross(bracoAlavancaVector, perpendicularCrateWeightComponent);
            return torque;
        }
    }   
