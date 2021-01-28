using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[Header("General")]
	public CharacterController2D controller;

	public float runSpeed = 40f;
	private float defaultSpeed;

	private float horizontalMove = 0f;
	private bool jump = false;
	private bool crouch = false;

	[Header("Health")]
	public int playerHealth = 3;

	[Header("Items")]
	public bool disableDoubleJump = false;
	public bool onSkateboard = false;
	public float skateboardTimer = 10f;
	public float energyDrinkTimer = 10f;

	private void Start()
    {
		defaultSpeed = runSpeed;
		energyDrink();
    }

    void Update () {

		if (!onSkateboard)
			horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        else
        {
			if (Input.GetAxisRaw("Horizontal") < 0)
				horizontalMove = -1 * runSpeed;
            else if (Input.GetAxisRaw("Horizontal") > 0)
				horizontalMove = runSpeed;
        }

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} 
		else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

	}

	void FixedUpdate ()
	{
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}

	public void skateboard()
    {
		onSkateboard = true;
		//Enable GFX
    }
	
	void endSkateboard()
    {
		onSkateboard = false;
		//Disable GFX
    }


	public void energyDrink()
    {
		runSpeed = (runSpeed * 0.5f) + runSpeed;
		disableDoubleJump = true;
		Invoke("endEnergyDrink", energyDrinkTimer);
		//Enable GFX
    }

	void endEnergyDrink()
    {
		runSpeed = defaultSpeed;
		disableDoubleJump = false;
		//Disable GFX
	}

	void gainHealth()
    {
		if(playerHealth < 3)
			playerHealth++;
    }
	void loseHealth()
    {
		if (playerHealth > 1)
			playerHealth--;
//		else
//			GameOver();
	}
}
