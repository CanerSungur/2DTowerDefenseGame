using UnityEngine;

public class CameraController : MonoBehaviour
{
	public float panSpeed = 10f;
	public float panBorderThickness = 10f;
	
	public float minY;
	public float maxY;
	public float minX;
	public float maxX;

	void Update()
	{
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y , minY, maxY), -10);

		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.mousePosition.y >= Screen.height - panBorderThickness)
		{
			if (transform.position.y >= maxY)
				return;
			transform.Translate(Vector2.up * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Input.mousePosition.y <= panBorderThickness)
		{
			if (transform.position.y <= minY)
				return;
			transform.Translate(Vector2.down * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.mousePosition.x <= panBorderThickness)
		{
			if (transform.position.x <= minX)
				return;
			transform.Translate(Vector2.left * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.mousePosition.x >= Screen.width - panBorderThickness)
		{
			if (transform.position.x >= maxX)
				return;
			transform.Translate(Vector2.right * panSpeed * Time.deltaTime, Space.World);
		}
	}
}
