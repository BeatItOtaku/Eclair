using UnityEngine;
using System.Collections;

/// <summary>
/// カメラを操作します。
/// 外から触るメソッドはStartLockOn、SwitchTarget、StopLockOnだけで十分なはずです。
/// </summary>
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

    public float cameraVerticalAngleOffset = 16;

    public float lockOnFOV = 50;

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

	// 全ての処理が終わったあとにカメラの位置を調整するためにLateUpdateにする
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
            if (isLockOn)
            {
                Vector2 rot = CaliculateTargetRotation(lockOnTarget);
                targetY = rot.y;
                targetAngle = rot.x;
                targetAngle += cameraVerticalAngleOffset;
                //Debug.Log("targetY = " + targetY + ", targetAngle = " + targetAngle);
            }
            else
            {
                float deltaY = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
                float deltaAngle = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;
                //Debug.Log(deltaY + "," + deltaAngle);
                if (Mathf.Abs(deltaY) < 120) targetY += deltaY;
                if (Mathf.Abs(deltaAngle) < 90) targetAngle -= deltaAngle;
            }
		}

        targetAngle = ClampAngle(targetAngle, minAngle, maxAngle);

        if (isLockOn) {//ロックオン状態の時はスムーズにする処理
			currentY = Mathf.LerpAngle (currentY, targetY, smoothFactor);
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


		cameraOffset = new Vector3(0, 0, -distance);
		cameraOffset = Quaternion.Euler(angle, y, 0) * cameraOffset;

		Transform lookAtTransform = lookAt.GetComponent<Transform>();
		cameraTransform.position = lookAtTransform.position + cameraOffset;

		cameraTransform.LookAt(lookAt.GetComponent<Transform>().position);
		cameraTransform.RotateAround (cameraTransform.position, cameraTransform.right, -cameraVerticalAngleOffset);
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

    /// <summary>
    /// とある方向をカメラが向くためのYとAngleの値を算出します。
    /// </summary>
    /// <param name="go">対象のGameObject</param>
    /// <returns>XがAngle、YがY。</returns>
	private Vector2 CaliculateTargetRotation(GameObject go){
		return CaliculateTargetRotation (go.transform.position);
	}

	private Vector2 CaliculateTargetRotation(Vector3 target){
		Quaternion qu =  Quaternion.LookRotation (target - lookAt.transform.position);
        float y = qu.eulerAngles.y;
        qu *= Quaternion.Euler(0, -y, 0);
        float x = qu.eulerAngles.x;
        return new Vector2(x, y);
	}

    /// <summary>
    /// 与えられた値が角度であることを考慮し-90から90の範囲で収まるようにClampします
    /// </summary>
    /// <param name="angle"></param>
    /// <param name="minAngle"></param>
    /// <param name="maxAngle"></param>
    private float ClampAngle(float angle,float minAngle,float maxAngle)
    {
        while (-90 > angle) angle += 360;
        while (angle > 90) angle -= 360;
        return Mathf.Clamp(angle, minAngle, maxAngle);
    }

}