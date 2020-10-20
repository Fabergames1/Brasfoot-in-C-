using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HubUIController : MonoBehaviour {//Vai controlar toda a interface do usuário , principalmente no Hub
	public Text TeamName;
	public Image PowerPB;
	public Image DefencePB;
	public Text CoachName;
	public Text League;
	public Text Money;
	public Text CoachLevel;
	public GameObject myTeam;
	public GameObject otherTeam;
	

	// Use this for initialization
	void Start () {
		//nome do time na tela
		myTeam = TeamController.GetInstance().myTeam;
		TeamName.text = myTeam.GetComponent<Team>().teamName;
		//nome do tecnico na tela
		CoachName.text = CoachController.GetInstance().coach.coachName;
		SetTeamOnScene();
		myTeam.SetActive(true);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void SetTeamOnScene(){
		myTeam.transform.localScale = new Vector3(myTeam.transform.localScale.x* 0.85259677362f, myTeam.transform.localScale.y * 0.85259677362f,    myTeam.transform.localScale.z);
		myTeam.transform.position = new Vector3 (0f,1.1f,0);
		if(myTeam.GetComponent<Team>().teamName == "Na Hora"){
			myTeam.transform.position = new Vector3 (0f,0.5f,0);
		}


		otherTeam = GameObject.FindGameObjectWithTag("OtherTeam");
		otherTeam.SetActive(false);
	}
}
