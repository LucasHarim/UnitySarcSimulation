using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PropellerSpinningMotionBlur;

public class PropellerSpinning : MonoBehaviour
{   
    public GameObject Propeller1, Propeller2, Propeller3, Propeller4;
    public float rpm;
    private Vector3 relativeUpVector;
    
    //TODO: Add efeito mais realista de rotação. Olhar link abaixo
    //https://docs.unity3d.com/ScriptReference/Rigidbody-angularVelocity.html
    
    private GameObject[] propArray;
    public int numberOfInstances;
    private GameObject[] childPropellers;
    

    // Start is called before the first frame update
    void Start()
    {
        // Efeito motion blur
        propArray = new GameObject[] {Propeller1, Propeller2, Propeller3, Propeller4};

        for (int i = 0; i < 4; i++)

        childPropellers = PropellerSpinningMotionBlur.InstantiatePrefab(
            targetPrefab: propArray[i],
            numberOfInstances: numberOfInstances,
            angleStep: 7.0f);

    }

    // Update is called once per frame
    void Update()
    {
        relativeUpVector = Propeller1.transform.up;

        //helice1 -> ccw
            Propeller1.transform.RotateAround(Propeller1.transform.position,
                                                relativeUpVector,
                                                rpm * Time.deltaTime);

            //helice2 -> cw
            Propeller2.transform.RotateAround(Propeller2.transform.position,
                                                relativeUpVector,
                                                -rpm * Time.deltaTime);

            //helice3 -> ccw
            Propeller3.transform.RotateAround(Propeller3.transform.position,
                                                relativeUpVector,
                                                rpm * Time.deltaTime);
            
            //helice4 -> cw
            Propeller4.transform.RotateAround(Propeller4.transform.position,
                                                relativeUpVector,
                                                -rpm * Time.deltaTime);
        
    }
}
