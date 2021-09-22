using UnityEngine;

namespace CubeGames.Target
{
    public class TargetController : MonoBehaviour
    {
		#region Functions

        public void MoveTargetGameObject(Vector3 position)
		{
            position = new Vector3(position.x, transform.position.y, position.z);
            transform.position = position;
		}

        #endregion Functions
    }
}