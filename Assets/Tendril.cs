using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tendril : MonoBehaviour
{
    // Start is called before the first frame update

    public TendrilInteraction tendrilInteraction;
    public SpriteRenderer TendrilRender;

    public Sprite DefaultSprite;
    public Sprite HoverSprite;



    void Awake()
    {
        tendrilInteraction.OnPointerUpdate += UpdateSprite;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.gameObject.transform);
    }


    public void UpdateSprite(Vector3 point, GameObject hitObject)
    {
        transform.position = point*0.99f;
        if(hitObject)
            gameObject.GetComponent<SpriteRenderer>().sprite = HoverSprite;
        else
            gameObject.GetComponent<SpriteRenderer>().sprite = DefaultSprite;

    }
}
