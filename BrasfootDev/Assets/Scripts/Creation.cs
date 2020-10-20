using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Creation : MonoBehaviour {
	private List<GameObject> models = new List<GameObject>();
	public InputField inputField;
	
	public Text TeamName;
	// Defaul Index of model
	public int selectionIndex = 0;
	private int indication =0;

	// Use this for initialization
	void Start () {
		foreach (Transform item in transform)
		{
			models.Add(item.gameObject);
			item.gameObject.SetActive(false);
		}
		models[selectionIndex].SetActive(true);

		
	}
	public void SelectNext(){
		indication++;
		Select(indication);
		
		
	}
	public void SelectBack(){
		indication--;
		Select(indication);
		
		
	}
	public void Select (int index){
		if(index == selectionIndex){
			print("nada");
			return;
		}
		if(index <0 || index >= models.Count){
			print("nada");
			return;
		}
		models[selectionIndex].SetActive(false);
		selectionIndex = index;
		models[selectionIndex].SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
	 if(models[selectionIndex].active){
            TeamName.text = models[selectionIndex].GetComponent<Team>().teamName;
        }
	
		
	}
	public void DefineCoachName(string newText){
		CoachController.GetInstance().coach.coachName=inputField.text;
	}
}
