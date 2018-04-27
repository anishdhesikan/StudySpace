using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchList : MonoBehaviour {

	public static SearchList current;

	public GameObject panelPrefab;
	[HideInInspector]
	public List<StudySpacePanel> panels;

	// Use this for initialization
	void Awake () {
		current = this;
		panels = new List<StudySpacePanel>(GetComponentsInChildren<StudySpacePanel>());
	}

	// Update is called once per frame
	void Update () {

	}

	public void SetSpaces (List<StudySpace> spaces) {
		DestroyAll();
		foreach (StudySpace space in spaces) {
			CreatePanel(space);
		}
	}

	void DestroyAll() {
		foreach (StudySpacePanel panel in panels) {
			DestroyImmediate(panel.gameObject);
		}
		panels = new List<StudySpacePanel> ();
	}

	void CreatePanel(StudySpace space) {
		GameObject curPanel = Instantiate(panelPrefab, transform);
		curPanel.transform.localScale = Vector3.one;
		StudySpacePanel ssp = curPanel.GetComponent<StudySpacePanel>();
		ssp.SetPanelContent(space);
		panels.Add(ssp);
	}
}
