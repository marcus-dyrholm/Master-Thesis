using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SaveObject : MonoBehaviour
{
    //Name of Person
    public string Name;
    //date
    public string date;
    
        //Game Experience Questionnaire � Core Module
        public float ExperienceScore;
        //In-game GEQ 
        public float InGameScore;
        //GEQ - Social Presence Module 
        public float SocialPresenceScore;
        //GEQ � post-game module
        public float PostGameScore;

    //Scoring guidelines GEQ Core Module
    [Header("Scoring guidelines GEQ Core Module")]
    public float Competence;
    public float Sensory_and_Imaginative_Immersion;
    public float Flow;
    public float Tension_Annoyance;
    public float Challenge;
    public float Negative_affect;
    public float Positive_affect;

    [Header("Scoring guidelines GEQ In-Game version")]
    public float In_Game_Competence;
    public float In_Game_Sensory_and_Imaginative_Immersion;
    public float In_game_Flow;
    public float In_Game_Tension;
    public float In_Game_Challenge;
    public float In_Game_Negative_affect;
    public float IN_Game_Positive_affect;

    [Header("Scoring guidelines GEQ Social Presence Module")]
    public float Psychological_Involvement_Empathy;
    public float Psychological_Involvement_Negative_Feelings;
    public float Behavioural_Involvement;

    [Header("Scoring guidelines GEQ Post-game Module")]
    public float Positive_Experience;
    public float Negative_experience;
    public float Tiredness;
    public float Returning_to_Reality;

}


