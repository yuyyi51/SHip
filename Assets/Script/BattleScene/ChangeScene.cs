using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{

    public string NScene;



    // Use this for initialization
    void Start()
    {
		//"Button"为你的Button的名称  
        
		gameObject.GetComponent<Button>().onClick.AddListener(delegate ()
        {
			SceneManager.LoadScene(NScene);
        });
    }

    // Update is called once per frame  
    void Update()
    {
    }

 

}
