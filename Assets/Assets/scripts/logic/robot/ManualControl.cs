using UnityEngine;
using System.Collections.Generic;

public class ManualControl : MonoBehaviour
{
	public WheelsControl w;
	public KlesnyaControl k;
	
	public void UpdateGasMoveSteer(float move, float steer)
	{
		w.UpdateGas(move + steer, move - steer);
	}
	
	public void UpdateGas(float left, float right)
	{
		w.UpdateGas(left, right);
	}
	
	public void SetAngles(float a1, float a2, float rotate, float a3)
	{
		k.SetAngles(a1, a2, rotate, a3);
	}
}

