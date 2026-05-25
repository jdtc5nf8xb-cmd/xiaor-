using UnityEngine;
using System.Collections.Generic;

public class KlesnyaControl : MonoBehaviour
{
	public ArticulationBody k1;
	public ArticulationBody k2;
	public ArticulationBody krotate;
	public ArticulationBody k3;
	
	public void SetAngles(float a1, float a2, float rotate, float a3)
	{
		var k = k1.xDrive;
		k.target = a1;
		k1.xDrive = k;
		
		k = k2.xDrive;
		k.target = a2;
		k2.xDrive = k;
		
		k = k3.xDrive;
		k.target = -a3;
		k3.xDrive = k;
		
		k = krotate.xDrive;
		k.target = rotate;
		krotate.xDrive = k;
	}
}

