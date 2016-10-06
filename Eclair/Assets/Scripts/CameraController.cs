using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	public GameObject lookAt;

	public Transform cameraTransform;   // 操作するカメラ
	public float mouseSensitivity = 300.0f;  // マウス感度
	public float defaultDistance = 3.0f;
	public float defaultAngle = 30.0f;//degree
	public float defaultY = 0.0f;

	public float maxAngle = 80.0f;
	public float minAngle = 5.0f;

	public float smoothFactor = 0.5f;

	private float targetY;    // カメラのY軸成分
	private float targetAngle;
	private float currentY;
	private float currentAngle;
	private float distance;
	private Vector3 cameraOffset;

	private bool isLockOn = false;
	private GameObject lockOnTarget;

	private bool cursorIsLocked
	{
		get
		{
			return !Cursor.visible;
		}
		set
		{
			Cursor.visible = !value;
			if (value) Cursor.lockState = CursorLockMode.Locked;
			else Cursor.lockState = CursorLockMode.None;
		}
	}

	public void ResetCamera()
	{
		targetY = defaultY;
		targetAngle = defaultAngle;
	}

	void Start()
	{
		targetY = defaultY;
		targetAngle = defaultAngle;
		distance = defaultDistance;
	}

	void Awake()
	{
		cursorIsLocked = true;
	}

	// 全ての処理が終わったとにカメラの位置を調整するためにLateUpdateにする
	void LateUpdate()
	{
		//カーソル関連
		if (Input.GetButtonDown("Fire1"))
		{
			cursorIsLocked = true;
		}

		if (Input.GetKeyDown("escape"))
		{
			cursorIsLocked = false;
		}

		//float scroll = Input.GetAxis("Mouse ScrollWheel");
		//distance += scroll * 4;
		//Debug.Log("targetY = " + targetY + ", targetAngle = " + targetAngle);
		if (cursorIsLocked) {
			float deltaY = Input.GetAxis ("Mouse X") * Time.deltaTime * mouseSensitivity;
			float deltaAngle = Input.GetAxis ("Mouse Y") * Time.deltaTime * mouseSensitivity;
			Debug.Log (deltaY + "," + deltaAngle);
			if(Mathf.Abs(deltaY) < 90) targetY += deltaY;
			if(Mathf.Abs(deltaAngle) < 90) targetAngle -= deltaAngle;
		}

		if (isLockOn) {//
			currentY = Mathf.Lerp (currentY, targetY, smoothFactor);
			currentAngle = Mathf.Lerp (currentAngle, targetAngle, smoothFactor);
		}
		else {
			currentY = targetY;
			currentAngle = targetAngle;
		}
		setCameraPosition (currentY, currentAngle);

	}

	private void setCameraPosition(float y, float angle){
			//if (angle > maxAngle) angle = maxAngle;
			//if (angle < minAngle) angle = minAngle;
		angle = Mathf.Clamp (angle, minAngle, maxAngle);

		cameraOffset = new Vector3(0, 0, -distance);
		cameraOffset = Quaternion.Euler(angle, y, 0) * cameraOffset;

		Transform lookAtTransform = lookAt.GetComponent<Transform>();
		cameraTransform.position = lookAtTransform.position + cameraOffset;

		cameraTransform.LookAt(lookAt.GetComponent<Transform>().position);
		cameraTransform.RotateAround (cameraTransform.position, cameraTransform.right, -16);
	}

	public void StartLockOn(GameObject target){
		isLockOn = true;
		lockOnTarget = target;
	}
	public void SwitchTarget(GameObject target){
		lockOnTarget = target;
	}
	public void StopLockOn(){
		isLockOn = false;
	}

	private Quaternion CaliculateTargetRotation(GameObject go){
		return CaliculateTargetRotation (go.transform.position);
	}

	private Quaternion CaliculateTargetRotation(Vector3 target){
		return Quaternion.LookRotation (target - transform.position);
	}

}