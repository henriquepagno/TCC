using UnityEngine;

namespace Lean.Touch
{
	public class LeanCameraMove : MonoBehaviour
	{
		[Tooltip("The camera the movement will be done relative to")]
		public Camera Camera;

		[Tooltip("Ignore fingers with StartedOverGui?")]
		public bool IgnoreGuiFingers = true;

		[Tooltip("Ignore fingers if the finger count doesn't match? (0 = any)")]
		public int RequiredFingerCount;

		[Tooltip("The distance from the camera the world drag delta will be calculated from (this only matters for perspective cameras)")]
		public float Distance = 1.0f;

		[Tooltip("The sensitivity of the movement, use -1 to invert")]
		public float Sensitivity = 1f;

        public GameObject gameController;

        protected virtual void LateUpdate()
		{
			// Make sure the camera exists
			if (LeanTouch.GetCamera(ref Camera, gameObject) == true)
			{

                //Busca as informações da Controller do Level.
                LevelController lvl = (LevelController)gameController.GetComponent("LevelController");
                float camPosDown = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane)).y;
                float camPosUp = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane)).y;

                // Get the fingers we want to use
                var fingers = LeanTouch.GetFingers(IgnoreGuiFingers, RequiredFingerCount);

				// Get the world delta of all the fingers
				var worldDelta = LeanGesture.GetWorldDelta(fingers, Distance, Camera);

                if (camPosDown < lvl.MaxCamPosDown)
                    transform.position -= new Vector3(0, camPosDown - lvl.MaxCamPosDown, 0);
                else if (camPosUp > lvl.MaxCamPosUp)
                    transform.position += new Vector3(0, lvl.MaxCamPosUp - camPosUp, 0);
                else if (((camPosDown > lvl.MaxCamPosDown) && worldDelta.y > 0) || ((camPosUp < lvl.MaxCamPosUp) && worldDelta.y < 0))
                {
                    // Pan the camera, on Y, based on the world delta
                    Vector3 move = new Vector3(0, worldDelta.y * Sensitivity, 0);
                    transform.position -= move;
                }

            }
		}
	}
}