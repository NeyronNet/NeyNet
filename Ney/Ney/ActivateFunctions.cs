﻿using System;
// TODO:Задание границ выходных значений
namespace Ney
{
    public class ActivateFunctions
    {
        private int ActFuncIndex = -1; //Индекс активационной функции
        private double Threshold,min,max = double.NaN; //Граница
        private double[] T; //Коэфициент
        /// <summary>
        /// Минимум активационной функции
        /// </summary>
        public double MinThreshold
        {
            get { return min;}
            set
            {
                if(value<Threshold)
                {
                    min = value; //Задать минимум, выдаваемый активационной функцией
                }
            }
        }
        /// <summary>
        /// Максимум активационной функции
        /// </summary>
        public double MaxThreshold
        {
            get { return max; }
            set
            {
                if (value > Threshold)
                {
                    max = value; //Задать максимум, выдаваемый активационной функцией
                }
            }

        }
        /// <summary>
        /// Возврат и задание типа функции и коэфициента. ДОДЕЛАТЬ!
        /// </summary>
        public double ActFunc
        {
            get { return ActFuncIndex; }
            set { if (value >= 0 ) { ActFuncIndex = (int)value; } }
        }
        public String ActFunccName
        {
            get { return ActivateFunctionsList()[ActFuncIndex]; }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="_ActFunc">Активационная функция. Список в через ActivateFunctionsList</param>
        /// <param name="_threshold">Порог активации</param>
        /// <param name="_t">Коэфициент "крутизны" выхода</param>
        public ActivateFunctions(int _ActFunc = -1, double _threshold = double.NaN, double _t = 1)
        {
            if (_ActFunc != -1)
            {
                ActFuncIndex = _ActFunc;
            }
            Threshold = _threshold;
            T = new double[1] { _t};
        }
        public ActivateFunctions(double[] _t, int _ActFunc = -1, double _threshold = double.NaN)
        {
            if (_ActFunc != -1)
            {
                ActFuncIndex = _ActFunc;
            }
            Threshold = _threshold;
            T = _t;
        }
        /// <summary>
        /// Рассчет активационной функции
        /// </summary>
        /// <param name="_input">Входное значение</param>
        /// <returns>Рассчетное значение с учетом имеющегося порога</returns>
        public double Calculate(double _input)
        {
            double output = double.NaN; //Переменная выходного значения
            switch (ActFuncIndex) //Для определения нужной активационной функции по индексу
            {
                case 0:
                    output = CalcThreshold(Sigmoid(_input)); //сразу вычисляем и применяем граничные условия
                    break;
                case 1:
                    output = CalcThreshold(HyperbolicTangens(_input)); //сразу вычисляем и применяем граничные условия
                    break;
                default:
                    output = double.NaN; //Если нет, то выход не определен
                    break;
            }
            return output;
        }
        /// <summary>
        /// Применение граничных условий
        /// </summary>
        /// <param name="_input">Вход</param>
        /// <returns>0 или 1, согласно границе (больше границы - 1, иначе 0)</returns>
        private double CalcThreshold(double _input)
        {
            double output = double.NaN;
            if (Threshold != double.NaN)
            {
                output = (_input <= Threshold) ? min : max; //Если меньше либо равен границе, то 0, иначе 1
            }
            
            return output;

        }
        /// <summary>
        /// Сигмоида
        /// </summary>
        /// <param name="_input">Вход</param>
        /// <returns></returns>
        private double Sigmoid(Double _input)
        {
            Double output = double.NaN;
            if (T[0] != double.NaN)
            {output = 1 / (1 + System.Math.Exp(-T[0] * _input));}
            return output;
        }
        /// <summary>
        /// Гиперболический тангенс
        /// </summary>
        /// <param name="_input">Вход</param>
        /// <returns></returns>
        private Double HyperbolicTangens(Double _input)
        {
            Double output = double.NaN;
            if (T[0] != double.NaN)
            {
               output = System.Math.Tanh(T[0] * _input);
            }
            return output;
        }

        /// <summary>
        /// Список активационных функций
        /// </summary>
        /// <returns>Возвращает список активационных функций</returns>
        public string[] ActivateFunctionsList()
        {
            string[] ActList = new String[1];
            ActList[0] = "Сигмоида"; //Для примера
            ActList[1] = "Гиперболический тангенс";
            return ActList;
        }


    }
}
