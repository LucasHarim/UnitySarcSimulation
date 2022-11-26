using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerSpinningMotionBlur : MonoBehaviour
{   
    
    /*
        1. Cria uma instância de targetPrefab, chamada newInstance
            1.1 Esta instância está na mesma posição de targetPrefab
            1.2 A nova instância deve ser rotacionada em relação à anterior,
                de um ângulo de angleStep       

    */


    //https://docs.unity3d.com/Manual/InstantiatingPrefabs.html
    //https://docs.unity3d.com/ScriptReference/Transform-parent.html
    //https://docs.unity3d.com/ScriptReference/Transform-localPosition.html

    public static GameObject[] InstantiatePrefab(GameObject targetPrefab, int numberOfInstances,float angleStep)
    {


        Vector3 prefabPosition = targetPrefab.transform.position;
        Quaternion prefabRotation = targetPrefab.transform.rotation;

        GameObject[] childInstances = new GameObject[numberOfInstances];

        for (int i = 0; i < numberOfInstances; i++)
        {
            
            GameObject newInstance = Instantiate(
            targetPrefab,
            prefabPosition,
            prefabRotation);
        
            //  newInstance está associada ao targetPrefab
            newInstance.transform.parent = targetPrefab.transform;
            // Garante que newInstance está de fato na mesma posição de targetPrefab
            newInstance.transform.localPosition = new Vector3(0, 0, 0);
            // Ajusta a escala
            newInstance.transform.localScale = new Vector3(1, 1, 1);
            //  Rotaciona em y o newInstance em relação ao targetPrefab:
            newInstance.transform.localEulerAngles = new Vector3(0, (i+1) * angleStep, 0);
            // newInstance.transform.localRotation = Quaternion.identity;

            childInstances[i] = newInstance;
            
        }
        
        return childInstances;
    }
    
}
