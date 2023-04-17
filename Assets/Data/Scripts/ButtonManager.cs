using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



  public class ButtonManager : MonoBehaviour
    {
        public SaveObject QR;
        public float SetScore;
        public float SwitchQuestionsType;
        public float ActivateQ;

    //Header
    //Game Experience Questionnaire
    public GameObject H_InGameExperience;
    //In-game GEQ 
    public GameObject H_InGameGEQ;
    //GEQ - Social Presence Module 
    public GameObject SocialPresence;

    //GEQ – post-game module
    public GameObject PostGame;

    //Save
    public GameObject SaveButton;

    //Q
    //Game Experience Questionnaire 33 - 0

    [Header ("Game Experience Questionnaire")]
    public GameObject Questions1GameExperience_Item1;
    public GameObject Questions2_Item2;
    public GameObject Questions3_Item3;
    public GameObject Questions4_Item4;
    public GameObject Questions5_Item5;

    public GameObject Questions6_Item6;
    public GameObject Questions7_Item7;
    public GameObject Questions8_Item8;
    public GameObject Questions9_Item9;
    public GameObject Questions10_Item10;

    public GameObject Questions11_Item11;
    public GameObject Questions12_Item12;
    public GameObject Questions13_Item13;
    public GameObject Questions14_Item14;
    public GameObject Questions15_Item15;

    public GameObject Questions16_Item16;
    public GameObject Questions17_Item17;
    public GameObject Questions18_Item18;
    public GameObject Questions19_Item19;
    public GameObject Questions20_Item20;

    public GameObject Questions21_Item21;
    public GameObject Questions22_Item22;
    public GameObject Questions23_Item23;
    public GameObject Questions24_Item24;
    public GameObject Questions25_Item25;

    public GameObject Questions26_Item26;
    public GameObject Questions27_Item27;
    public GameObject Questions28_Item28;
    public GameObject Questions29_Item29;
    public GameObject Questions30_Item30;

    public GameObject Questions31_Item31;
    public GameObject Questions32_Item32;
    public GameObject Questions33GameExperience_Item33;

    //Q - 1
    //In-game GEQ 
    [Header("In-game GEQ")]

    public GameObject Questions34Item1;
    public GameObject Questions35_Item2;
    public GameObject Questions36_Item3;
    public GameObject Questions37__Item4;
    public GameObject Questions38_Item5;

    public GameObject Questions39_Item6;
    public GameObject Questions40_Item7;
    public GameObject Questions41_Item8;
    public GameObject Questions42_Item9;
    public GameObject Questions43_Item10;

    public GameObject Questions44_Item11;
    public GameObject Questions45_Item12;
    public GameObject Questions46_Item13;
    public GameObject Questions47GEQ14_Item14;

    //Q - 2
    [Header("Social Presence Module")]
    public GameObject Questions48SPM1_Item1;
    public GameObject Questions49_Item2;
    public GameObject Questions50_Item3;
    public GameObject Questions51_Item4;

    public GameObject Questions52_Item5;
    public GameObject Questions53_Item6;
    public GameObject Questions54_Item7;
    public GameObject Questions55_Item8;

    public GameObject Questions56_Item9;
    public GameObject Questions57_Item10;
    public GameObject Questions58_Item11;
    public GameObject Questions59_Item12;

    public GameObject Questions60_Item13;
    public GameObject Questions61SPM17_Item14;

    public GameObject Questions62_Item15;
    public GameObject Questions63_Item16;
    public GameObject Questions64_Item17;
    //Q - 3
    [Header("Post-Game")]


    public GameObject Questions65_Item1;
    public GameObject Questions66_Item2;
    public GameObject Questions67_Item3;
    public GameObject Questions68_Item4;
    public GameObject Questions69_Item5;

    public GameObject Questions70_Item6;
    public GameObject Questions71_Item7;
    public GameObject Questions72_Item8;
    public GameObject Questions73_Item9;
    public GameObject Questions74_Item10;

    public GameObject Questions75_Item11;
    public GameObject Questions76_Item12;
    public GameObject Questions77_Item13;
    public GameObject Questions78_Item14;
    public GameObject Questions79_Item15;

    public GameObject Questions80_Item16;
    public GameObject Questions81Post17_Item17;



    // Start is called before the first frame update
    void Start()
    {
            ActivateQ = 0;
            SwitchQuestionsType = 0;
            Questions1GameExperience_Item1.SetActive(true);
    }

        // Update is called once per frame
        void Update()
        {
            switch (SwitchQuestionsType)
            {
                case 0:

                
                H_InGameExperience.SetActive(true);
                H_InGameGEQ.SetActive(false);
                SocialPresence.SetActive(false);
                PostGame.SetActive(false);
                break;
                case 1:

                
                H_InGameExperience.SetActive(false);
                H_InGameGEQ.SetActive(true);
                SocialPresence.SetActive(false);
                PostGame.SetActive(false);
                break;

                case 2:

                
                H_InGameExperience.SetActive(false);
                H_InGameGEQ.SetActive(false);
                SocialPresence.SetActive(true);
                PostGame.SetActive(false);
                break;

                case 3:

                
                H_InGameExperience.SetActive(false);
                H_InGameGEQ.SetActive(false);
                SocialPresence.SetActive(false);
                PostGame.SetActive(true);

                break;
            }
        }


     public void ResetNumber()
    {
        SetScore = 0;
    }
        public void Next()
        {
            switch (ActivateQ)
            {
                case 0:
                

                SetDeActiveAll();
                Questions1GameExperience_Item1.SetActive(true);
                QR.Psychological_Involvement_Empathy =+ SetScore;
                QR.In_Game_Sensory_and_Imaginative_Immersion =+ SetScore;
                QR.Positive_affect =+ SetScore;
                QR.Positive_Experience =+ SetScore;
                ResetNumber();
                break;
                case 1:

                
                SetDeActiveAll();
                Questions2_Item2.SetActive(true);
                QR.Negative_experience =+ SetScore;
                QR.Behavioural_Involvement =+ SetScore;
                QR.In_Game_Competence =+ SetScore;
                QR.Competence =+ SetScore;
                ResetNumber();
                break;
                case 2:

                SetDeActiveAll();
               
                Questions3_Item3.SetActive(true);
                QR.Returning_to_Reality =+ SetScore;
                QR.Behavioural_Involvement =+ SetScore;
                QR.In_Game_Negative_affect =+ SetScore;
                QR.Sensory_and_Imaginative_Immersion =+ SetScore;
                ResetNumber();
                break;
                case 3:

                SetDeActiveAll();
               
                Questions4_Item4.SetActive(true);
                QR.Negative_experience += SetScore;
                QR.Psychological_Involvement_Empathy += SetScore;
                QR.In_Game_Sensory_and_Imaginative_Immersion += SetScore;
                QR.Positive_affect += SetScore;
                ResetNumber();
                break;

            case 4:

                SetDeActiveAll();
               
                Questions5_Item5.SetActive(true);
                QR.Positive_Experience += SetScore;
                QR.Behavioural_Involvement += SetScore;
                QR.In_game_Flow += SetScore;
                QR.Flow += SetScore;
                ResetNumber();
                break;

            case 5:

                SetDeActiveAll();
             
                Questions6_Item6.SetActive(true);
                QR.Negative_experience += SetScore;
                QR.Behavioural_Involvement += SetScore;
                QR.In_Game_Tension += SetScore;
                QR.Positive_affect += SetScore;
                ResetNumber();
                break;

            case 6:

                SetDeActiveAll();
              
                Questions7_Item7.SetActive(true);
                QR.Positive_Experience += SetScore;
                QR.Psychological_Involvement_Negative_Feelings += SetScore;
                QR.In_Game_Negative_affect += SetScore;
                QR.Negative_affect += SetScore;
                ResetNumber();
                break;

            case 7:

                SetDeActiveAll();
               
                Questions8_Item8.SetActive(true);
                QR.Positive_Experience += SetScore;
                QR.Psychological_Involvement_Empathy += SetScore;
                QR.In_Game_Tension += SetScore;
                QR.Negative_affect += SetScore;
                ResetNumber();
                break;

            case 8:

                SetDeActiveAll();
              
                Questions9_Item9.SetActive(true);
                QR.Returning_to_Reality += SetScore;
                QR.Psychological_Involvement_Empathy += SetScore;
                QR.In_Game_Competence += SetScore;
                QR.Negative_affect += SetScore;
                ResetNumber();

                break;

            case 9:

                SetDeActiveAll();
            
                Questions10_Item10.SetActive(true);
                QR.Tiredness += SetScore;
                QR.Psychological_Involvement_Empathy += SetScore;
                QR.In_game_Flow += SetScore;
                ResetNumber();
                break;

            case 10:

                SetDeActiveAll();
              
                Questions11_Item11.SetActive(true);
                QR.Negative_experience += SetScore;
                QR.Psychological_Involvement_Negative_Feelings += SetScore;
                QR.IN_Game_Positive_affect += SetScore;
                QR.Challenge += SetScore;
                ResetNumber();
                break;

            case 11:


                SetDeActiveAll();
             
                Questions12_Item12.SetActive(true);
                QR.Positive_Experience += SetScore;
                QR.Psychological_Involvement_Negative_Feelings += SetScore;
                QR.In_Game_Challenge += SetScore;
                QR.Sensory_and_Imaginative_Immersion += SetScore;
                ResetNumber();
                break;

            case 12:

                SetDeActiveAll();
               
                Questions13_Item13.SetActive(true);
                QR.Tiredness += SetScore;
                QR.Psychological_Involvement_Empathy += SetScore;
                QR.In_Game_Challenge += SetScore;
                QR.Flow += SetScore;
                ResetNumber();
                break;

            case 13:

                SetDeActiveAll();
              
                Questions14_Item14.SetActive(true);
                QR.Negative_experience += SetScore;
                QR.Behavioural_Involvement += SetScore;
                QR.IN_Game_Positive_affect += SetScore;
                QR.Positive_affect += SetScore;
                ResetNumber();
                break;

            case 14:

                SetDeActiveAll();
               
                Questions15_Item15.SetActive(true);
                QR.Negative_experience += SetScore;
                QR.Behavioural_Involvement += SetScore;
                QR.Competence += SetScore;
                ResetNumber();
                break;

            case 15:

                SetDeActiveAll();
              
                Questions16_Item16.SetActive(true);
                QR.Positive_Experience += SetScore;
                QR.Psychological_Involvement_Negative_Feelings += SetScore;
                QR.Negative_affect += SetScore;
                ResetNumber();
                break;

            case 16:

                SetDeActiveAll();
           
                Questions17_Item17.SetActive(true);
                QR.Returning_to_Reality += SetScore;
                QR.Psychological_Involvement_Negative_Feelings += SetScore;
                QR.Competence += SetScore;
                ResetNumber();
                break;

            case 17:


                SetDeActiveAll();
        
                Questions18_Item18.SetActive(true);
                QR.Sensory_and_Imaginative_Immersion += SetScore;
                ResetNumber();
                break;

            case 18:


                SetDeActiveAll();
             
                Questions19_Item19.SetActive(true);
                QR.Sensory_and_Imaginative_Immersion += SetScore;
                ResetNumber();
                break;

            case 19:

                SetDeActiveAll();
              
                Questions20_Item20.SetActive(true);
                QR.Positive_affect += SetScore;
                ResetNumber();
                break;

            case 20:


                SetDeActiveAll();
          
                Questions21_Item21.SetActive(true);
                QR.Competence += SetScore;
                ResetNumber();
                break;

            case 21:

                SetDeActiveAll();
              
                Questions22_Item22.SetActive(true);
                QR.Tension_Annoyance += SetScore;
                ResetNumber();
                break;

            case 22:

                SetDeActiveAll();
             
                Questions23_Item23.SetActive(true);
                QR.Challenge += SetScore;
                ResetNumber();
                break;

            case 23:

                SetDeActiveAll();
            
                Questions24_Item24.SetActive(true);
                QR.Tension_Annoyance += SetScore;
                ResetNumber();
                break;

            case 24:

                SetDeActiveAll();
               
                Questions25_Item25.SetActive(true);
                QR.Flow += SetScore;
                ResetNumber();
                break;

            case 25:
  
                SetDeActiveAll();
              
                Questions26_Item26.SetActive(true);
                QR.Challenge += SetScore;
                ResetNumber();
                break;

            case 26:

  
                SetDeActiveAll();
               
                Questions27_Item27.SetActive(true);
                QR.Sensory_and_Imaginative_Immersion += SetScore;
                ResetNumber();
                break;

            case 27:

                SetDeActiveAll();
             
                Questions28_Item28.SetActive(true);
                QR.Flow += SetScore;
                ResetNumber();
                break;

            case 28:

                SetDeActiveAll();
             
                Questions29_Item29.SetActive(true);
                QR.Tension_Annoyance += SetScore;
                ResetNumber();
                break;

            case 29:

                SetDeActiveAll();
          
                Questions30_Item30.SetActive(true);
                QR.Sensory_and_Imaginative_Immersion += SetScore;
                ResetNumber();

                break;

            case 30:

                SetDeActiveAll();
            
                Questions31_Item31.SetActive(true);
                QR.Flow += SetScore;
                ResetNumber();
                break;

            case 31:

                SetDeActiveAll();
             
                Questions32_Item32.SetActive(true);
                QR.Challenge += SetScore;
                ResetNumber();
                break;

            case 32:

                SetDeActiveAll();
              
                Questions33GameExperience_Item33.SetActive(true);
                QR.Challenge += SetScore;
                SwitchQuestionsType = 1;
                ResetNumber();
                break;

            case 33:

                SetDeActiveAll();
             
                Questions34Item1.SetActive(true);
                QR.Positive_Experience += SetScore;
                QR.Psychological_Involvement_Empathy += SetScore;
                QR.In_Game_Sensory_and_Imaginative_Immersion += SetScore;
                QR.Positive_affect += SetScore;
                ResetNumber();
                break;

            case 34:

                SetDeActiveAll();
              
                Questions35_Item2.SetActive(true);
                QR.Negative_experience += SetScore;
                QR.Behavioural_Involvement += SetScore;
                QR.In_Game_Competence += SetScore;
                QR.Competence += SetScore;
                ResetNumber();
                break;

            case 35:

                SetDeActiveAll();
               
                Questions36_Item3.SetActive(true);
                QR.Returning_to_Reality += SetScore;
                QR.Behavioural_Involvement += SetScore;
                QR.In_Game_Negative_affect += SetScore;
                QR.Sensory_and_Imaginative_Immersion += SetScore;
                ResetNumber();
                break;

            case 36:

                SetDeActiveAll();
           
                Questions37__Item4.SetActive(true);
                QR.Negative_experience += SetScore;
                QR.Psychological_Involvement_Empathy += SetScore;
                QR.In_Game_Sensory_and_Imaginative_Immersion += SetScore;
                QR.Positive_affect += SetScore;
                ResetNumber();
                break;

            case 37:

                SetDeActiveAll();
          
                Questions38_Item5.SetActive(true);
                QR.Positive_Experience += SetScore;
                QR.Behavioural_Involvement += SetScore;
                QR.In_game_Flow += SetScore;
                QR.Flow += SetScore;
                ResetNumber();
                break;

            case 38:

                SetDeActiveAll();
            
                Questions39_Item6.SetActive(true);
                QR.Negative_experience += SetScore;
                QR.Behavioural_Involvement += SetScore;
                QR.Positive_affect += SetScore;
                QR.In_Game_Tension += SetScore;
                ResetNumber();
                break;

            case 39:

                SetDeActiveAll();
            
                Questions40_Item7.SetActive(true);
                QR.Positive_Experience += SetScore;
                QR.Psychological_Involvement_Negative_Feelings += SetScore;
                QR.In_Game_Negative_affect += SetScore;
                QR.Negative_affect += SetScore;
                ResetNumber();
                break;

            case 40:

                SetDeActiveAll();
              
                Questions41_Item8.SetActive(true);
                QR.Positive_Experience += SetScore;
                QR.Psychological_Involvement_Empathy += SetScore;
                QR.In_Game_Tension += SetScore;
                QR.Negative_affect += SetScore;
                ResetNumber();
                break;

            case 41:

                SetDeActiveAll();
             
                Questions42_Item9.SetActive(true);
                QR.Returning_to_Reality += SetScore;
                QR.Psychological_Involvement_Empathy += SetScore;
                QR.In_Game_Competence += SetScore;
                QR.Negative_affect += SetScore;
                ResetNumber();
                break;

            case 42:

                SetDeActiveAll();
              
                Questions43_Item10.SetActive(true);
                QR.Tiredness += SetScore;
                QR.Psychological_Involvement_Empathy += SetScore;
                QR.In_game_Flow += SetScore;
                QR.Competence += SetScore;
                ResetNumber();
                break;

            case 43:

                SetDeActiveAll();
            
                Questions44_Item11.SetActive(true);
                QR.Negative_experience += SetScore;
                QR.Psychological_Involvement_Negative_Feelings += SetScore;
                QR.IN_Game_Positive_affect += SetScore;
                QR.Challenge += SetScore;
                ResetNumber();
                break;

            case 44:

                SetDeActiveAll();
               
                Questions45_Item12.SetActive(true);
                QR.Positive_Experience += SetScore;
                QR.Psychological_Involvement_Negative_Feelings += SetScore;
                QR.In_Game_Challenge += SetScore;
                QR.Sensory_and_Imaginative_Immersion += SetScore;
                ResetNumber();
                break;

            case 45:

                SetDeActiveAll();
              
                Questions46_Item13.SetActive(true);
                QR.Tiredness += SetScore;
                QR.Psychological_Involvement_Empathy += SetScore;
                QR.In_Game_Challenge += SetScore;
                QR.Flow += SetScore;
                ResetNumber();
                break;

            case 46:

                SetDeActiveAll();
            
                Questions47GEQ14_Item14.SetActive(true);
                QR.Negative_experience += SetScore;
                QR.Behavioural_Involvement += SetScore;
                QR.IN_Game_Positive_affect += SetScore;
                QR.Positive_affect += SetScore;
                SwitchQuestionsType = 2;
                ResetNumber();
                break;

            case 47:

                SetDeActiveAll();
               
                Questions48SPM1_Item1.SetActive(true);
                QR.Positive_Experience += SetScore;
                QR.Psychological_Involvement_Empathy += SetScore;
                QR.In_Game_Sensory_and_Imaginative_Immersion += SetScore;
                QR.Positive_affect += SetScore;
                ResetNumber();
                break;

            case 48:

                SetDeActiveAll();
                QR.Competence += SetScore;
                Questions49_Item2.SetActive(true);
                QR.Negative_experience += SetScore;
                QR.Behavioural_Involvement += SetScore;
                QR.In_Game_Competence += SetScore;
                ResetNumber();
                break;

            case 49:

                SetDeActiveAll();
               
                Questions50_Item3.SetActive(true);
                QR.Returning_to_Reality += SetScore;
                QR.Behavioural_Involvement += SetScore;
                QR.In_Game_Negative_affect += SetScore;
                QR.Sensory_and_Imaginative_Immersion += SetScore;
                ResetNumber();
                break;
            case 50:

                SetDeActiveAll();
           
                Questions51_Item4.SetActive(true);
                QR.Negative_experience += SetScore;
                QR.Psychological_Involvement_Empathy += SetScore;
                QR.In_Game_Sensory_and_Imaginative_Immersion += SetScore;
                QR.Positive_affect += SetScore;
                ResetNumber();
                break;

            case 51:

                SetDeActiveAll();
               
                Questions52_Item5.SetActive(true);
                QR.Positive_Experience += SetScore;
                QR.Behavioural_Involvement += SetScore;
                QR.In_game_Flow += SetScore;
                QR.Flow += SetScore;
                ResetNumber();
                break;

            case 52:

                SetDeActiveAll();
            
                Questions53_Item6.SetActive(true);
                QR.Negative_experience += SetScore;
                QR.Behavioural_Involvement += SetScore;
                QR.Positive_affect += SetScore;
                QR.In_Game_Tension += SetScore;
                ResetNumber();

                break;

            case 53:

                SetDeActiveAll();
              
                Questions54_Item7.SetActive(true);
                QR.Positive_Experience += SetScore;
                QR.Psychological_Involvement_Negative_Feelings += SetScore;
                QR.In_Game_Negative_affect += SetScore;
                QR.Negative_affect += SetScore;
                ResetNumber();
                break;

            case 54:

                SetDeActiveAll();
             
                Questions55_Item8.SetActive(true);
                QR.Positive_Experience += SetScore;
                QR.Psychological_Involvement_Empathy += SetScore;
                QR.In_Game_Tension += SetScore;
                QR.Negative_affect += SetScore;
                ResetNumber();
                break;

            case 55:

                SetDeActiveAll();
              
                Questions56_Item9.SetActive(true);
                QR.Returning_to_Reality += SetScore;
                QR.Psychological_Involvement_Empathy += SetScore;
                QR.In_Game_Competence += SetScore;
                QR.Negative_affect += SetScore;
                ResetNumber();
                break;

            case 56:

                SetDeActiveAll();
            
                Questions57_Item10.SetActive(true);
                QR.Tiredness += SetScore;
                QR.Psychological_Involvement_Empathy += SetScore;
                QR.In_game_Flow += SetScore;
                QR.Competence += SetScore;
                ResetNumber();
                break;

            case 57:

                SetDeActiveAll();
              
                Questions58_Item11.SetActive(true);
                QR.Negative_experience += SetScore;
                QR.Psychological_Involvement_Negative_Feelings += SetScore;
                QR.IN_Game_Positive_affect += SetScore;
                QR.Challenge += SetScore;
                ResetNumber();
                break;

            case 58:

                SetDeActiveAll();
               
                Questions59_Item12.SetActive(true);
                QR.Positive_Experience += SetScore;
                QR.Psychological_Involvement_Negative_Feelings += SetScore;
                QR.In_Game_Challenge += SetScore;
                QR.Sensory_and_Imaginative_Immersion += SetScore;
                ResetNumber();
                break;

            case 59:

                SetDeActiveAll();
             
                Questions60_Item13.SetActive(true);
                QR.Tiredness += SetScore;
                QR.Psychological_Involvement_Empathy += SetScore;
                QR.In_Game_Challenge += SetScore;
                QR.Flow += SetScore;
                ResetNumber();
                break;

            case 60:
                SwitchQuestionsType = 3;
                SetDeActiveAll();
             
                Questions61SPM17_Item14.SetActive(true);
                QR.Negative_experience += SetScore;
                QR.Behavioural_Involvement += SetScore;
                QR.IN_Game_Positive_affect += SetScore;
                QR.Positive_affect += SetScore;
                ResetNumber();
                break;

            case 61:

                SetDeActiveAll();
              
                Questions62_Item15.SetActive(true);
                QR.Negative_experience += SetScore;
                QR.Behavioural_Involvement += SetScore;
                QR.Competence += SetScore;
                ResetNumber();
                break;

            case 62:

                SetDeActiveAll();
            
                Questions63_Item16.SetActive(true);
                QR.Positive_Experience += SetScore;
                QR.Psychological_Involvement_Negative_Feelings += SetScore;
                QR.Negative_affect += SetScore;
                ResetNumber();
                break;

            case 63:

                SetDeActiveAll();
              
                Questions64_Item17.SetActive(true);
                QR.Returning_to_Reality += SetScore;
                QR.Psychological_Involvement_Negative_Feelings += SetScore;
                QR.Competence += SetScore;
                ResetNumber();
                break;

            case 64:

                SetDeActiveAll();
             
                Questions65_Item1.SetActive(true);
                QR.Positive_Experience += SetScore;
                QR.Psychological_Involvement_Empathy += SetScore;
                QR.In_Game_Sensory_and_Imaginative_Immersion += SetScore;
                QR.Positive_affect += SetScore;
                ResetNumber();
                break;

            case 65:

                SetDeActiveAll();
                QR.Competence += SetScore;
                Questions66_Item2.SetActive(true);
                QR.Negative_experience += SetScore;
                QR.Behavioural_Involvement += SetScore;
                QR.In_Game_Competence += SetScore;
                ResetNumber();
                break;

            case 66:

                SetDeActiveAll();
           
                Questions67_Item3.SetActive(true);
                QR.Returning_to_Reality += SetScore;
                QR.Behavioural_Involvement += SetScore;
                QR.In_Game_Negative_affect += SetScore;
                QR.Sensory_and_Imaginative_Immersion += SetScore;
                ResetNumber();
                break;

            case 67:

                SetDeActiveAll();
              
                Questions68_Item4.SetActive(true);
                QR.Negative_experience += SetScore;
                QR.Psychological_Involvement_Empathy += SetScore;
                QR.In_Game_Sensory_and_Imaginative_Immersion += SetScore;
                QR.Positive_affect += SetScore;
                ResetNumber();
                break;


            case 68:

                SetDeActiveAll();
       
                Questions69_Item5.SetActive(true);
                QR.Positive_Experience += SetScore;
                QR.Behavioural_Involvement += SetScore;
                QR.In_game_Flow += SetScore;
                QR.Flow += SetScore;
                ResetNumber();
                break;

            case 69:

                SetDeActiveAll();
       
                Questions70_Item6.SetActive(true);
                QR.Negative_experience += SetScore;
                QR.Behavioural_Involvement += SetScore;
                QR.In_Game_Tension += SetScore;
                QR.Positive_affect += SetScore;
                ResetNumber();
                break;

            case 70:

                SetDeActiveAll();
           
                Questions71_Item7.SetActive(true);
                QR.Positive_Experience += SetScore;
                QR.Psychological_Involvement_Negative_Feelings += SetScore;
                QR.In_Game_Negative_affect += SetScore;
                QR.Negative_affect += SetScore;
                ResetNumber();
                break;

            case 71:

                SetDeActiveAll();
       
                Questions72_Item8.SetActive(true);
                QR.Positive_Experience += SetScore;
                QR.Psychological_Involvement_Empathy += SetScore;
                QR.In_Game_Tension += SetScore;
                QR.Negative_affect += SetScore;
                ResetNumber();
                break;

            case 72:

                SetDeActiveAll();
             
                Questions73_Item9.SetActive(true);
                QR.Returning_to_Reality += SetScore;
                QR.Psychological_Involvement_Empathy += SetScore;
                QR.In_Game_Competence += SetScore;
                QR.Negative_affect += SetScore;
                ResetNumber();
                break;

            case 73:

                SetDeActiveAll();
                
                Questions74_Item10.SetActive(true);
                QR.Tiredness += SetScore;
                QR.Psychological_Involvement_Empathy += SetScore;
                QR.In_game_Flow += SetScore;
                QR.Competence += SetScore;
                ResetNumber();
                break;

            case 74:

                SetDeActiveAll();
            
                Questions75_Item11.SetActive(true);
                QR.Negative_experience += SetScore;
                QR.Psychological_Involvement_Negative_Feelings += SetScore;
                QR.IN_Game_Positive_affect += SetScore;
                QR.Challenge += SetScore;
                ResetNumber();
                break;

            case 75:

                SetDeActiveAll();
            
                Questions76_Item12.SetActive(true);
                QR.Positive_Experience += SetScore;
                QR.Psychological_Involvement_Negative_Feelings += SetScore;
                QR.In_Game_Challenge += SetScore;
                QR.Sensory_and_Imaginative_Immersion += SetScore;
                ResetNumber();
                break;

            case 76:

                SetDeActiveAll();
           
                Questions77_Item13.SetActive(true);
                QR.Tiredness += SetScore;
                QR.Psychological_Involvement_Empathy += SetScore;
                QR.In_Game_Challenge += SetScore;
                QR.Flow += SetScore;
                ResetNumber();
                break;

            case 77:

                SetDeActiveAll();
               
                Questions78_Item14.SetActive(true);
                QR.Negative_experience += SetScore;
                QR.Behavioural_Involvement += SetScore;
                QR.IN_Game_Positive_affect += SetScore;
                QR.Positive_affect += SetScore;
                QR.Positive_affect += SetScore;
                ResetNumber();
                break;

            case 78:

                SetDeActiveAll();
          
                Questions79_Item15.SetActive(true);
                QR.Negative_experience += SetScore;
                QR.Behavioural_Involvement += SetScore;
                QR.Competence += SetScore;
                ResetNumber();
                break;

            case 79:

                SetDeActiveAll();
              
                Questions80_Item16.SetActive(true);
                QR.Positive_Experience += SetScore;
                QR.Psychological_Involvement_Negative_Feelings += SetScore;
                QR.Negative_affect += SetScore;
                ResetNumber();
                break;

            case 80:

                SetDeActiveAll();
   
                Questions81Post17_Item17.SetActive(true);
                QR.Returning_to_Reality += SetScore;
                QR.Psychological_Involvement_Negative_Feelings += SetScore;
                QR.Competence += SetScore;
                QR.Competence += SetScore;
                ResetNumber();
                SaveButton.SetActive(true);
                break;

            }


        }

    public void SetDeActiveAll()
    {
        NewValue = 0;
        //SetScore = 0;

        SaveButton.SetActive(false);

        Questions1GameExperience_Item1.SetActive(false);
        Questions2_Item2.SetActive(false);
        Questions3_Item3.SetActive(false);
        Questions4_Item4.SetActive(false);
        Questions5_Item5.SetActive(false);
     
        Questions6_Item6.SetActive(false);
        Questions7_Item7.SetActive(false);
        Questions8_Item8.SetActive(false);
        Questions9_Item9.SetActive(false);
        Questions10_Item10.SetActive(false);

        Questions11_Item11.SetActive(false);
        Questions12_Item12.SetActive(false);
        Questions13_Item13.SetActive(false);
        Questions14_Item14.SetActive(false);
        Questions15_Item15.SetActive(false);

        Questions16_Item16.SetActive(false);
        Questions17_Item17.SetActive(false);
        Questions18_Item18.SetActive(false);
        Questions19_Item19.SetActive(false);
        Questions20_Item20.SetActive(false);

        Questions21_Item21.SetActive(false);
        Questions22_Item22.SetActive(false);
        Questions23_Item23.SetActive(false);
        Questions24_Item24.SetActive(false);
        Questions25_Item25.SetActive(false);

        Questions26_Item26.SetActive(false);
        Questions27_Item27.SetActive(false);
        Questions28_Item28.SetActive(false);
        Questions29_Item29.SetActive(false);
        Questions30_Item30.SetActive(false);

        Questions31_Item31.SetActive(false);
        Questions32_Item32.SetActive(false);
        Questions33GameExperience_Item33.SetActive(false);
        Questions34Item1.SetActive(false);
        Questions35_Item2.SetActive(false);

        Questions36_Item3.SetActive(false);
        Questions37__Item4.SetActive(false);
        Questions38_Item5.SetActive(false);
        Questions39_Item6.SetActive(false);
        Questions40_Item7.SetActive(false);

        Questions41_Item8.SetActive(false);
        Questions42_Item9.SetActive(false);
        Questions43_Item10.SetActive(false);
        Questions44_Item11.SetActive(false);
        Questions45_Item12.SetActive(false);

        Questions46_Item13.SetActive(false);
        Questions47GEQ14_Item14.SetActive(false);
        Questions48SPM1_Item1.SetActive(false);
        Questions49_Item2.SetActive(false);
        Questions50_Item3.SetActive(false);

        Questions51_Item4.SetActive(false);
        Questions52_Item5.SetActive(false);
        Questions53_Item6.SetActive(false);
        Questions54_Item7.SetActive(false);
        Questions55_Item8.SetActive(false);

        Questions56_Item9.SetActive(false);
        Questions57_Item10.SetActive(false);
        Questions58_Item11.SetActive(false);
        Questions59_Item12.SetActive(false);

        Questions60_Item13.SetActive(false);
        Questions61SPM17_Item14.SetActive(false);

        Questions62_Item15.SetActive(false);
        Questions63_Item16.SetActive(false);
        Questions64_Item17.SetActive(false);
        Questions65_Item1.SetActive(false);
        Questions66_Item2.SetActive(false);

        Questions67_Item3.SetActive(false);
        Questions68_Item4.SetActive(false);
        Questions69_Item5.SetActive(false);
        Questions70_Item6.SetActive(false);

        Questions71_Item7.SetActive(false);
        Questions72_Item8.SetActive(false);
        Questions73_Item9.SetActive(false);
        Questions74_Item10.SetActive(false);
        Questions75_Item11.SetActive(false);

        Questions76_Item12.SetActive(false);
        Questions77_Item13.SetActive(false);
        Questions78_Item14.SetActive(false);
        Questions79_Item15.SetActive(false);
        Questions80_Item16.SetActive(false);

        Questions81Post17_Item17.SetActive(false);




    }

    public float NewValue;

    public void NotatAl()
    {
            //Score 0
            ActivateQ++;
            Next();
    }

   
        public void SlightLy()
        {

            this.NewValue += 1;
            this.SetScore += NewValue;
            

            ActivateQ++;
            Next();
        }

        public void Moderately()
        {
            //Score 2
            NewValue += 2;
            SetScore += NewValue;
            ActivateQ++;
            Next();

        }

        public void Fairly()
        {
        //Score 3
            NewValue += 3;
            SetScore += NewValue;
            ActivateQ++;
            Next();
        }

        public void Extremely()
        {
            //Score 4
            NewValue += 4;
            SetScore += NewValue;
            ActivateQ++;
            Next();
        }
  }


