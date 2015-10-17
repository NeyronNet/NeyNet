using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActivFuncNN
{
    /// <summary>
    /// Класс гиперболического тангенса и иже с ним.
    /// </summary>
    class Hyperbolic
    {
        /// <summary>
        ///  Гиперболический тангенс. Функция, принимающая сумму произведений входов на веса (NET) и "температуру" (некую величину сдвига, по умолчанию заданную в 1). 
        ///  Возвращает результат вычисления функции F(NET)=th(T*NET).
        ///  Предельные значения получаются из функции HyperbolicTangentLimit.
        /// </summary>
        public static Double HyperbolicTangent(Double NET, Double T = 1)
        {
            Double FNET = 0;
            FNET = System.Math.Tanh(T * NET); //(System.Math.Exp(T * NET) - System.Math.Exp(-T * NET)) / (System.Math.Exp(T * NET) + System.Math.Exp(-T * NET));
            return FNET;
        }
        /// <summary>
        /// Предельные значения гиперболического тангенса. Принимает 0 - для получения нижней границы, и 1 - для верхней.
        /// </summary>
        public static int HyperbolicTangentLimit(int Position)
        {
            if (Position == 0)
                return 1;
            else
                return -1;
        }
        /// <summary>
        ///  Модифицированный гиперболический тангенс. Функция, принимающая сумму произведений входов на веса (NET) и 2 величины сдвига, по умолчанию заданные в 1 и позволяющие масштабировать S-образную функцию в разных направлениях. 
        ///  Возвращает результат вычисления функции F(NET)=th(T*NET).
        ///  A и B обязательно больше 1, иначе программно скинутся в 1!
        ///  Предельные значения получаются из функции ModifiedHyperbolicTangentLimit.
        /// </summary>
        public static Double ModifiedHyperbolicTangent(Double NET, Double A = 1, Double B=1)
        {
            if (A < 1) A = 1;
            if (B < 1) B = 1;
            Double FNET=0;
            FNET = (System.Math.Exp(NET) - System.Math.Exp(-NET)) / (System.Math.Exp(A * NET) + System.Math.Exp(-B * NET));
            return FNET;
        }
        /// <summary>
        /// Предельные значения модифицированного гиперболического тангенса. Принимает 0 - для получения нижней границы, и 1 - для верхней.
        /// </summary>
        public static int ModifiedHyperbolicTangentLimit(int Position)
        {
            if (Position == 0)
                return 1;
            else
                return -1;
        }
    }
}
