using UnityEngine;

namespace Framework.UI
{
    public class UIBaseController : MonoBehaviour
    {
        #region Variables

        [SerializeField] protected CanvasGroup _canvasGroup;

        #endregion Variables

        #region Properties

        protected CanvasGroup CanvasGroup { get => _canvasGroup; set => _canvasGroup = value; }

		#endregion Properties

		#region OnEnable
		
        protected virtual void OnEnable()
		{
            CanvasGroup.alpha = 1f;
		}
        
        #endregion OnEnable

		#region Functions

		public virtual void Initialize()
        {

        }

        public virtual void ActivateScreen()
        {
            if (!gameObject.activeSelf)
                gameObject.SetActive(true);
        }

        public virtual void DeactivateScreen()
        {
            if (gameObject.activeSelf)
                gameObject.SetActive(false);
        }

        #endregion Functions
    }
}