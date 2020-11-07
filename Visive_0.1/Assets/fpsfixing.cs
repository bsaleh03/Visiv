using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class fpsfixing : NetworkBehaviour
{
    public GameObject body;
    public GameObject body1;
    public GameObject body2;
    public GameObject body3;

    public GameObject Camera;
    // Start is called before the first frame update
    public GameObject AudioSource;
    void Start()
    {

        if(!isLocalPlayer) 
        {
            Destroy(Camera);
            return;
        }
    }

    // Update is called once per frame
    
    
    //int e = transform.rotation;
    void Update()
    {          
        
        Quaternion startRotation = Camera.transform.rotation;
        Camera.transform.position = transform.position;
        if(isLocalPlayer)
            Camera.transform.parent = null;
            transform.rotation = startRotation;
            Camera.transform.rotation = startRotation;
    }

    public override void OnStartLocalPlayer()
    {
        //base.OnStartLocalPlayer();
       // head.GetComponent<MeshRenderer>().enabled = false;
        body.GetComponent<MeshRenderer>().enabled = false;
        body1.GetComponent<MeshRenderer>().enabled = false;
        body2.GetComponent<MeshRenderer>().enabled = false;
        body3.GetComponent<MeshRenderer>().enabled = false;
    }
}
