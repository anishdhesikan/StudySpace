using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SidePanelManager : MonoBehaviour {

	public static SidePanelManager current;

	public GameObject parent;

	public GameObject[] panels;
	public Button[] buttons;

	public Transform closedPos;
	public Transform openPos;

	public bool isOpen;

	void Awake () {
		current = this;
		for (int i = 0; i < buttons.Length; i++) {
			int x = i;
			buttons[i].onClick.AddListener(() => SetPanel(x));
		}
	}

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (isOpen) {
			parent.transform.position = Vector3.Lerp(parent.transform.position, openPos.position, 5f * Time.deltaTime);
		} else {
			parent.transform.position = Vector3.Lerp(parent.transform.position, closedPos.position, 5f * Time.deltaTime);
		}
	}

	public void SetPanel (int index) {
		foreach (GameObject go in panels) {
			go.SetActive(false);
		}
		foreach (Button b in buttons) {
			SetButtonColor(b, Color.gray);
		}
		panels [index].SetActive(true);
		SetButtonColor(buttons[index], Color.white);

		OpenPanel ();
	}


	private void SetButtonColor (Button b, Color c) {
		ColorBlock block = b.colors;
		block.normalColor = c;
		b.colors = block;
	}

	public void OpenPanel () {
		isOpen = true;
	}

	public void ClosePanel () {
		isOpen = false;
		foreach (Button b in buttons) {
			SetButtonColor(b, Color.white);
		}
	}
}
