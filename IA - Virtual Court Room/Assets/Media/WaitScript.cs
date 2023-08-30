using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class WaitScript:MonoBehaviour
    {
        public Button MenuButton;
        public GameObject UiElement;
    // Start is called before the first frame update
    void Start()
    {
    Button btn = MenuButton.GetComponent<Button>();
	btn.onClick.AddListener(TaskOnClick);
   
    }
  public IEnumerator WaitForFunction()
    {
        Debug.Log("Hello?");
        yield return new WaitForSeconds(1);
          UiElement.SetActive(true);
       } 
    
    
    
    // Update is called once per frame
    void Update()
    { 
 
    }
    void TaskOnClick(){
		Debug.Log ("You have clicked the button!");
         StartCoroutine(WaitForFunction());
    
	}
    }



