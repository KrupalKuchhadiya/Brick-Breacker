using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadelScript : MonoBehaviour
{
    void Update()
    {
        if (GameManager.Instance.TargetObjectBool == true)
        {
            if (Input.GetMouseButton(0))
            {
                float MouseInput = Input.GetAxis("Mouse X");
                this.gameObject.transform.position += new Vector3(MouseInput, -3f, 0);
                this.gameObject.transform.position = new Vector3(Mathf.Clamp(this.gameObject.transform.position.x, -1.5f, 1.5f), -3f, 0);
            }
        }
    }
}
