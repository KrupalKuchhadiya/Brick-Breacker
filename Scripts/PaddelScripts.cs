using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddelScripts : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.transform.GetComponent<BoxCollider2D>().enabled = false;
    }
    void Update()
    {
        if (GameManager.Instance.TargetObjectBool == true)
        {
            if (Input.GetMouseButton(0))
            {
                float MouseInput = Input.GetAxis("Mouse X");
                this.gameObject.transform.position += new Vector3(MouseInput, -3.5f, 0);
                this.gameObject.transform.position = new Vector3(Mathf.Clamp(this.gameObject.transform.position.x, -2, 2), -3.5f, 0);
            }
        }
    }
}