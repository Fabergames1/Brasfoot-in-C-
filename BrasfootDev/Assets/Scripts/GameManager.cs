using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GameManager : MonoBehaviour {
	public GameObject PlayingCanvas;
	public GameObject ResoultsCanvas;
	public Text timer;
	public Text goolsHome;
	public Text goolsOther;
	public Team team_A;
	private int goolsA;
	private int goolsB;
	public Team team_B;
	public Player player;
	public GameObject myTeam;
	public GameObject EnemmyTeam;
	public GameObject toDestroy;
	public enum TurnState{
		PROCESSING, //O JOGO ESTA ACONTECENDO E O TEMPO CORRENDO
		WAITING,//TECNICO PEDIU TEMPO
		NOTHING,//O USUARIO NAO SELECIONOU NADA
		FINISHED //ACABOU O JOGO
	
	}
	public TurnState currentState;

	//for the ProgressBar
	private float cur_time = 0f;
	private float max_time = 10f;
	private float calc_timeElapsed;
	private int actionTime = 0;
	public Image ProgressBar;
	
	// Use this for initialization
	void Start () {
		//identify my Team and enemmy team and set their positions
		SetOnScreem();
	
		currentState = TurnState.PROCESSING;
		PlayingCanvas.SetActive(true);
		ResoultsCanvas.SetActive(false);
		StartCoroutine("CompareInXSeconds");//Inicializa a função

		
	}
	IEnumerator CompareInXSeconds(){
		bool isHappening = true;
		int quantasVezes = 0;
		while(isHappening)
		{
			Compare();
			quantasVezes++;
			if(quantasVezes == 3){//limita o numero de vezes que pode acontecer
				isHappening = false;
			}
			yield return new WaitForSeconds(3);
		}
	}
	
	// Update is called once per frame
	void Update () {

		switch(currentState){

			case(TurnState.PROCESSING):
				UpdateProgressBrar();
				RunTimer();
				if(Time.deltaTime <= max_time){
					CompareInXSeconds();
				}
				
			break;
			
			case(TurnState.WAITING):
			break;
			
			case(TurnState.NOTHING):
			break;
			case(TurnState.FINISHED):
				WhoWon();
				currentState = TurnState.NOTHING;
				PlayingCanvas.SetActive(false);
				ResoultsCanvas.SetActive(true);
				SetBackInPosition();

			break;
		}
		
	}
	void Compare(){
		print("comparando...");
		if(team_A.power/team_B.defence >= 1){
			goolsA ++;
			UpdateUI();
			print(team_A.teamName);
		} 
		else if (team_B.power/team_A.defence >= 1){
			goolsB++;
			UpdateUI();
			print(team_B.teamName);
		}
		else{
			print("No Gool");
		}
	}

	void UpdateProgressBrar(){
		
		cur_time = cur_time + Time.deltaTime;
		float calc_timeElapsed = cur_time / max_time;
		ProgressBar.transform.localScale = new Vector3 (Mathf.Clamp(calc_timeElapsed, 0, 1), ProgressBar.transform.localScale.y,ProgressBar.transform.localScale.z); 
		if(cur_time >=max_time){
			currentState = TurnState.FINISHED;
		}

	}
	void UpdateUI(){
		if(goolsA.ToString() != goolsHome.text){
			goolsHome.text = goolsA.ToString();
		}
		if(goolsB.ToString() != goolsOther.text){
			goolsOther.text = goolsB.ToString();
		}
		
	}
	void RunTimer(){
		if(Time.deltaTime < max_time){
			timer.text = (cur_time + Time.deltaTime).ToString("00");	
		}
	}
	void WhoWon(){
		if (goolsA >goolsB){
			print(team_A.teamName + " ganhou!"); 
		}else if( goolsA == goolsB){
			print("Empate!");
		}else{
			print(team_B.teamName + " ganhou!");
		}
	}
	void SetOnScreem(){
		myTeam = TeamController.GetInstance().myTeam;
		if(myTeam == TeamController.GetInstance().LeagueDteams[0]){
			EnemmyTeam = TeamController.GetInstance().LeagueDteams[1];
		}else{
			EnemmyTeam = TeamController.GetInstance().LeagueDteams[0];
		}
		EnemmyTeam.SetActive(true);
		myTeam.transform.position = new Vector3(-1.81f,1.83f,0);
		myTeam.transform.localScale = new Vector3(myTeam.transform.localScale.x/2.04752736f,myTeam.transform.localScale.y/2.04752736f,0);
		EnemmyTeam.transform.position = new Vector3(1.79f, 1.83f,0);
		EnemmyTeam.transform.localScale = new Vector3(EnemmyTeam.transform.localScale.x/2.04752736f,EnemmyTeam.transform.localScale.y/2.04752736f,0);

		team_A = myTeam.GetComponent<Team>();
		team_B = EnemmyTeam.GetComponent<Team>();
		
	}
	public void SetBackInPosition(){
		
		myTeam.transform.localScale = new Vector3((myTeam.transform.localScale.x*2.04752736f)/0.85259677362f,(myTeam.transform.localScale.y*2.04752736f)/0.85259677362f,0);
		
		EnemmyTeam.transform.localScale = new Vector3((EnemmyTeam.transform.localScale.x*2.04752736f)/0.85259677362f,(EnemmyTeam.transform.localScale.y*2.04752736f)/0.85259677362f,0);
		myTeam.transform.position = new Vector3 (0f,1.1f,0);
		if(EnemmyTeam.GetComponent<Team>().teamName == "Na Hora"){
			myTeam.transform.position = new Vector3 (0f,0.5f,0);
		}
		EnemmyTeam.SetActive(false);
		myTeam.SetActive(false);
	}
	public void ActiveToHub(){
		myTeam.SetActive(true);
	}
}