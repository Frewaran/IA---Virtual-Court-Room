using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextFollowsCamera : MonoBehaviour
{
    private bool isSelected = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected)
        {
            transform.LookAt(Camera.main.transform);
            transform.Rotate(0, 180, 0);
        }
    }

    public void textVisible()
    {
        transform.GetComponent<TextMeshPro>().enabled = true;
        transform.parent.GetComponent<MeshRenderer>().enabled = false;
        isSelected = true;
    }

    public void textNotVisible()
    {
        transform.GetComponent<TextMeshPro>().enabled = false;
        transform.parent.GetComponent<MeshRenderer>().enabled = true;
        isSelected = false;
    }
}
