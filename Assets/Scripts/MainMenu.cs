using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    int mapNumber;

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Map1()
    {
        mapNumber = 1;
        SceneManager.LoadScene("Map" + mapNumber);
    }

    public void Map2()
    {
        mapNumber = 2;
        SceneManager.LoadScene("Map" + mapNumber);
    }

    public void Map3()
    {
        mapNumber = 3;
        SceneManager.LoadScene("Map" + mapNumber);
    }
}