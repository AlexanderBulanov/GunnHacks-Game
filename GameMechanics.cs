using UnityEngine;
using System.Collections;

public class GameMechanics : MonoBehaviour {
	
	int humanstage = 0; //This is stage of life of human, you start at Baby=0
	double current_time = 0;
	int health;
	int strength;
	double punch_damage;
	double throw_damage;
	int itemweight; //Use this for specifiying item weight individually for each object
	double speed_multiplier;
	double jump_multiplier;



	// Use this for initialization
	void Start () {
		int lifetime_constant;
		
		do
		{
			Console.Write("Enter total game time in seconds between 10000 and 100000 inclusive: ");
			string lifetime = Console.ReadLine();
			Int32.TryParse(lifetime, out lifetime_constant);  
		}
		while (lifetime_constant == 0);
		Convert.ToDouble(lifetime_constant); //Game length(lifetime_constant) is converted to a double
		double stagetime_constant = lifetime_constant/8.0; //Each stage of life is stagetime_constant seconds long
	}
	

	public void UpdateHumanStats() {
		health = (int) (100.0 * Math.Log10(humanstage + 2.0)); //Human's health at a given humanstage
		strength = Math.Round((-(1.0/100.0)) * Math.Pow((humanstage * 20.0 - 100.0), 2.0)) + 100.0; //Human's strength at a given humanstage
		speed_multiplier = ((-(1.0 / 12.5)) * Math.Pow ((humanstage - 5.0), 2.0) + 2.0); //Human's speed multiplier at a given humanstage
		jump_multiplier = ((-(1.0 / 12.5)) * Math.Pow ((humanstage - 5.0), 2.0) + 2.0); //Human's jump multiplier at a given humanstage
		punch_damage = .04 * (strength + itemweight); //Human's punch damage at a given humanstage
		throw_damage = .02 * (strength + itemweight); //Human's throw damage at a given humanstage
	}


	// Update is called once per frame
	void Update () {
		current_time += Time.deltaTime; //This variable counts the time passed during current life stage
		if (current_time/stagetime_constant >= 1) {
			humanstage++; //Changes your stage in life to the next one (ex: Teen to Adult#1)
	}
		UpdateHumanStats(); //Updates your stats based on current stage in life
}
