using UnityEngine;

namespace Runtime.Commands.Level
{
    public class OnLevelLoaderCommand
    {
        private readonly Transform _levelHolder;
        public OnLevelLoaderCommand(Transform levelHolder)
        {
            _levelHolder = levelHolder;
        }

        public void Execute(byte levelIndex)
        {
            // even without MonoBehaviour access Instantiate method.
            Object.Instantiate(Resources.Load<GameObject>($"Prefabs/Levels/Level {levelIndex}"), _levelHolder, true);
        }
    }
}