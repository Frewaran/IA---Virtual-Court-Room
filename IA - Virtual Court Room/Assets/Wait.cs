namespace Vico
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Wait:MonoBehaviour
    {
        void Start()
        {
            StartCoroutine(WaitForFunction());
        }

        IEnumerator WaitForFunction()
        {
            yield return new WaitForSeconds(3);
            Debug.Log("Hello?");
        }
        
        // Update is called once per frame
        void Update()
        { 
                
        }
    }
}
