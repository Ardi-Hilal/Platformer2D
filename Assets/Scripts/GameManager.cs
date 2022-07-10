using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenufrom1(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

    public void MainMenufrom2(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);
    }
    public void Next(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void Retry(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +0);
    }


}
