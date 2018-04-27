using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckInButton : MonoBehaviour {

	public Image buttonImage;
	public Text buttonText;

	private Color origColor;
	private string origText;

	// Use this for initialization
	void Start () {
		origColor = buttonImage.color;
		origText = buttonText.text;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClick () {
		StartCoroutine(ClickCoroutine());
	}

	private IEnumerator ClickCoroutine() {
		buttonImage.color = new Color (0.2f, 0.8f, 0.4f);
		buttonText.text = "Checked In";
		yield return new WaitForSeconds (5f);
		buttonImage.color = origColor;
		buttonText.text = origText;
	}
}
