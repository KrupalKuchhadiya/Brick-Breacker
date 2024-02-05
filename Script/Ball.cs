using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    int Count;
    [SerializeField] GameObject BallPosition,PadelPosition;
    [SerializeField] List<GameObject> ChanceSprite;

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "DownObject")
        {
            Count++;
            Debug.Log(Count + "Chance Gone");
            this.gameObject.transform.position = BallPosition.transform.position;
            GameManager.Instance.Padel.transform.position = PadelPosition.transform.position;
            this.gameObject.transform.GetComponent<Rigidbody2D>().AddForce(Vector2.zero);
            GameManager.Instance.FirstRelease = false;
            GameManager.Instance.TargetObjectBool = false;
            GameManager.Instance.TargetObject.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                GameManager.Instance.StartPos = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {

                GameManager.Instance.DragPos = GameManager.Instance.StartPos - Input.mousePosition;
                GameManager.Instance.TargetObject.gameObject.transform.GetChild(0).Rotate(new Vector3(0, 0, GameManager.Instance.DragPos.x * 0.4f));
                GameManager.Instance.StartPos = Input.mousePosition;
                GameManager.Instance.currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                GameManager.Instance.currentPosX = Mathf.Clamp(GameManager.Instance.currentPos.x, -3, 3);
                GameManager.Instance.currentPosY = Mathf.Abs(GameManager.Instance.currentPos.y);

            }
            if (Input.GetMouseButtonUp(0))
            {
                if (GameManager.Instance.FirstRelease == false)
                {
                    if (GameManager.Instance.TargetObjectBool == false)
                    {
                        GameManager.Instance.MainBall.transform.up = new Vector3(GameManager.Instance.currentPosX, GameManager.Instance.currentPosY, 0);
                        GameManager.Instance.PushBall();
                        GameManager.Instance.TargetObject.SetActive(false);
                        GameManager.Instance.TargetObjectBool = true;
                    }
                    GameManager.Instance.TargetObject.SetActive(false);
                    GameManager.Instance.MainBall.GetComponent<Rigidbody2D>().gravityScale = 0;
                    GameManager.Instance.MainBall.gameObject.transform.GetComponent<CircleCollider2D>().enabled = true;
                    Vector2 TargetPosition = new Vector2(GameManager.Instance.StartPos.x, GameManager.Instance.StartPos.y).normalized;
                    Debug.Log(TargetPosition);

                    GameManager.Instance.MainBall.GetComponent<Rigidbody2D>().AddForce(TargetPosition * 10f, ForceMode2D.Impulse);
                    GameManager.Instance.FirstRelease = true;
                }
                GameManager.Instance.TargetObjectBool = true;
            }
            Destroy(ChanceSprite[ChanceSprite.Count - 1]);k
            ChanceSprite.Remove(ChanceSprite[ChanceSprite.Count - 1]);
        }
    }

     void Update()
    {
        if(Count == 4)
        {
            Destroy(this.gameObject);
            GameManager.Instance.GameOverPanelLose.SetActive(true);
            Debug.Log("You Lose");
        } 
    }
}
