using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			//touch.phase                       // This allows us to see the status of the touch (i.e Begun, Canceled, etc.)
			Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
			touchPosition.y = 0;
			transform.position = touchPosition;
		}
    }
}
