using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Aiming : MonoBehaviour
{
    //GraphicRaycaster m_Raycaster;
    //PointerEventData m_PointerEventData;
    //EventSystem m_EventSystem;

    public GameObject lasthit;
    public Vector3 collision = Vector3.zero;
    public GameObject turret;
    RaycastHit hit;

    private void Start()
    {
        ////Fetch the Raycaster from the GameObject (the Canvas)
        //m_Raycaster = GetComponent<GraphicRaycaster>();
        ////Fetch the Event System from the Scene
        //m_EventSystem = GetComponent<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        var ray = new Ray(this.transform.position, this.transform.forward);

        if (Physics.Raycast(ray, out hit, 100))
        {
            lasthit = hit.transform.gameObject;
            collision = hit.point;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Instantiate(turret, collision, lasthit.transform.rotation);
            }
        }

        //if (Input.GetKey(KeyCode.Mouse0))
        //{
        //    //Set up the new Pointer Event
        //    m_PointerEventData = new PointerEventData(m_EventSystem);
        //    //Set the Pointer Event Position to that of the mouse position
        //    m_PointerEventData.position = hit.transform.position;

        //    //Create a list of Raycast Results
        //    List<RaycastResult> results = new List<RaycastResult>();

        //    //Raycast using the Graphics Raycaster and mouse click position
        //    m_Raycaster.Raycast(m_PointerEventData, results);

        //    //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
        //    foreach (RaycastResult result in results)
        //    {
        //        Debug.Log("Hit " + result.gameObject.name);
        //    }
        //}
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(collision, 2.0f);
    }
}
