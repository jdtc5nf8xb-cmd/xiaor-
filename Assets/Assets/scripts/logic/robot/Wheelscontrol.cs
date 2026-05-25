using UnityEngine;
using System.Collections.Generic;

public class WheelsControl : MonoBehaviour
{
	public float maxVelocity = 500f; // Градусы в секунду
	public float force = 1000f;

	private List<ArticulationBody> leftTrack = new List<ArticulationBody>();
	private List<ArticulationBody> rightTrack = new List<ArticulationBody>();


	public void UpdateGas(float left, float right)
	{
		UpdateWheels(leftTrack, left);
		UpdateWheels(rightTrack, right);
	}


	void UpdateWheels(List<ArticulationBody> wheels, float gas)
	{
		foreach (var wheel in wheels)
		{
			var drive = wheel.xDrive;
			
			drive.forceLimit = force;
			drive.stiffness = 0f; 
			drive.damping = 1f;
			
			
			var v = gas * maxVelocity;
			drive.targetVelocity = v < maxVelocity ? v : maxVelocity * Mathf.Sign(gas);
			
			
			wheel.xDrive = drive;
			
		}
	}
	
	void Start()
	{
		var allBodies = GetComponentsInChildren<ArticulationBody>();

		foreach (var body in allBodies)
		{
			// Пропускаем сам корпус (root)
			if (body.isRoot) continue;

			// Сортируем по имени или родителю
			if (body.name.StartsWith("L"))
			{
				leftTrack.Add(body);
			}
			else if (body.name.TrimStart().StartsWith("R")) 
			{
				rightTrack.Add(body);
			}
		}
	}
}

