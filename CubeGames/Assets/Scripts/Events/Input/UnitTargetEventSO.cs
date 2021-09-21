using UnityEngine;
using CubeGames.Target;

namespace CubeGames.Data
{
    [CreateAssetMenu]
    public class UnitTargetEventSO : ScriptableObject
    {
        #region Events

        public delegate void UnitSentToTarget(TargetController targetController);
        public event UnitSentToTarget OnUnitSentToTarget;

        public delegate void RemoveUnitTarget();
        public event RemoveUnitTarget OnRemoveAllUnitTarget;

        #endregion Events

        #region Functions

        public void RaiseOnUnitSentToTarget(TargetController targetController)
        {
            OnUnitSentToTarget?.Invoke(targetController);
        }

        public void RaiseOnRemoveUnitTarget()
        {
            OnRemoveAllUnitTarget?.Invoke();
        }

        #endregion Functions
    }
}