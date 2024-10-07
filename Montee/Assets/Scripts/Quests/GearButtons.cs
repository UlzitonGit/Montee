using UnityEngine;

namespace Quests
{
    public class GearButtons : MonoBehaviour
    {
        public GearScript gs;
        private bool _isActive;
        
        private void Start()
        {
            _isActive = false;
        }
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player") && !_isActive)
            {
                gs.CountUpdate();
                _isActive = true;
            }
        }
    }
}
