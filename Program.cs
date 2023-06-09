﻿//Лабораторная работа №11
//Написать программу, в которой с помощью делегатов и лямбда-выражений создается экземпляр делегата,
//который вызывается без аргументов, а результатом возвращает текстовое значение с названием дня недели
//("Понедельник", "Вторник" и так до "Воскресенья"). При каждом новом вызове экземпляра результатом
//возвращается название следующего дня недели. После "Воскресенья" результатом возвращается
//"Понедельник" и так далее.

using System;
using System.Threading;

class Program
{
    delegate string GetNextDayOfWeek(); //создаём делегат

    static void Main(string[] args)
    {
        string[] daysOfWeek = { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье" }; //значения дней недели
        int currentDayIndex = -1;

        GetNextDayOfWeek getNextDay = () =>
        {
            currentDayIndex = (currentDayIndex+1) % 7; //проходимся по каждому дню и когда доходим до последнего, начинаем с начала
            return daysOfWeek[currentDayIndex]; //возвращаем элемент массива по текущему индексу
        };

        for (int i = 0; i < 14; i++)
        {
            Console.WriteLine(getNextDay()); //вызываем дни недели
            Thread.Sleep(300);
        }
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("столько дней прошло с момента назначения ответственного задания :р");
        Console.ForegroundColor = ConsoleColor.White;
    }
}
