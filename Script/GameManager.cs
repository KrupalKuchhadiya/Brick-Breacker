using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject MainBall, Padel, TargetObject;
    public Vector3 StartPos, DragPos,currentPos;
    public float currentPosX, currentPosY;
    public bool TargetObjectBool, FirstRelease;
    [SerializeField] GameObject UpObject, DownObject, LeftObject, RightObject;
    public List<GameObject> AlreadyExitsBrick;
    public GameObject GameOverPanelLose, GameOverPanelWin;


    private void Awake()
    {
        Instance = this;
       
    }
    private void Start()
    {
        MainBall.GetComponent<CircleCollider2D>().enabled = false;
        MainBall.GetComponent<Rigidbody2D>().gravityScale = 0;

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
        DownObject.tag = "DownObject";


    }
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
                    MainBall.transform.up = new Vector3(currentPosX, currentPosY, 0);
                    PushBall();
                    TargetObject.SetActive(false);
                    TargetObjectBool = true;
                }
                TargetObject.SetActive(false);
                MainBall.GetComponent<Rigidbody2D>().gravityScale = 0;
                MainBall.gameObject.transform.GetComponent<CircleCollider2D>().enabled = true;
                Vector2 TargetPosition = new Vector2(StartPos.x, StartPos.y).normalized;
                Debug.Log(TargetPosition);

                MainBall.GetComponent<Rigidbody2D>().AddForce(TargetPosition * 10f, ForceMode2D.Impulse);
                FirstRelease = true;
            }
                    TargetObjectBool = true;
        }

        if(AlreadyExitsBrick.Count == 0)
        {
            GameOverPanelWin.SetActive(true);
            MainBall.GetComponent<Rigidbody2D>().gravityScale = 0;
            Padel.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void NextButton()
    {
        SceneManager.LoadScene("AllLevel");
    }

    public void PrevButton()
    {
        SceneManager.LoadScene("AllLevel");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    int PushSpeed;
    public void PushBall()
    {
        PushSpeed = 200;
        if (currentPosY > 1.2f || currentPosX > 1.2f)
        {
            PushSpeed = 220;
        }
        else if (currentPosY < 0.5f || currentPosX < 0.5f)
        {
            PushSpeed = 220;
        }
        else
        {
            PushSpeed = 250;
        }

        Vector2 PushDirection = new Vector2(currentPosX, currentPosY).normalized;
        MainBall.GetComponent<Rigidbody2D>().AddForce(PushDirection * PushSpeed);
    }
}
  