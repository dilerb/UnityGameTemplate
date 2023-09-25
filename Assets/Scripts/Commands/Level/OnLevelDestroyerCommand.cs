using UnityEngine;

namespace Commands.Level
{
    public class OnLevelDestroyerCommand
    {
        private readonly Transform _levelHolder;
        public OnLevelDestroyerCommand(Transform levelHolder)
        {
            _levelHolder = levelHolder;
        }

        public void Execute()
        {
            if (_levelHolder.transform.childCount <= 0)
                return;
            
            // even without MonoBehaviour access Destroy method.
            Object.Destroy(_levelHolder.transform.GetChild(0).gameObject); 
        }
    }
}