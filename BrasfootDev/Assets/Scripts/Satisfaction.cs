using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Satisfaction : MonoBehaviour {
	
	public float rotation; // rotation 0:88 100:-86
	public float satisfaction; //entre 0 e 1 -> vai levar em conta as vitorias
	Image im;
	// Use this for initialization
	void Start () {
		im=GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		rotation = (float)(88.0 - satisfaction*100*1.74);
		if (rotation >= 88.0)
			rotation = 88.0f;
		if (rotation <= -86)
			rotation = -86.0f;
		im.rectTransform.eulerAngles = new Vector3(0,0,rotation);	
			
	}
}
