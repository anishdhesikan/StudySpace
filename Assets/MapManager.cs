using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour {

	public static MapManager current;

	public List<StudySpace> currentGroup;
	public GameObject[] scrollViews;
	private int curIndex;

	void Awake () {
		current = this;
		currentGroup = new List<StudySpace> ();
	}

	// Use this for initialization
	void Start () {
		SetScrollView(0);
		SortByProximity();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetScrollView (int index) {
		foreach (GameObject go in scrollViews) {
			go.SetActive(false);
		}
		scrollViews [index].SetActive(true);
		currentGroup = new List<StudySpace> ();
		foreach (StudySpace space in scrollViews [index].GetComponent<StudySpaceGroup>().studySpaces) {
			if (space != null) {
				currentGroup.Add(space);
			}
		}
		AvailableSpacesList.current.SetSpaces(currentGroup);
		curIndex = index;
		ResetZoomCurrent ();
	}

	public void ResetZoomCurrent () {
		scrollViews [curIndex].GetComponent<ScrollRect>().content.localScale = Vector3.one;
	}

	public void ZoomInCurrent () {
		scrollViews [curIndex].GetComponent<ScrollRect>().content.localScale += Vector3.one * 0.25f;
	}

	public void ZoomOutCurrent () {
		if (scrollViews [curIndex].GetComponent<ScrollRect>().content.localScale.magnitude >= 0.5f) {
			scrollViews [curIndex].GetComponent<ScrollRect>().content.localScale -= Vector3.one * 0.25f;
		}
	}

	public void SortByProximity () {
		currentGroup.Sort(SortByProximity);
		AvailableSpacesList.current.SetSpaces(currentGroup);
	}

	public void SortByAvailability () {
		currentGroup.Sort(SortByAvailability);
		AvailableSpacesList.current.SetSpaces(currentGroup);
	}

	public void SortByFriends () {
		currentGroup.Sort(SortByFriends);
		AvailableSpacesList.current.SetSpaces(currentGroup);
	}

	static int SortByProximity(StudySpace s1, StudySpace s2)
	{
		int res = s1.distance.CompareTo(s2.distance);
		if (res == 0) {
			return s1.title.CompareTo(s2.title);
		} else {
			return res;
		}
	}

	static int SortByAvailability(StudySpace s1, StudySpace s2)
	{
		if (s1.availability == StudySpace.Availablity.High) {
			if (s2.availability == StudySpace.Availablity.High) {
				return s1.title.CompareTo(s2.title);
			} else {
				return -1;
			}
		} else {
			if (s2.availability == StudySpace.Availablity.High) {
				return 1;
			} else {
				return s1.title.CompareTo(s2.title);
			}
		}
	}

	static int SortByFriends(StudySpace s1, StudySpace s2)
	{
		int res = -1 * s1.numFriends.CompareTo(s2.numFriends);
		if (res == 0) {
			return s1.title.CompareTo(s2.title);
		} else {
			return res;
		}
	}
}
