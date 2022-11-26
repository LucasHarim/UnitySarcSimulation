using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmCircleFormation : MonoBehaviour
{
    public GameObject centralUAV;
    public int numOfUavs = 9;
    public float radius;
    private GameObject[] uavs;

    // Start is called before the first frame update
    void Start()
    {   

        // uavs = new GameObject[numOfUavs];
        // uavs[0] = centralUAV;

        int numArroundUAV = numOfUavs - 1;
        // https://docs.unity3d.com/Manual/InstantiatingPrefabs.html
        for (int i = 0; i < numArroundUAV; i++)
        {   

            float angle = i * Mathf.PI * 2/numArroundUAV;
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            Vector3 pos = transform.position + new Vector3(x, 0, z);

            float angleDegrees = -angle * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.Euler(0, angleDegrees, 0);

            Instantiate(centralUAV, pos, rot); 
            // GameObject go = Instantiate(centralUAV, pos, rot); 
            // uavs[i+1] = go;
        }

    }


    void Update()

    {

    }

    void UpdateSwarmCircle(float x, float y, float dr)
    {

        

    }
    
   
}
