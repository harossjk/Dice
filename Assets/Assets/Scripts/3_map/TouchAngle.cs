using UnityEngine;
using System.Collections;

public class TouchAngle : MonoBehaviour
{
	private float m_distanceTwo;
	private Vector3 m_touchPosPrev;
	private Touch m_temptoch;
	private bool m_isTouchOn;
	private bool m_isMultiTouchOn;


	private const float m_cameraAnglePerFrame = 1.0f;
	private GameObject m_cameraObj;

	// Use this for initialization
	void Start()
	{
		m_cameraObj = GameObject.Find("Main Camera") as GameObject;
		m_isTouchOn = false;
		m_isMultiTouchOn = false;

		m_touchPosPrev = new Vector3(0.0f, 0.0f, 0.0f);
	}

	// Update is called once per frame
	void Update()
	{
		CameraRotaion();
		//ZoomInOut();
	}
	private void ZoomInOut()
	{
		if (Input.touchCount == 0) return;
		else if (Input.touchCount == 2
			&& (Input.GetTouch(0).phase == TouchPhase.Moved)
			&& (Input.GetTouch(1).phase == TouchPhase.Moved))
		{
			m_isMultiTouchOn = true;
		}
		else if( (Input.GetTouch(0).phase == TouchPhase.Ended) && (Input.GetTouch(1).phase == TouchPhase.Ended))
		{
			m_isMultiTouchOn = false;
		}

		if(m_isMultiTouchOn)
		{
			float delta = 0.0f;
			Vector2 touchPrev = new Vector2(0, 0);
			Vector2 touchCur = new Vector2(0, 0);

			touchCur = Input.GetTouch(0).position - Input.GetTouch(1).position;
			touchPrev = ((Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition)
					  - (Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition));
			delta = touchCur.magnitude - touchPrev.magnitude;


			//Debug.Log("delta : "+ delta + " , touchPrev : "+ touchPrev + " , touchCur : " + touchCur);

			m_distanceTwo -= delta;
			Debug.Log(m_distanceTwo);

			if (m_distanceTwo > 80)
				m_distanceTwo = 80;
			else if (m_distanceTwo < 30)
				m_distanceTwo = 30;

			if (m_distanceTwo < 80 && m_distanceTwo > 30)
			{

				if (delta > 0)
				{
					Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, m_distanceTwo, Time.deltaTime * 5.0f);
				}
				else if (delta < 0)
				{
					Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, m_distanceTwo, Time.deltaTime * 5.0f);
				}
			}
		}
	}

	private void CameraRotaion()
	{
		if (Input.touchCount == 0) return;
		else if (Input.touchCount == 1)
		{
			m_temptoch = Input.GetTouch(0);
			if (m_temptoch.phase == TouchPhase.Began) // touch start 
			{
				m_isTouchOn = true;
				Debug.Log("touch 시작");

				m_touchPosPrev = m_temptoch.position;
			}
			else if (m_temptoch.phase == TouchPhase.Ended) //touch end
			{
				m_isTouchOn = false;
				Debug.Log("touch 종료");
			}
		}
		if (m_isTouchOn)
		{
			Vector3 touchPosCur = new Vector3(0.0f, 0.0f, 0.0f);
			touchPosCur = Input.GetTouch(0).position;
			float delta = touchPosCur.x - m_touchPosPrev.x;

			if (delta < 0)
			{
				Vector3 angle = new Vector3(0.0f, delta * m_cameraAnglePerFrame, 0.0f);
				this.transform.Rotate(angle);
				m_touchPosPrev = Input.GetTouch(0).position;
			}
			else if (0 < delta)
			{
				Vector3 angle = new Vector3(0.0f, delta * m_cameraAnglePerFrame, 0.0f);
				this.transform.Rotate(angle);
				m_touchPosPrev = Input.GetTouch(0).position;
			}
		}
	}
}
