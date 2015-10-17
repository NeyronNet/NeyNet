using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActivFuncNN
{
    /// <summary>
    /// Класс радиально-базисных функций, коих привеликое множество есть...
    /// </summary>
    public class RadialBasis
    {
        /// <summary>
        /// Экспонента с отрицательной степенью. Функция, принимающая сумму произведений входов на веса (NET).
        /// Возвращает результат вычисления функции F(NET)=Exp(-(NET*NET)).
        /// Предельные значения получаются из функции ExponentNegativeDegreeLimit.
        /// </summary>
        public static Double ExponentNegativeDegree(Double NET)
        {
            Double FNET = 0;
            FNET = System.Math.Exp(-(NET * NET));
            return FNET;
        }
        /// <summary>
        /// Предельные значения экспоненты с отрицательной степенью. Принимает 0 - для получения нижней границы, и 1 - для верхней.
        /// </summary>
        public static int SigmoidLimit(int Position)
        {
            if (Position == 0)
                return 0;
            else
                return 1;
        }
    }
}
