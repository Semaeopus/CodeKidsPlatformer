using UnityEngine;
using System.Collections;

public class EnterPipe : MonoBehaviour {

    public int nextLevel = 1;

    void OnTriggerEnter(Collider col)
    {
        //TODO stop character controller
        //TODO animate player going down pipe
        //TODO play pipe sound

        // wait .. seconds and load level
        Invoke("LoadNextLevel", 1);
        Debug.Log("loading next level");
       

    }

    void LoadNextLevel() { Application.LoadLevel(nextLevel); }
}
