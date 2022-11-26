using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateAndDrop : MonoBehaviour
{

    public GameObject parachutePrefab;
    public GameObject uavPrefab;
    // public float crateMass, drag;

    // public GameObject dronePrefab;
    public int numOfUavs;
    string uavName = "f40";

    public GameObject aircraft;

    public float distanceBetweenParachutes;
    public float uavReleaseHeight;

    Vector3 startPosition, currentPosition;
    int parachutesReleased = 0;
    int uavReleased = 0;

    GameObject[] parachutes;

    public void Start()
    {
        startPosition = aircraft.transform.position;
        currentPosition = startPosition;

        parachutes = new GameObject[numOfUavs];

    }


    public void Update()
    {
        currentPosition = aircraft.transform.position;

        if (Vector3.Distance(currentPosition, startPosition) >= distanceBetweenParachutes && numOfUavs > parachutesReleased)
        {
            parachutes[parachutesReleased] =  InstantiateParachute(parachutePrefab, currentPosition);
            startPosition = currentPosition;
            parachutesReleased += 1;
        }

        // Release the UAVs
        if (uavReleased < numOfUavs)
        {
            
            if (parachutes[uavReleased] != null)
            {
                float height = parachutes[uavReleased].transform.position.y;
                
                Vector3 offset = new Vector3(-33.178f, 2.5f, -3.45f);
                
                if (height < uavReleaseHeight) 
                {
                    Instantiate(uavPrefab, parachutes[uavReleased].transform.position + offset, Quaternion.identity);
                    
                    // Transform parentTransform = parachutes[uavReleased].transform;
                    // Transform uavTransform = parentTransform.Find(uavName);
                    // Rigidbody uavBody = uavTransform.GetComponent<Rigidbody>();
                    // uavBody.useGravity = true;
                    uavReleased +=1;

                }

            }
            
        }


    }


    public GameObject InstantiateParachute(GameObject parachutePrefab, Vector3 position)      
    {   

        Vector3 offset = new Vector3(34.0f, -5.0f, 0.0f);
        position = position + offset;
        GameObject newInstance = Instantiate(parachutePrefab, position, Quaternion.identity);
        return newInstance;
        
    }
}