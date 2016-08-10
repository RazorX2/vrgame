using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class double_trigger_start : MonoBehaviour
{
 
    // Use this for initialization
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SteamVR_Controller.Device left = SteamVR_Controller.Input(3);
        SteamVR_Controller.Device right = SteamVR_Controller.Input(4);

        if (left.GetPress(SteamVR_Controller.ButtonMask.Trigger) && right.GetPress(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("both triggers down");
            SceneManager.LoadScene(1);
        }
    }
}