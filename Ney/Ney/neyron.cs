using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ney
{
    public class neyron
    {
        private List<links> Inputs; //Список входящих связей
        private List<links> Outputs; //Список исходящих связей
        private Double Output; //Выход нейрона

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
        //Параметр только для чтения
        /// <summary>
        /// Выход нейрона
        /// </summary>
        public double Out
        {
            get { return Output; }
        }
        /// <summary>
        /// Конструктор нейрона со случайными весами
        /// </summary>
        /// <param name="_inputs">Массив нейронов, являющихся входом данного нейрона</param>
        public neyron(neyron[] _inputs)
        {
            foreach (neyron element in _inputs)
            {
                links link = new links(element, GetRandomDouble());
                Inputs.Add(link);
            }
        }
        /// <summary>
        /// Конструктор нейрона с заданными весами
        /// </summary>
        /// <param name="_inputs">Массив нейронов, являющихся входом данного нейрона</param>
        /// <param name="_weigth">Соответствующие им веса</param>
        public neyron(neyron[] _inputs, double[] _weigth)
        {
            int i = 0;
            foreach (neyron element in _inputs)
            {
                links link = new links(element, _weigth[i]);
                Inputs.Add(link);
                i++;
            }
        }
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public neyron()
        {
            
        }
        /// <summary>
        /// Добавление входящей связи к нейрону
        /// </summary>
        /// <param name="_input">Нейрон, от которого идет связь</param>
        /// <param name="_weigth">Вес связи. Если = 0, то задается случайно в диапазоне (0,1)</param>
        public void addInput(neyron _input, double _weigth = 0)
        {
            links link;
            if(_weigth == 0)
            {
                link = new links(_input, GetRandomDouble());
            }
            else
            {
                link = new links(_input, _weigth);
            }
            Inputs.Add(link);
        }
        /// <summary>
        /// Добавление ссылки на связь, являющейся исходящей. Для облегчения обучения.
        /// </summary>
        /// <param name="_link">Структура связи</param>
        public void addOutput(ref links _link)
        {
            Outputs.Add(_link);
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
                Sum += element.weigth * element.point.Out;
            }
            Output = ActFunc.Calculate(Sum);
        }
        /// <summary>
        /// Костыль для получения отличных от 0 значений
        /// </summary>
        /// <returns>Случайное число типа double в диапеазоне (0,1)</returns>
        private double GetRandomDouble()
        {
            Random rnd = new Random();
            double result = 0;
            while(result == 0)
            {
                result = rnd.NextDouble();
            }
            return result;
                
        }

    }
    /// <summary>
    /// Класс для нейронов входного слоя. Наследование от базового класса нейрона. Скрыт метод вычисления, добавлено поле значения (он же выход).
    /// </summary>
    public class inputNeyron : neyron
    {
        private double Output;
        private new struct links { }
        public double Value
               {
            set { if (value != double.NaN) { Output = value; } }
        }
        public void calculate() { }

    }
}
