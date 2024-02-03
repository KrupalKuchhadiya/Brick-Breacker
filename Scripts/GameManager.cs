using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] GameObject LeftObject, RightObject, UpObject, DownObject;
    [SerializeField] GameObject TargetObject, GameOverPanel;
    public bool TargetObjectBool;
    [SerializeField] Vector3 StartPos, DragPos;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Paddel;
    public float minZRotation = -90f;
    public float maxZRotation = 90f;
    [SerializeField] List<GameObject> AlreadyBrick;
    bool FirstRelease;
    private void Awake()
    {
        Instance = this;
        Vector2 pos = new Vector2(Screen.width, Screen.height);
        Vector2 ScreenSize = Camera.main.ScreenToWorldPoint(pos);

        LeftObject.GetComponent<BoxCollider2D>().size = new Vector2(1, ScreenSize.y * 2);
        LeftObject.transform.position = new Vector2(-ScreenSize.x - LeftObject.GetComponent<BoxCollider2D>().size.x / 2, 0);


        RightObject.GetComponent<BoxCollider2D>().size = new Vector2(1, ScreenSize.y * 2);
        RightObject.transform.position = new Vector2(ScreenSize.x + RightObject.GetComponent<BoxCollider2D>().size.x / 2, 0);


        UpObject.GetComponent<BoxCollider2D>().size = new Vector2(ScreenSize.x * 2, 1);
        UpObject.transform.position = new Vector2(0, ScreenSize.y + UpObject.GetComponent<BoxCollider2D>().size.y / 2);


        DownObject.GetComponent<BoxCollider2D>().size = new Vector2(ScreenSize.x * 2, 1);
        DownObject.transform.position = new Vector2(0, -ScreenSize.y - DownObject.GetComponent<BoxCollider2D>().size.y / 2);

    }
    Vector3 currentPos;
    float currentPosY, currentPosX;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartPos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
           
                DragPos = StartPos - Input.mousePosition;
                TargetObject.gameObject.transform.GetChild(0).Rotate(new Vector3(0, 0, DragPos.x * 0.4f));
                StartPos = Input.mousePosition;
                currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                currentPosX = Mathf.Clamp(currentPos.x, -3, 3);
                currentPosY = Mathf.Abs(currentPos.y);
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (FirstRelease == false)
            {
                if (TargetObjectBool == false)
                {
                    Player.transform.up = new Vector3(currentPosX, currentPosY, 0);
                    PushBall();
                    TargetObject.SetActive(false);
                    TargetObjectBool = true;
                }
                TargetObject.SetActive(false);
                Player.GetComponent<Rigidbody2D>().gravityScale = 1;
                Paddel.gameObject.transform.GetComponent<BoxCollider2D>().enabled = true;
                Vector2 TargetPosition = new Vector2(StartPos.x, StartPos.y).normalized;
                Debug.Log(TargetPosition);

                Player.GetComponent<Rigidbody2D>().AddForce(TargetPosition * 10f, ForceMode2D.Impulse);
                FirstRelease = true;
            }
        }


        if (AlreadyBrick.Count == 0)
        {
            GameOverPanel.SetActive(false);
        }
    }

    int PushSpeed;
    public void PushBall()
    {
        PushSpeed = 200;
        if (currentPosY > 1.2f || currentPosX > 1.2f)
        {
            PushSpeed = 250;
        }
        else if (currentPosY < 0.5f || currentPosX < 0.5f)
        {
            PushSpeed = 250;
        }
        else
        {
            PushSpeed = 250;
        }

        Vector2 PushDirection = new Vector2(currentPosX, currentPosY).normalized;
        Player.GetComponent<Rigidbody2D>().AddForce(PushDirection * PushSpeed);
    }
}