using UnityEngine;
using Framework.UI;
using UnityEngine.UI;
using CubeGames.Event;

namespace CubeGames.UI
{
    public class UIRightClickGuideController : UIBaseController
    {
        #region Variables

        [SerializeField] private Image _guideImage;

        [SerializeField] private RightClickGuideEventSO _rightClickGuideEventSO;

		#endregion Variables

		#region Properties

        private Image GuideImage { get => _guideImage; set => _guideImage = value; }
		
		private RightClickGuideEventSO RightClickGuideEventSO { get => _rightClickGuideEventSO; set => _rightClickGuideEventSO = value; }

		#endregion Properties

        #region Functions

        public override void Initialize()
        {
            base.Initialize();
        }

        public void SubscribeEvents()
        {
            RightClickGuideEventSO.OnRightClickDown += OnRightClickDown;
            RightClickGuideEventSO.OnRightClickUp += OnRightClickUp;

            RightClickGuideEventSO.OnRightClickHold += OnRightClickHold;
        }

		public void UnSubscribeEvents()
        {
            RightClickGuideEventSO.OnRightClickDown -= OnRightClickDown;
            RightClickGuideEventSO.OnRightClickUp -= OnRightClickUp;

            RightClickGuideEventSO.OnRightClickHold -= OnRightClickHold;
        }

        private void OnRightClickDown()
		{
            GuideImage.gameObject.SetActive(true);
		}

        private void OnRightClickUp()
        {
            GuideImage.gameObject.SetActive(false);
        }

        private void OnRightClickHold(Vector3 startPosition, Vector3 endPosition)
        {
            Vector3 centre = (startPosition + endPosition) / 2f;

            RectTransform rectTransform = GuideImage.GetComponent<RectTransform>();
            rectTransform.position = centre;

            float width = Mathf.Abs(startPosition.x - endPosition.x);
            float height = Mathf.Abs(startPosition.y - endPosition.y);
            rectTransform.sizeDelta = new Vector2(width, height);
        }

        #endregion Functions
    }
}