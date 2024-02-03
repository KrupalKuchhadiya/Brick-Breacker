using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    [SerializeField] float Health;
    [SerializeField] int SwitchNo;
    [SerializeField] Sprite BrickCrackImage;

    private void Start()
    {
        this.gameObject.SetActive(true);
        if (this.gameObject.transform.tag == "Level1Brick")
        {
            Health =  1f;
            SwitchNo = 1;
        }
        if (this.gameObject.transform.tag == "Level2Brick")
        {
            Health =  2f;
            SwitchNo = 2;
        }
        if (this.gameObject.transform.tag == "Level3Brick")
        {
            Health =  3f;
            SwitchNo = 3;
        }
        if (this.gameObject.transform.tag == "Level4Brick")
        {
            Health = 4;
            SwitchNo = 4;
        }
        if (this.gameObject.transform.tag == "Level5Brick")
        {
            Health = 5;
            SwitchNo = 5;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (SwitchNo)
            {
                case 1:
                    Health -= 0.5f;
                    if(Health == 0)
                    {
                        Destroy(this.gameObject);
                    }
                    if(Health == 0.5f)
                    {
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = BrickCrackImage;
                    }
                    break;
                case 2:
                    Health -= 1f;
                    if (Health == 0)
                    {
                        Destroy(this.gameObject);
                    }
                    if (Health == 1f)
                    {
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = BrickCrackImage;
                    }
                    break;
                case 3:
                    Health -= 1;
                    if (Health == 0)
                    {
                        Destroy(this.gameObject);
                    }
                    if (Health == 1f)
                    {
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = BrickCrackImage;
                    }
                    break;
                case 4:
                    Health -= 1;
                    if (Health == 0)
                    {
                        Destroy(this.gameObject);
                    }
                    if (Health == 1f)
                    {
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = BrickCrackImage;
                    }
                    break;
                case 5:
                    Health -= 1;
                   
                    if (Health == 0)
                    {
                        Destroy(this.gameObject);
                    }
                    if (Health == 1f)
                    {
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = BrickCrackImage;
                    }
                    break;
            }
        }
    }
}
