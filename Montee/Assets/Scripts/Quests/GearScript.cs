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
        
        private void Start()
        {
            _isSpinning = false;
            currentNumber = 0;
        }
        
        private void FixedUpdate()
        {
            if (_isSpinning)
            {
                transform.Rotate(0f, 0f, -1f);
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
            }
        }
    }
}
