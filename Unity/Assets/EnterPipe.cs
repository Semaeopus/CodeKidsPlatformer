using UnityEngine;
using System.Collections;

public class EnterPipe : MonoBehaviour {

    public int nextLevel = 1;

    void OnTriggerEnter2D (Collider2D col)
    {
        //TODO stop character controller
        //TODO animate player going down pipe
        //TODO play pipe sound

        // wait .. seconds and load level
        Debug.Log("loading next level");
        Invoke("LoadNextLevel", 1);
        
       

    }

    void LoadNextLevel() { Application.LoadLevel(nextLevel); }
}
