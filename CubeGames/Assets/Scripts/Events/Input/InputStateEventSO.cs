using UnityEngine;
using Framework.Enum;

namespace CubeGames.Event
{
    [CreateAssetMenu]
    public class InputStateEventSO : ScriptableObject
    {
        #region Events

        public delegate void InputStateTypeUpdate(InputStateType inputStateType);
        public event InputStateTypeUpdate StateEnter;
        public event InputStateTypeUpdate StateExit;

        public delegate void InputMouseButtonUp(InputStateType inputStateType);
        public event InputMouseButtonUp OnInputMouseButtonUp;

        #endregion Events

        #region Functions

        public void RaiseOnInputMouseButtonUp(InputStateType inputStateType)
		{
            OnInputMouseButtonUp?.Invoke(inputStateType);
        }

        public void ChangeInputState(InputStateType currentState, InputStateType targetState)
		{
            StateExit?.Invoke(currentState);
            StateEnter?.Invoke(targetState);
		}

        #endregion Functions
    }
}