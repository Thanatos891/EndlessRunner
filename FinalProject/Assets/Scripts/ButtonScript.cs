using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {
    [SerializeField]
    private Button button = null;
	// Use this for initialization
	void Start () {
        button.onClick.AddListener(StartGame);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void StartGame()
    {
        SceneManager.LoadScene("EndlessRunner_Game");
    }
}
