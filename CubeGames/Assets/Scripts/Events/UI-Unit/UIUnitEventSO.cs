using UnityEngine;

namespace CubeGames.Event
{
    [CreateAssetMenu]
    public class UIUnitEventSO : ScriptableObject
    {
        #region Events

        public delegate void UnitFeatureUpdated(float unitSpeed);
        public event UnitFeatureUpdated OnUnitSpeedUpdated;
        public event UnitFeatureUpdated OnUnitStoppingDistanceUpdated;

        #endregion Events

        #region Functions

        public void RaiseOnUnitSpeedUpdated(float unitSpeed)
        {
            OnUnitSpeedUpdated?.Invoke(unitSpeed);
        }

        public void RaiseOnUnitStoppingDistanceUpdated(float stoppingDistance)
        {
            OnUnitStoppingDistanceUpdated?.Invoke(stoppingDistance);
        }

        #endregion Functions
    }
}