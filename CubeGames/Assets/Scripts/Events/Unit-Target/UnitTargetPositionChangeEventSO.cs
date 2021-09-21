using UnityEngine;
using CubeGames.Target;

namespace CubeGames.Event
{
    [CreateAssetMenu]
    public class UnitTargetPositionChangeEventSO : ScriptableObject
    {
        #region Events

        public delegate void TargetPositionUpdated(TargetController targetController);
        public event TargetPositionUpdated OnTargetPositionUpdated;

        #endregion Events

        #region Functions

        public void RaiseOnTargetPositionUpdated(TargetController targetController)
        {
            OnTargetPositionUpdated?.Invoke(targetController);
        }

        #endregion Functions
    }
}