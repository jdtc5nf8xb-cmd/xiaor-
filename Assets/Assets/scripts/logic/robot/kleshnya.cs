using UnityEngine;

public class Kelshnya : MonoBehaviour
{
    public ArticulationBody Main;
    public ArticulationBody Slave;

    void FixedUpdate()
    {
        // Проверяем наличие компонентов и наличие степеней свободы (DOF)
        if (Main != null && Slave != null && Main.dofCount > 0)
        {
            // 1. Получаем текущий угол поворота Main (в радианах)
            // [0] - это первая ось вращения (для Revolute Joint она одна)
            float currentAngleRad = Main.jointPosition[0];

            // 2. Переводим в градусы
            float currentAngleDeg = -currentAngleRad * Mathf.Rad2Deg;

            // 3. Принудительно выставляем цель для Slave
            var drive = Slave.xDrive; 
            drive.target = currentAngleDeg;
            Slave.xDrive = drive;
        }
    }
}
