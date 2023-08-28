using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class WaitScript:MonoBehaviour
    {
        public GameObject UiElement;
    // Start is called before the first frame update
    void Start()
    {
     StartCoroutine(WaitForFunction());
    }
  public IEnumerator WaitForFunction()
    {
        Debug.Log("Hello?");
        yield return new WaitForSeconds(10);
        
        UiElement.SetActive(true); 
       
    }
    
    // Update is called once per frame
    void Update()
    { 
 
    }

    public void Click(){
     Debug.Log("HalloWelt");
     UiElement.SetActive(true);  
    }
}
