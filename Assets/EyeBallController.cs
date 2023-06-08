using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EyeBallController : MonoBehaviour
{
    GameObject[] eyeBalls;
    // Start is called before the first frame update


    void Start()
    {
        eyeBalls = GameObject.FindGameObjectsWithTag("EyeBall");
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject eyeball in eyeBalls)
        {

            float x = Camera.main.transform.rotation.eulerAngles.x * -1;
            float y = Camera.main.transform.rotation.eulerAngles.y * -1;


            //TBD: To restrict the Eye ball rotation beyond 90 after which it will be hidden
           
            //DEBUG LOG
            //GameObject.Find("Body").GetComponent<TextMeshProUGUI>().text = y.ToString();

            eyeball.transform.rotation = Quaternion.Euler(x, y, eyeball.transform.rotation.eulerAngles.z);
        }
    }

    public void EnableEyeTracking()
    {

        SceneManager.LoadScene("EyeTrackingEnabled");
        //GameObject.Find("Body").GetComponent<TextMeshProUGUI>().text = "Pressed";

        //GameObject CanvasObj = Instantiate(trackingStatusCanvas, new Vector3(0.5f, 1f, 2f), Quaternion.identity);
        //CanvasObj.transform.parent = Camera.main.transform;
        //CanvasObj.name = "TrackingStatusCanvas";

    }
}
