using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoachController : MonoBehaviour {
	public static CoachController ThisIsTheOneAndOnlyCoachController;
	public Coach coach= new Coach();
	

	// Use this for initialization
	void Start () {
		ThisIsTheOneAndOnlyCoachController = this;
		GameObject.DontDestroyOnLoad(this.gameObject);
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public static CoachController GetInstance(){
		return ThisIsTheOneAndOnlyCoachController;
	}
	// public void GetCoachName(string newText){
	// 	coach.coachName = newText;
	// 	print(coach.coachName);
	// }
}
