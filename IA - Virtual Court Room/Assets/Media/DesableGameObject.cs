using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class DesableGameObject:MonoBehaviour
    {
        public Button BackButton;
        public GameObject UiElement;
    // Start is called before the first frame update
    void Start()
    {
    Button Back = BackButton.GetComponent<Button>();
	Back.onClick.AddListener(TaskOnClick);
    }

    
    // Update is called once per frame
    void Update()
    { 
 
    }
    void TaskOnClick(){
		Debug.Log ("You have clicked the button!");
        if (UiElement.activeSelf == true) {
          UiElement.SetActive(false);
       } 
	}

}
