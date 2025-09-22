// See https://aka.ms/new-console-template for more information
namespace EscapeGame
{
    using System;
    internal class Program
    {
        class EscapeRoom
        {
            static string playerName;
            static bool hasArtifact1 = false;
            static bool hasArtifact2 = false;
            static bool hasArtifact3 = false;
            static bool statueActivated = false;
            static bool hasKey = false;
            static bool boxOpened = false;
            static bool hasPicklock = false;
            static int ventilationAttempts = 0;

            static void Main()
            {
                Console.WriteLine("Вы проснулись в старнной комнате и пытаетесь вспомнить своё имя...");
                Console.Write("Введите имя вашего персонажа: ");
                playerName = Console.ReadLine();

                Console.WriteLine($"\nПривет, {playerName}! твоя цель выбраться из этой комнаты.\n");


                while (true)
                {
                    ShowOptions();
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            TryOpenDoor();
                            break;
                        case "2":
                            LookUnderBed();
                            break;
                        case "3":
                            OpenBox();
                            break;
                        case "4":
                            OpenVentilation();
                            break;
                        case "5":
                            LookAtNightstand();
                            break;
                        case "6":
                            LookAtStatue();
                            break;
                        default:
                            Console.WriteLine(" Твой выбор 1 - 6.");
                            break;
                    }
                    if (HasEscaped())
                        break;
                }
            }

            static void ShowOptions()
            {
                Console.WriteLine("\nЧто сделать?");
                Console.WriteLine("1. Открыть дверь");
                Console.WriteLine("2. Посмотреть под кровать");
                Console.WriteLine("3. Откройте ящик в углу комнаты.");
                Console.WriteLine("4. Откройте вентиляцию");
                Console.WriteLine("5. Взгляните на тумбочку.");
                Console.WriteLine("6. Посмотрите на статую рядом с дверью.");
                Console.Write("Твой выбор (1-6): ");
            }

            static void TryOpenDoor()
            {
                if (!hasPicklock)
                {
                    Console.WriteLine("Дверь заперта. Вам нужно найти отмычку, чтобы открыть дверь.");
                    return;
                }

                Console.WriteLine("Вы используете главный ключ и открываете дверь...");
                Console.WriteLine($"Congratulations, {playerName}! Вам удалось успешно сбежать из комнаты!");
            }

            static void LookUnderBed()
            {
                if (!hasArtifact1)
                {
                    hasArtifact1 = true;
                    Console.WriteLine($"{playerName}, Первый артефакт вы нашли под кроватью.");
                }
                else
                {
                    Console.WriteLine("Под кроватью ничего нет.");
                }
            }

            static void OpenBox()
            {
                if (!hasKey)
                {
                    Console.WriteLine("Ящик заперт. Тебе нужно найти ключ..");
                    return;
                }

                if (!boxOpened)
                {
                    boxOpened = true;
                    hasPicklock = true;
                    Console.WriteLine($"{playerName}, Вы открыли коробку и нашли главный ключ от двери.");
                }
                else
                {
                    Console.WriteLine("Коробка уже открыта, внутри пусто..");
                }
            }

            static void OpenVentilation()
            {
                if (!hasArtifact2)
                {
                    ventilationAttempts++;
                    if (ventilationAttempts < 3)
                    {
                        Console.WriteLine("Вентиляция плотно закрыта. Попробуйте ещё раз.");
                    }
                    else
                    {
                        hasArtifact2 = true;
                        Console.WriteLine($"{playerName}, Вы открыли вентиляцию и нашли второй артефакт..");
                    }
                }
                else
                {
                    Console.WriteLine("Вентиляция открыта, но больше ничего нет.");
                }
            }

            static void LookAtNightstand()
            {
                if (!hasArtifact3)
                {
                    hasArtifact3 = true;
                    Console.WriteLine($"{playerName}, Третий артефакт вы нашли на тумбочке.");
                }
                else
                {
                    Console.WriteLine("На тумбочке ничего нового.");
                }
            }

            static void LookAtStatue()
            {
                if (statueActivated)
                {
                    Console.WriteLine("Статуя уже активирована и дала вам ключ от ящика.");
                    return;
                }

                if (hasArtifact1 && hasArtifact2 && hasArtifact3)
                {
                    statueActivated = true;
                    hasKey = true;
                    Console.WriteLine($"{playerName}, Активировав статую тремя артефактами, вы получили ключ от сундука.");
                }
                else
                {
                    Console.WriteLine("Статуя выглядит загадочно. Похоже, для её активации требуется три артефакта.");
                }
            }

            static bool HasEscaped()
            {
                return hasPicklock && Console.ReadLine().Trim() == "1" && hasPicklock;
            }
        }
    }
}

