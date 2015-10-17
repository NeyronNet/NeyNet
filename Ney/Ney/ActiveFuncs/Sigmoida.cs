using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActivFuncNN
{
    /// <summary>
    /// Сигмоида.
    /// </summary>
    class Sigmoida
    {
        /// <summary>
        ///  Сигмоида. Функция, принимающая сумму произведений входов на веса (NET) и "температуру" (некую величину сдвига, по умолчанию заданную в 1). 
        ///  Возвращает результат вычисления функции F(NET)=1/(1+exp(-T*NET)).
        ///  Предельные значения получаются из функции SigmoidLimit.
        /// </summary>
        public static Double Sigmoid(Double NET, Double T = 1)
        {
            Double FNET = 0;
            FNET = 1 / (1 + System.Math.Exp(-T * NET));
            return FNET;
        }
        /// <summary>
        /// Предельные значения сигмоиды. Принимает 0 - для получения нижней границы, и 1 - для верхней.
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
