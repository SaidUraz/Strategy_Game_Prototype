using UnityEngine;
using CubeGames.Cameras;
using CubeGames.Event;

namespace CubeGames.Manager
{
    public class CameraManager : MonoBehaviour
    {
        #region Variables

        [SerializeField] private MainCameraController _mainCameraController;

        #endregion Variables

        #region Properties

        private MainCameraController MainCameraController { get => _mainCameraController; set => _mainCameraController = value; }

        #endregion Properties

        #region Awake

		void Awake()
		{
            SubscribeEvents();
            Initialize();
        }

		#endregion Awake

        #region Functions

        public void Initialize()
        {
            MainCameraController.Initialize();
        }

        public void SubscribeEvents()
        {
            MainCameraController.SubscribeEvents();
        }

        public void UnSubscribeEvents()
        {
            MainCameraController.UnSubscribeEvents();
        }

        #endregion Functions
    }
}