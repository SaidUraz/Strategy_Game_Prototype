using UnityEngine;
using CubeGames.Target;

namespace CubeGames.Manager
{
    public class TargetManager : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TargetController _redTargetController;
        [SerializeField] private TargetController _blueTargetController;
        [SerializeField] private TargetController _yellowTargetController;

		#endregion Variables

		#region Properties

		private TargetController BlueTargetController { get => _blueTargetController; set => _blueTargetController = value; }
		private TargetController RedTargetController { get => _redTargetController; set => _redTargetController = value; }
		private TargetController YellowTargetController { get => _yellowTargetController; set => _yellowTargetController = value; }

		#endregion Properties
    }
}