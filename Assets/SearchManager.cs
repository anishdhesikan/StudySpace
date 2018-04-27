using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchManager : MonoBehaviour {

	public StudySpaceGroup spaces;
	public InputField searchBar;
	public GameObject suggestionsView;
	public SearchList suggestionsList;

	// Use this for initialization
	void Start () {
		searchBar.onValueChanged.AddListener(OnTyped);
		suggestionsList.SetSpaces(new List<StudySpace>());
		suggestionsView.SetActive(false);
	}

	void OnTyped (string input) {
		if (input == "") {
			suggestionsView.SetActive(false);
			return;
		} else {
			suggestionsView.SetActive(true);
		}
		List<StudySpace> searchListings = new List<StudySpace> ();
		foreach (StudySpace space in spaces.studySpaces) {
			if (space.title.ToLower().StartsWith(input.ToLower())) {
				searchListings.Add(space);
			}
		}
		suggestionsList.SetSpaces(searchListings);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
