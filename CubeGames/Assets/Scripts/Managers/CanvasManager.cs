using UnityEngine;
using Framework.UI;
using CubeGames.UI;

namespace Framework.Managers
{
    public class CanvasManager : MonoBehaviour
    {
        #region Variables

        [SerializeField] private UIHudController _uIHudController;
        [SerializeField] private UIRightClickGuideController _uIRightClickGuideController;

		#endregion Variables

		#region Properties

		private UIHudController UIHudController { get => _uIHudController; set => _uIHudController = value; }
		private UIRightClickGuideController UIRightClickGuideController { get => _uIRightClickGuideController; set => _uIRightClickGuideController = value; }

		#endregion Properties

		#region Awake

		void Awake()
		{
			Initialize();
		}

		#endregion Awake

		#region Functions

		public void Initialize()
        {
			UIHudController.SubscribeEvents();
			UIRightClickGuideController.SubscribeEvents();

			UIHudController.Initialize();
			UIRightClickGuideController.Initialize();
		}

        #endregion Functions
    }
}