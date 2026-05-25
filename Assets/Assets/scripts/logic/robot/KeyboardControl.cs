using UnityEngine;
using System.Collections.Generic;

public class KeyboardControl : ManualControl
{
	private float angle1, angle2, rotation, angle3;
	
	public float speed = 50f;
	
	
	void Start()
	{
		// Получаем ссылки на соседние компоненты
		if(!w)
			w = GetComponent<WheelsControl>();
		if(!k)
			k = GetComponent<KlesnyaControl>();
	}
	
	void Update()
	{
		// Простое управление: W/S — вперед/назад, A/D — поворот
		float move = Input.GetAxis("Vertical");
		float steer = Input.GetAxis("Horizontal");
		
		UpdateGasMoveSteer(move, steer);

				// 1. Поворот основания (Q / E)
		if (Input.GetKey(KeyCode.Q)) rotation += speed;
		if (Input.GetKey(KeyCode.E)) rotation -= speed;

		// 2. Первый сустав (Стрелки Вверх / Вниз)
		if (Input.GetKey(KeyCode.F)) angle1 += speed;
		if (Input.GetKey(KeyCode.C)) angle1 -= speed;

		// 3. Второй сустав (Стрелки Влево / Вправо)
		if (Input.GetKey(KeyCode.G)) angle2 += speed;
		if (Input.GetKey(KeyCode.V)) angle2 -= speed;

		// 4. Клешня/Захват (Клавиши Z / X)
		if (Input.GetKey(KeyCode.Z)) angle3 += speed;
		if (Input.GetKey(KeyCode.X)) angle3 -= speed;

		// Ограничиваем углы (например, от -90 до 90 градусов), чтобы модель не вывернулась
		angle1 = Mathf.Clamp(angle1, -90f, 90f);
		angle2 = Mathf.Clamp(angle2, -90f, 90f);
		rotation = Mathf.Clamp(rotation, -180f, 180f);
		angle3 = Mathf.Clamp(angle3, 0f, 45f); // Для самой клешни обычно диапазон меньше

		// Передаем значения в вашу функцию
		SetAngles(angle1, angle2, rotation, angle3);
	}
}

