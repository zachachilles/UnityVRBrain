/************************************************************************************

Copyright   :   Copyright 2014 Oculus VR, LLC. All Rights reserved.

Licensed under the Oculus VR Rift SDK License Version 3.3 (the "License");
you may not use the Oculus VR Rift SDK except in compliance with the License,
which is provided at the time of installation or download, or which
otherwise accompanies this software in either electronic or hard copy form.

You may obtain a copy of the License at

http://www.oculus.com/licenses/LICENSE-3.3

Unless required by applicable law or agreed to in writing, the Oculus VR SDK
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

************************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A head-tracked stereoscopic virtual reality camera rig.
/// </summary>
[ExecuteInEditMode]
public class OVRCameraRig : MonoBehaviour
{
	/// <summary>
	/// The left eye camera.
	/// </summary>
	public Camera leftEyeCamera { get { return (usePerEyeCameras) ? _leftEyeCamera : _centerEyeCamera; } }
	/// <summary>
	/// The right eye camera.
	/// </summary>
	public Camera rightEyeCamera { get { return (usePerEyeCameras) ? _rightEyeCamera : _centerEyeCamera; } }
	/// <summary>
	/// Provides a root transform for all anchors in tracking space.
	/// </summary>
	public Transform trackingSpace { get; private set; }
	/// <summary>
	/// Always coincides with the pose of the left eye.
	/// </summary>
	public Transform leftEyeAnchor { get; private set; }
	/// <summary>
	/// Always coincides with average of the left and right eye poses.
	/// </summary>
	public Transform centerEyeAnchor { get; private set; }
	/// <summary>
	/// Always coincides with the pose of the right eye.
	/// </summary>
	public Transform rightEyeAnchor { get; private set; }
	/// <summary>
	/// Always coincides with the pose of the left hand.
	/// </summary>
	public Transform leftHandAnchor { get; private set; }
	/// <summary>
	/// Always coincides with the pose of the right hand.
	/// </summary>
	public Transform rightHandAnchor { get; private set; }
	/// <summary>
	/// Always coincides with the pose of the sensor.
	/// </summary>
	public Transform trackerAnchor { get; private set; }
	/// <summary>
	/// Occurs when the eye pose anchors have been set.
	/// </summary>
	public event System.Action<OVRCameraRig> UpdatedAnchors;

	/// <summary>
	/// If true, separate cameras will be used for the left and right eyes.
	/// </summary>
	public bool usePerEyeCameras = false;

	/// <summary>
	/// If true, all tracked anchors are updated in FixedUpdate instead of Update to favor physics fidelity.
	/// \note: If the fixed update rate doesn't match the rendering framerate (OVRManager.display.appFramerate), the anchors will visibly judder.
	/// </summary>
	public bool useFixedUpdateForTracking = false;

	private bool _skipUpdate = false;

	private readonly string trackingSpaceName = "TrackingSpace";
	private readonly string trackerAnchorName = "TrackerAnchor";
	private readonly string eyeAnchorName = "EyeAnchor";
	private readonly string handAnchorName = "HandAnchor";
	private readonly string legacyEyeAnchorName = "Camera";
	private Camera _centerEyeCamera;
	private Camera _leftEyeCamera;
	private Camera _rightEyeCamera;

#region Unity Messages
	private void Awake()
	{
		_skipUpdate = true;
		EnsureGameObjectIntegrity();
	}

	private void Start()
	{
		UpdateAnchors();
	}

	private void FixedUpdate()
	{
		if (useFixedUpdateForTracking)
			UpdateAnchors();
	}

	private void Update()
	{
		_skipUpdate = false;

		if (!useFixedUpdateForTracking)
			UpdateAnchors();
	}

#endregion

	private void UpdateAnchors()
	{
		EnsureGameObjectIntegrity();

		if (!Application.isPlaying)
			return;
		
		if (_skipUpdate)
		{
			centerEyeAnchor.FromOVRPose(OVRPose.identity, true);
			leftEyeAnchor.FromOVRPose(OVRPose.identity, true);
			rightEyeAnchor.FromOVRPose(OVRPose.identity, true);

			return;
		}

		bool monoscopic = OVRManager.instance.monoscopic;

		OVRPose tracker = OVRManager.tracker.GetPose();

		trackerAnchor.localRotation = tracker.orientation;
#if UNITY_2017_2_OR_NEWER
		centerEyeAnchor.localRotation = UnityEngine.XR.InputTracking.GetLocalRotation(UnityEngine.XR.XRNode.CenterEye);
        leftEyeAnchor.localRotation = monoscopic ? centerEyeAnchor.localRotation : UnityEngine.XR.InputTracking.GetLocalRotation(UnityEngine.XR.XRNode.LeftEye);
		rightEyeAnchor.localRotation = monoscopic ? centerEyeAnchor.localRotation : UnityEngine.XR.InputTracking.GetLocalRotation(UnityEngine.XR.XRNode.RightEye);
#else
		centerEyeAnchor.localRotation = UnityEngine.VR.InputTracking.GetLocalRotation(UnityEngine.VR.VRNode.CenterEye);
		leftEyeAnchor.localRotation = monoscopic ? centerEyeAnchor.localRotation : UnityEngine.VR.InputTracking.GetLocalRotation(UnityEngine.VR.VRNode.LeftEye);
		rightEyeAnchor.localRotation = monoscopic ? centerEyeAnchor.localRotation : UnityEngine.VR.InputTracking.GetLocalRotation(UnityEngine.VR.VRNode.RightEye);
#endif
		leftHandAnchor.localRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch);
        rightHandAnchor.localRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);

		trackerAnchor.localPosition = tracker.position;
#if UNITY_2017_2_OR_NEWER
		centerEyeAnchor.localPosition = UnityEngine.XR.InputTracking.GetLocalPosition(UnityEngine.XR.XRNode.CenterEye);
		leftEyeAnchor.localPosition = monoscopic ? centerEyeAnchor.localPosition : UnityEngine.XR.InputTracking.GetLocalPosition(UnityEngine.XR.XRNode.LeftEye);
		rightEyeAnchor.localPosition = monoscopic ? centerEyeAnchor.localPosition : UnityEngine.XR.InputTracking.GetLocalPosition(UnityEngine.XR.XRNode.RightEye);
#else
		centerEyeAnchor.localPosition = UnityEngine.VR.InputTracking.GetLocalPosition(UnityEngine.VR.VRNode.CenterEye);
		leftEyeAnchor.localPosition = monoscopic ? centerEyeAnchor.localPosition : UnityEngine.VR.InputTracking.GetLocalPosition(UnityEngine.VR.VRNode.LeftEye);
		rightEyeAnchor.localPosition = monoscopic ? centerEyeAnchor.localPosition : UnityEngine.VR.InputTracking.GetLocalPosition(UnityEngine.VR.VRNode.RightEye);
#endif
        leftHandAnchor.localPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
        rightHandAnchor.localPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);

		if (UpdatedAnchors != null)
		{
			UpdatedAnchors(this);
		}
	}

	public void EnsureGameObjectIntegrity()
	{
		if (trackingSpace == null)
			trackingSpace = ConfigureRootAnchor(trackingSpaceName);

#if UNITY_2017_2_OR_NEWER
		if (leftEyeAnchor == null)
            leftEyeAnchor = ConfigureEyeAnchor(trackingSpace, UnityEngine.XR.XRNode.LeftEye);

		if (centerEyeAnchor == null)
            centerEyeAnchor = ConfigureEyeAnchor(trackingSpace, UnityEngine.XR.XRNode.CenterEye);

		if (rightEyeAnchor == null)
            rightEyeAnchor = ConfigureEyeAnchor(trackingSpace, UnityEngine.XR.XRNode.RightEye);
#else
		if (leftEyeAnchor == null)
			leftEyeAnchor = ConfigureEyeAnchor(trackingSpace, UnityEngine.VR.VRNode.LeftEye);

		if (centerEyeAnchor == null)
			centerEyeAnchor = ConfigureEyeAnchor(trackingSpace, UnityEngine.VR.VRNode.CenterEye);

		if (rightEyeAnchor == null)
			rightEyeAnchor = ConfigureEyeAnchor(trackingSpace, UnityEngine.VR.VRNode.RightEye);
#endif

		if (leftHandAnchor == null)
            leftHandAnchor = ConfigureHandAnchor(trackingSpace, OVRPlugin.Node.HandLeft);

		if (rightHandAnchor == null)
            rightHandAnchor = ConfigureHandAnchor(trackingSpace, OVRPlugin.Node.HandRight);

		if (trackerAnchor == null)
			trackerAnchor = ConfigureTrackerAnchor(trackingSpace);

		if (_centerEyeCamera == null || _leftEyeCamera == null || _rightEyeCamera == null)
		{
			_centerEyeCamera = centerEyeAnchor.GetComponent<Camera>();
			_leftEyeCamera = leftEyeAnchor.GetComponent<Camera>();
			_rightEyeCamera = rightEyeAnchor.GetComponent<Camera>();

			if (_centerEyeCamera == null)
			{
				_centerEyeCamera = centerEyeAnchor.gameObject.AddComponent<Camera>();
				_centerEyeCamera.tag = "MainCamera";
			}

			if (_leftEyeCamera == null)
			{
				_leftEyeCamera = leftEyeAnchor.gameObject.AddComponent<Camera>();
				_leftEyeCamera.tag = "MainCamera";
			}

			if (_rightEyeCamera == null)
			{
				_rightEyeCamera = rightEyeAnchor.gameObject.AddComponent<Camera>();
				_rightEyeCamera.tag = "MainCamera";
			}

			_centerEyeCamera.stereoTargetEye = StereoTargetEyeMask.Both;
			_leftEyeCamera.stereoTargetEye = StereoTargetEyeMask.Left;
			_rightEyeCamera.stereoTargetEye = StereoTargetEyeMask.Right;
		}

		if (_centerEyeCamera.enabled == usePerEyeCameras ||
		    _leftEyeCamera.enabled == !usePerEyeCameras ||
		    _rightEyeCamera.enabled == !usePerEyeCameras)
		{
			_skipUpdate = true;
		}
		
		_centerEyeCamera.enabled = !usePerEyeCameras;
		_leftEyeCamera.enabled = usePerEyeCameras;
		_rightEyeCamera.enabled = usePerEyeCameras;
	}

	private Transform ConfigureRootAnchor(string name)
	{
		Transform root = transform.Find(name);

		if (root == null)
		{
			root = new GameObject(name).transform;
		}

		root.parent = transform;
		root.localScale = Vector3.one;
		root.localPosition = Vector3.zero;
		root.localRotation = Quaternion.identity;

		return root;
	}

#if UNITY_2017_2_OR_NEWER
	private Transform ConfigureEyeAnchor(Transform root, UnityEngine.XR.XRNode eye)
#else
	private Transform ConfigureEyeAnchor(Transform root, UnityEngine.VR.VRNode eye)
#endif
	{
#if UNITY_2017_2_OR_NEWER
		string eyeName = (eye == UnityEngine.XR.XRNode.CenterEye) ? "Center" : (eye == UnityEngine.XR.XRNode.LeftEye) ? "Left" : "Right";
#else
		string eyeName = (eye == UnityEngine.VR.VRNode.CenterEye) ? "Center" : (eye == UnityEngine.VR.VRNode.LeftEye) ? "Left" : "Right";
#endif
		string name = eyeName + eyeAnchorName;
		Transform anchor = transform.Find(root.name + "/" + name);

		if (anchor == null)
		{
			anchor = transform.Find(name);
		}

		if (anchor == null)
		{
			string legacyName = legacyEyeAnchorName + eye.ToString();
			anchor = transform.Find(legacyName);
		}

		if (anchor == null)
		{
			anchor = new GameObject(name).transform;
		}

		anchor.name = name;
		anchor.parent = root;
		anchor.localScale = Vector3.one;
		anchor.localPosition = Vector3.zero;
		anchor.localRotation = Quaternion.identity;

		return anchor;
	}

	private Transform ConfigureHandAnchor(Transform root, OVRPlugin.Node hand)
	{
		string handName = (hand == OVRPlugin.Node.HandLeft) ? "Left" : "Right";
		string name = handName + handAnchorName;
		Transform anchor = transform.Find(root.name + "/" + name);

		if (anchor == null)
		{
			anchor = transform.Find(name);
		}

		if (anchor == null)
		{
			anchor = new GameObject(name).transform;
		}

		anchor.name = name;
		anchor.parent = root;
		anchor.localScale = Vector3.one;
		anchor.localPosition = Vector3.zero;
		anchor.localRotation = Quaternion.identity;

		return anchor;
	}

	private Transform ConfigureTrackerAnchor(Transform root)
	{
		string name = trackerAnchorName;
		Transform anchor = transform.Find(root.name + "/" + name);

		if (anchor == null)
		{
			anchor = new GameObject(name).transform;
		}

		anchor.parent = root;
		anchor.localScale = Vector3.one;
		anchor.localPosition = Vector3.zero;
		anchor.localRotation = Quaternion.identity;

		return anchor;
	}

	public Matrix4x4 ComputeTrackReferenceMatrix()
	{
		if (centerEyeAnchor == null)
		{
			Debug.LogError("centerEyeAnchor is required");
			return Matrix4x4.identity;
		}

		// The ideal approach would be using UnityEngine.VR.VRNode.TrackingReference, then we would not have to depend on the OVRCameraRig. Unfortunately, it is not available in Unity 5.4.3

		OVRPose headPose;
#if UNITY_2017_2_OR_NEWER
		headPose.position = UnityEngine.XR.InputTracking.GetLocalPosition(UnityEngine.XR.XRNode.Head);
		headPose.orientation = UnityEngine.XR.InputTracking.GetLocalRotation(UnityEngine.XR.XRNode.Head);
#else
		headPose.position = UnityEngine.VR.InputTracking.GetLocalPosition(UnityEngine.VR.VRNode.Head);
		headPose.orientation = UnityEngine.VR.InputTracking.GetLocalRotation(UnityEngine.VR.VRNode.Head);
#endif

		OVRPose invHeadPose = headPose.Inverse();
		Matrix4x4 invHeadMatrix = Matrix4x4.TRS(invHeadPose.position, invHeadPose.orientation, Vector3.one);

		Matrix4x4 ret = centerEyeAnchor.localToWorldMatrix * invHeadMatrix;

		return ret;
	}

}
