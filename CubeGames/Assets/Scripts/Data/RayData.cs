using UnityEngine;

namespace CubeGames.Data
{
    public class RayData
    {
        #region Variables

        private Ray _ray;

		#endregion Variables

		#region Properties

		public Ray Ray { get => _ray; set => _ray = value; }

		#endregion Properties

		#region Functions

        public RayData()
		{
            Ray = new Ray();
		}

		public void Reset()
        {
            Ray = new Ray();
        }

        #endregion Functions
    }
}