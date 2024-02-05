using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    public void Level1ButtonClick()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Level2ButtonClick()
    {
        SceneManager.LoadScene("Level2");
    } 
    public void Level3ButtonClick()
    {
        SceneManager.LoadScene("Level3");
    }
    public void Level4ButtonClick()
    {
        SceneManager.LoadScene("Level4");
    } 
}
