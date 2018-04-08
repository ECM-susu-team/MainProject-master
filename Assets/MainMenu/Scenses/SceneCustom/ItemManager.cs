using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {
    GameObject APIClass;
    MainAPI api;
	// Use this for initialization
	void Start () {
        APIClass = GameObject.Find("API");
        api = APIClass.GetComponent<MainAPI>();
        api.getUserItems(GlobalControl.Instance.email);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
