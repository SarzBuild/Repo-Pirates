using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GoToCombatOne()
    {
        SceneManager.LoadScene("Combat1");
    }
    public void GoToCombatTwo()
    {
        SceneManager.LoadScene("Combat2");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
