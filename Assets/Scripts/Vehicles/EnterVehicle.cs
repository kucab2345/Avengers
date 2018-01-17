using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterVehicle : MonoBehaviour {
    
    public GameObject occupant = null;

    private bool driver = false;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.transform.root.tag == "Player" && Input.GetKeyDown("e"))
        {
            Debug.Log("Entering Car");
            occupant = collider.transform.root.gameObject;
            collider.transform.root.position = transform.root.position;
            collider.transform.root.gameObject.SetActive(false);
            collider.transform.root.SetParent(transform.root);

            Camera.main.GetComponent<CameraSlerpPlayer>().player = transform.root.gameObject;

            SendMessageUpwards("PlayerControllingVehicle", SendMessageOptions.RequireReceiver);

            driver = true;
            Debug.Log("Driver: " + occupant.name);
        }
    }
}
