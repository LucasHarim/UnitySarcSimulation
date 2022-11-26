using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateFire : MonoBehaviour
{   

    public GameObject firePrefab;
    public GameObject smokePrefab;
    public int numOfInstances;
    public Vector3 centralPosition;
    public float rangeXZ, rangeY;
    bool smokeHere = true;
    // Start is called before the first frame update

    void Start()
    {
        for (int i = 0; i < numOfInstances; i++)
        {   
            float randomX, randomY,randomZ;
            
            randomX = Random.Range(-rangeXZ, rangeXZ);
            randomY = Random.Range(- rangeY, rangeY);
            randomZ = Random.Range(-rangeXZ, rangeXZ);

            Vector3 position = new Vector3(
                centralPosition.x + randomX,
                centralPosition.y + randomY,
                centralPosition.z + randomZ);

            Instantiate(firePrefab, position, Quaternion.identity);
            
            // Spawnar smoke apenas na metade das instancias do fogo
            if (smokeHere)
            {
                Instantiate(smokePrefab, position, Quaternion.identity);
                smokeHere = false;
            }
            else
            {
                smokeHere = true;
            }
            
        }
    }

}
