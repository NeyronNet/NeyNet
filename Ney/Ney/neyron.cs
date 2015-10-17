using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ney
{
    public class neyron
    {
        public struct links
        {
            public neyron point;
            public double weigth;
            /// <summary>
            /// Конструктор структуры (потому что могу)
            /// </summary>
            /// <param name="_point">Связанный нейрон</param>
            /// <param name="_weigth">Вес</param>
            public links(neyron _point, double _weigth)
            {
                point = _point;
                weigth = _weigth;
            }
        }

        List<links> Inputs; //Список входящих связей
        Double NeyronOutput; //Выход нейрона

        /// <summary>
        /// Конструктор нейрона
        /// </summary>
        /// <param name="_inputs">Массив нейронов, являющихся входом данного нейрона</param>
        public neyron(neyron[] _inputs)
        {
            Random rnd = new Random();
            foreach (neyron element in _inputs)
            {
                links link = new links(element, rnd.NextDouble());
                Inputs.Add(link);
            }
        }
        /// <summary>
        /// Рассчет выхода нейрона. Выход помещается в поле NeyronOutput
        /// </summary>
        /// <param name="ActFunc">Объект типа "активационная функция"</param>
        public void calculate(ActivateFunctions ActFunc)
        {
            double Sum = 0;
            foreach (links element in Inputs)
            {
                Sum += element.weigth * element.point.NeyronOutput;
            }
            NeyronOutput = ActFunc.Calculate(Sum);
        }


    }
}
