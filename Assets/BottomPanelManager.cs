using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomPanelManager : MonoBehaviour {

	public static BottomPanelManager current;

	public Text titleText;
	public Text subtitleText;

	void Awake () {
		current = this;
	}

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

	}

	public void SetPanelInfo (StudySpace studySpace) {
		titleText.text = studySpace.title;
		subtitleText.text = "Availability: " + studySpace.availability.ToString() +
		" | Friends: " + studySpace.numFriends.ToString();
	}
}
