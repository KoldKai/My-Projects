using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public int _counter = 0;
 	public Text Counter;

	public float jumpForce = 10f;

	public Rigidbody2D rb;
	public SpriteRenderer sr;

	public bool stay=true; 

	public string currentColor;

	public Color colorCyan;
	public Color colorYellow;
	public Color colorMagenta;
	public Color colorPink;

	void Start()
	{
		SetRandomColor ();
		rb.constraints = RigidbodyConstraints2D.FreezePositionY;
	}
    // Update is called once per frame
    void Update()
    {
    	Counter.text = _counter.ToString();
		if (Input.GetButtonDown ("Jump") || Input.GetMouseButtonDown (0)) {
			rb.velocity = Vector2.up * jumpForce;

			if (stay == true){
			rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
			stay = false;
			}
		}
    }

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "ColorChanger") {
			SetRandomColor();
			Destroy(col.gameObject);
			return;
		}

		if (col.tag == "Bonus") {
			_counter++;
			Destroy(col.gameObject);
			return;
		}

		if (col.tag != currentColor|| col.tag == "DeadLine") {
			Debug.Log ("GAME OVER!");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	void SetRandomColor()
	{
		int index = Random.Range (0, 4);

		switch (index) {
		case 0:
			currentColor = "Cyan";
			sr.color = colorCyan;
			break;
		case 1: 
			currentColor = "Yellow";
			sr.color = colorYellow;
			break;
		case 2: 
			currentColor = "Magenta";
			sr.color = colorMagenta;
			break;
		case 3: 
			currentColor = "Pink";
			sr.color = colorPink;
			break;
		}
	}

}
