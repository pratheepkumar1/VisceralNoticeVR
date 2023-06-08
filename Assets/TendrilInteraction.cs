using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;

public class TendrilInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject GazeIndicator;
    //GameObject obj;

    float offset;
    float radius;




    //CUSTOM RAYCAST POINTER
    public float gazeDefaultDistance = 2f;

    //public LineRenderer gazeLineRenderer = null;
    public LayerMask gazeEverythingMask = 0;
    public LayerMask gazeInteractableMask = 0;

    private Transform gazeCurrentOrigin = null;
    private GameObject gazeCurrentObject = null;


    public UnityAction<Vector3, GameObject> OnPointerUpdate = null;




    void Start()
    {
        //// y_text = GameObject.Find("LeftHandDebug").GetComponent<Text>();
        //Vector3 pos = new Vector3(0, 0, 0);
        //obj = Instantiate(GazeIndicator, pos, Quaternion.identity);
        //offset = 0.05f;




    }

    // Update is called once per frame
    void Update()
    {
        //// FOR DEBUGGING OFFSET REQUIRED
        //// offset += (OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).y * 0.01f); 
        //Vector3 camPos = Camera.main.transform.position;
        //Quaternion camRot = Camera.main.transform.rotation;

        //Vector3 camForward = Camera.main.transform.forward;

        //// Gaze pointer in VR
        //radius = 2f;
        //Vector3 targetPos = camPos + camForward * radius;
        //targetPos += Camera.main.transform.right * offset;
        //targetPos += Camera.main.transform.up * offset;
        //obj.transform.position = Vector3.MoveTowards(obj.transform.position, targetPos, Vector3.Distance(obj.transform.position, targetPos));
        //obj.transform.rotation = camRot;


        //CUSTOM RAYCAST POINTER

        gazeCurrentOrigin = Camera.main.transform;
        Vector3 hitPoint = UpdateLine();

        gazeCurrentObject = UpdatePointerStatus();

        if (OnPointerUpdate != null)
            OnPointerUpdate(hitPoint, gazeCurrentObject);
    }



    // TENDRILS POSITION ----------------------------------


    private Vector3 UpdateLine()
    {
        // Create ray
        RaycastHit hit = CreateRaycast(gazeEverythingMask);

        // Default End
        Vector3 gazeEndPosition = gazeCurrentOrigin.position + (gazeCurrentOrigin.forward * gazeDefaultDistance);

        // Check hit
        if (hit.collider != null)
            gazeEndPosition = hit.point;

        // Set position
        //gazeLineRenderer.SetPosition(0, gazeCurrentOrigin.position);
        //gazeLineRenderer.SetPosition(1, gazeEndPosition);

        return gazeEndPosition;
    }


    private void UpdateOrigin(Transform controllerOrigin, GameObject controllerObject)
    {
        gazeCurrentOrigin = controllerOrigin;


    }




    // INTERACTABLE OBJECT CODE ----------------------------------


    private GameObject UpdatePointerStatus()
    {
        // Create ray
        RaycastHit hit = CreateRaycast(gazeInteractableMask);

        // Check hit
        if (hit.collider)
            return hit.collider.gameObject;

        // Return
        return null;

    }


    private void OnHitEvent()
    {
        if (!gazeCurrentObject)
            return;

        GazeInteractable gazeInteractable = gazeCurrentObject.GetComponent<GazeInteractable>();
        gazeInteractable.OnGazeHit();

    }


    // DRAWING RAY ----------------------------------------------

    private RaycastHit CreateRaycast(int layer)
    {
        RaycastHit hit;
        Ray ray = new Ray(gazeCurrentOrigin.position, gazeCurrentOrigin.forward);
        Physics.Raycast(ray, out hit, gazeDefaultDistance, layer);
        return hit;
    }



}


