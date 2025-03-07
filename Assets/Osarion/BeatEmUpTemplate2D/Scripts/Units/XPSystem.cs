using UnityEngine;
using System.Collections;

namespace BeatEmUpTemplate2D
{

    //xpsystem class for player, enemy and objects
    public class XPSystem : MonoBehaviour
    {

        public int minStageXP = 0;   // experience points
                                     // 200 XP = 1 SP
        public int maxStageXP = 200;
        public int currentStageXP = 0; //curren stage XP
        public float stageXpPercentage => (float)currentStageXP / (float)maxStageXP;
        public int currentOverallXP = 0; // current overall XP

        public int minSP = 0; // skill points
        public int currentSP = 0; // current skill points

        private GameObject xpBar; // XPbar gameobject to be added

        public delegate void OnXPChange(XPSystem xs); // Renamed the delegate
        public static event OnXPChange onXPChange;

        void OnEnable()
        {
            //add enemies to enemyList
            // if(isEnemy) EnemyManager.AddEnemyToList(gameObject);
        }

        void OnDisable()
        {
            //remove enemies from enemyList
            // if(isEnemy) EnemyManager.RemoveEnemyFromList(gameObject);
        }

        void Start()
        {
            //initialize player healthbar
            if (onXPChange != null) onXPChange(this);
        }

        //substract xp
        public void SubstractXP(int amount)
        {
            //broadcast Event
            SendXPEvent();
        }

        //add xp
        public void AddXP(int amount)
        {
            // print added Xp in the console
            Debug.Log("[XPSystem]\t" + "Added XP: " + amount);

            // add overall xp
            currentOverallXP += amount;

            // add stage xp, if it is greater than maxStageXP, add 1 SP
            if (currentStageXP + amount >= maxStageXP)
            {
                currentSP += 1;
                currentStageXP = (currentStageXP + amount) - maxStageXP;
            }
            else
            {
                currentStageXP += amount;
            }

            // print the current overall xp in the console
            Debug.Log("[XPSystem]\t" + "Current Overall XP: " + currentOverallXP);

            SendXPEvent();
        }

        //xp update event
        private void SendXPEvent()
        {
            // float CurrentXpPercentage = 1f / maxStageXP * currentStageXP;

            if (onXPChange != null) onXPChange(this);
        }


        //adjust xpbar positon
        private void OnValidate()
        {
            if (Application.isPlaying)
            {
            }
        }
    }
}
