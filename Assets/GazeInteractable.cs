using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeInteractable : MonoBehaviour
{

    public Material[] gazeHoverMat;

    private Material[] defaultMat;

    //bool GazeHitStatus = false;

    int matCount = 0;


    void Awake()
    {
        defaultMat = GetComponent<MeshRenderer>().materials;
        matCount = defaultMat.Length;

    }

    public void OnGazeHit()
    {
        for (int i = 0; i < matCount; i++)
            GetComponent<MeshRenderer>().materials[i] = gazeHoverMat[i];
    }
}
