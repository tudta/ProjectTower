using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Unit : MonoBehaviour {
    [SerializeField] private float moveSpeed = 0.0f;
    [SerializeField] private float jumpPower = 0.0f;
    private Rigidbody2D rb = null;

    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }
    public float JumpPower { get { return jumpPower; } set { jumpPower = value; } }
    public Rigidbody2D Rb { get { return rb; } set { rb = value; } }

    public virtual void Awake() {

    }

	// Use this for initialization
	public virtual void Start () {
        Init();
	}
	
	// Update is called once per frame
	public virtual void Update () {
		
	}

    public virtual void Init() {
        GameManager.Instance.AllUnits.Add(this);
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void Move(Vector3 direction) {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    public virtual void Jump() {
        rb.AddForce(Vector3.up * jumpPower);
    }
}
