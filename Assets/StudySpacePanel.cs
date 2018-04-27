using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudySpacePanel : MonoBehaviour {

	public Text titleText;
	public Text subtitleText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetPanelContent (StudySpace studySpace) {
		titleText.text = studySpace.title;
		subtitleText.text = studySpace.distance.ToString() + "mi | Availability: " + studySpace.availability.ToString() +
			" | Friends: " + studySpace.numFriends.ToString();
		GetComponent<Button>().onClick.AddListener(() => SetBottomPanel(studySpace));
	}

	void SetBottomPanel (StudySpace space) {
		BottomPanelManager.current.SetPanelInfo(space);
	}
}
