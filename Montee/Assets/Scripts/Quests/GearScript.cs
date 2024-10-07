using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Quests
{
    public class GearScript : MonoBehaviour
    {
        private const int Counter = 3;
        private bool _isSpinning;

        public GameObject[] lights = new GameObject[3];
        
        public int currentNumber;
        [SerializeField] bool needAtcivation = true;
        [SerializeField] int speedModofication = 1;
        
        private void Start()
        {
            _isSpinning = false;
            currentNumber = 0;
        }
        
        private void FixedUpdate()
        {
            if (_isSpinning || needAtcivation == false)
            {
                transform.Rotate(0f, 0f, -1f * speedModofication);
            }
        }
        
        public void CountUpdate()
        {
            if (currentNumber < Counter)
            {
                lights[currentNumber].GetComponent<Light2D>().color = Color.green;
                currentNumber++;
            }

            if (currentNumber == Counter) 
            {
                _isSpinning = true;
                SoundScripts EMPImpact = FindObjectOfType<SoundScripts>();

                EMPImpact.GearSound(); 
            }
        }
    }
}
