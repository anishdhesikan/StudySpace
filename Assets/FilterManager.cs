using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilterManager : MonoBehaviour {

	public Toggle highAvailableToggle;
	public Toggle lowAvailableToggle;
	public Toggle friendsToggle;
	public Button filterButton;

	// Use this for initialization
	void Start () {
		filterButton.onClick.AddListener(Filter);
		gameObject.SetActive(false);
	}

	void Filter () {
		if (friendsToggle.isOn) {
			if (highAvailableToggle.isOn && lowAvailableToggle.isOn) {
				MapManager.current.SetScrollView(6);
			} else if (highAvailableToggle.isOn) {
				MapManager.current.SetScrollView(4);
			} else if (lowAvailableToggle.isOn) {
				MapManager.current.SetScrollView(5);
			} else {
				MapManager.current.SetScrollView(6); // no map available with just friends, no availability red/green
			}
		} else {
			if (highAvailableToggle.isOn && lowAvailableToggle.isOn) {
				MapManager.current.SetScrollView(3);
			} else if (highAvailableToggle.isOn) {
				MapManager.current.SetScrollView(2);
			} else if (lowAvailableToggle.isOn) {
				MapManager.current.SetScrollView(1);
			} else {
				MapManager.current.SetScrollView(0);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
