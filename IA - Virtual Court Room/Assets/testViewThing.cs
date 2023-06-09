using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class testViewThing : MonoBehaviour
{
    public PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        enabled = photonView.IsMine;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
