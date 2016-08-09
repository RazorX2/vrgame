using UnityEngine;
using System.Collections;

public class control : MonoBehaviour {

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < 1)
        {
            print("Razor taking L's");
            this.GetComponent<Rigidbody>().useGravity = false;
        }
	}
    public void OnCollisionEnter(Collision collision) {
        this.GetComponent<Rigidbody>().useGravity = false;
    }
    public void OnCollisionExit(Collision collision)
    {
        this.GetComponent<Rigidbody>().useGravity = true;
    }
}
