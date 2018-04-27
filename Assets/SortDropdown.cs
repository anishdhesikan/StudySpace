using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortDropdown : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnValueChanged (int index) {
		if (index == 0) {
			MapManager.current.SortByProximity();
		} else if (index == 1) {
			MapManager.current.SortByAvailability();
		} else if (index == 2) {
			MapManager.current.SortByFriends();
		}
	}
}
