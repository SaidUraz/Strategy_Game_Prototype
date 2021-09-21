using UnityEngine;
using Framework.UI;

namespace Framework.Managers
{
    public class CanvasManager : MonoBehaviour
    {
        #region Variables

        [SerializeField] private UIHudController _uIHudController;

		#endregion Variables

		#region Properties

		private UIHudController UIHudController { get => _uIHudController; set => _uIHudController = value; }

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

			UIHudController.Initialize();
		}

        #endregion Functions
    }
}