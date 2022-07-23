﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ver1._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            nhapSo();
            Console.Clear();
            Menu1();
            var readKeys = new Task(ReadKeys);
            readKeys.Start();

            var tasks = new[] { readKeys };

            Task.WaitAll(tasks);

            Console.CancelKeyPress += (sender, e) =>
            {
                Environment.Exit(0);
            };
        }
        private static void nhapSo()
        {
            Console.CursorVisible = true;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Cyan;
        nhap:
            Console.Clear();
            Console.Write("Ban can nhap bao nhieu so: ");
            n = int.Parse(Console.ReadLine());
            if (n < 5 || n > 10)
            {
                Console.WriteLine("Chi duoc nhap tu 5 den 10");
                Console.WriteLine("Vui long nhap lai");
                Thread.Sleep(700);
                goto nhap;
            }

            for (i = 0; i < n; i++)
            {
                Console.Write("so {0} = ", i + 1);
                int number = int.Parse(Console.ReadLine());
                board.Add(number);
            }
        }
        private static int x = 0;
        private static int y = 0;
        private static int i, j, n;
        private static ArrayList board = new ArrayList();
        private static void Menu()
        {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("+---------+---------+");
            Console.WriteLine("|      LUA CHON:    |");
            Console.WriteLine("+---------+---------+");
            Console.WriteLine("| 1.Nhap lai day so |");
            Console.WriteLine("| 2.Sap xep tang dan|");
            Console.WriteLine("| 3.Sap xep giam dan|");
            Console.WriteLine("| 4.In ket qua      |");
            Console.WriteLine("| 5.Demo sx tang dan|");
            Console.WriteLine("| 6.Thoat           |");
            Console.WriteLine("+---------+---------+");
        }
        private static void Menu1()
        {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("+---------+---------+");
            Console.WriteLine("|      LUA CHON:    |");
            Console.WriteLine("+---------+---------+");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("| 1.Nhap lai day so |");
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("| 2.Sap xep tang dan|");
            Console.WriteLine("| 3.Sap xep giam dan|");
            Console.WriteLine("| 4.In ket qua      |");
            Console.WriteLine("| 5.Demo sx tang dan|");
            Console.WriteLine("| 6.Thoat           |");
            Console.WriteLine("+---------+---------+");
        }
        private static int[] s1 = new int[12];

        private static void Demo()
        {
            Array.Clear(s1, 0, s1.Length);

            for (int i = 0; i < board.Count; i++)
            {
                s1[i] = Convert.ToInt32(board[i]);
            }

            for (int i = 0; i < board.Count; i++)
            {
                for (int j = i; j < board.Count; j++)
                {
                    if (s1[i] > s1[j])
                    {
                        int tmp = s1[i];

                        s1[i] = s1[j];

                        s1[j] = tmp;
                    }
                }
            }
            Console.SetCursorPosition(x + 21, Y);
            for (int i = 0; i < board.Count; i++)
            {
                Console.Write(board[i] + " , ");
            }
            Console.Write(" ---> ");
                for (int i = 0; i < board.Count; i++)
            {
                Thread.Sleep(700);
                Console.Write(s1[i] + " , ");
            }
        
        }

        private static void Tangdan()
        {
            Array.Clear(s1, 0, s1.Length);

            for (int i = 0; i < board.Count; i++)
            {
                s1[i] = Convert.ToInt32(board[i]);
            }

            for (int i = 0; i < board.Count; i++)
            {
                for (int j = i; j < board.Count; j++)
                {
                    if (s1[i] > s1[j])
                    {
                        int tmp = s1[i];

                        s1[i] = s1[j];

                        s1[j] = tmp;
                    }
                }
            }
            Console.SetCursorPosition(x + 21, Y);
            for (int i = 0; i < board.Count; i++)
            {
                if (i == 0 || i == n - 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write(" [ " + s1[i] + " ] ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(" [ " + s1[i] + " ] ");
                }
            }
        }

        private static void Giamdan()
        {
            Array.Clear(s1, 0, s1.Length);

            for (int i = 0; i < board.Count; i++)
            {
                s1[i] = Convert.ToInt32(board[i]);
            }

            for (int i = 0; i < board.Count; i++)
            {
                for (int j = i; j < board.Count; j++)
                {
                    if (s1[i] < s1[j])
                    {
                        int tmp = s1[i];

                        s1[i] = s1[j];

                        s1[j] = tmp;
                    }
                }
            }
            Console.SetCursorPosition(x + 21, Y);
            for (int i = 0; i < board.Count; i++)
            {
                if (i == 0 || i == n - 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write(" [ " + s1[i] + " ] ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(" [ " + s1[i] + " ] ");
                }
            }
        }


        private static int Y = 3;
        


        private static void ReadKeys()
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            while (!Console.KeyAvailable && key.Key != ConsoleKey.Escape)
            {
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (Y != 3)
                        {
                            switch (Y)
                            {
                                case 4:
                                    Menu();
                                    Y--;
                                    Console.SetCursorPosition(x, Y);
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.WriteLine("| 1.Nhap lai day so |");
                                    Console.BackgroundColor = ConsoleColor.White;
                                    break;
                                case 5:
                                    Menu();
                                    Y--;
                                    Console.SetCursorPosition(x, Y);
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.WriteLine("| 2.Sap xep tang dan|");
                                    Console.BackgroundColor = ConsoleColor.White;
                                    break;
                                case 6:
                                    Menu();
                                    Y--;
                                    Console.SetCursorPosition(x, Y);
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.WriteLine("| 3.Sap xep giam dan|");
                                    Console.BackgroundColor = ConsoleColor.White;
                                    break;
                                case 7:
                                    Menu();
                                    Y--;
                                    Console.SetCursorPosition(x, Y);
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.WriteLine("| 4.In ket qua      |");
                                    Console.BackgroundColor = ConsoleColor.White;
                                    break;
                                case 8:
                                    Menu();
                                    Y--;
                                    Console.SetCursorPosition(x, Y);
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.WriteLine("| 5.Demo sx tang dan|");
                                    Console.BackgroundColor = ConsoleColor.White;
                                    break;
                             
                            }
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (Y != 8)
                        {
                            switch (Y)
                            {
                                case 3:
                                    Menu();
                                    Y++;
                                    Console.SetCursorPosition(x, Y);
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.WriteLine("| 2.Sap xep tang dan|");
                                    Console.BackgroundColor = ConsoleColor.White;
                                    break;
                                case 4:
                                    Menu();
                                    Y++;
                                    Console.SetCursorPosition(x, Y);
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.WriteLine("| 3.Sap xep giam dan|");
                                    Console.BackgroundColor = ConsoleColor.White;
                                    break;
                                case 5:
                                    Menu();
                                    Y++;
                                    Console.SetCursorPosition(x, Y);
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.WriteLine("| 4.In ket qua      |");
                                    Console.BackgroundColor = ConsoleColor.White;
                                    break;
                                case 6:
                                    Menu();
                                    Y++;
                                    Console.SetCursorPosition(x, Y);
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.WriteLine("| 5.Demo sx tang dan|");
                                    Console.BackgroundColor = ConsoleColor.White;
                                    break;
                                case 7:
                                    Menu();
                                    Y++;
                                    Console.SetCursorPosition(x, Y);
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.WriteLine("| 6.Thoat           |");
                                    Console.BackgroundColor = ConsoleColor.White;
                                    break;
                             
                            }
                        }
                        break;

                    case ConsoleKey.Enter:
                        switch (Y)
                        {
                            case 8:
                                return;
                                break;
                            case 3:
                                nhapSo();
                                Menu();
                                break;
                            case 4:
                                Console.SetCursorPosition(x + 21, Y);
                                Console.Write("da sap xep xong");
                                Menu();
                                Thread.Sleep(700);
                                Console.SetCursorPosition(x, 6);
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.WriteLine("| 4.In ket qua      |");
                                Console.BackgroundColor = ConsoleColor.White;
                                break;
                            case 6:
                                Tangdan();
                            case 5:
                                Console.SetCursorPosition(x + 21, Y);
                                Console.Write("da sap xep xong");
                                Menu();
                                Thread.Sleep(700);
                                Console.SetCursorPosition(x, 6);
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.WriteLine("| 4.In ket qua      |");
                                Console.BackgroundColor = ConsoleColor.White;
                                
                                break;
                            
                            case 7:
                                Demo();
                                break;

                        }
                        break;
                    default: break;
                }
            }
        }
    }
}
