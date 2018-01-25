﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameEngine;
using LudoGame.Models;

namespace LudoGame.Controllers
{
    public class LudoController : Controller
    {
        public static Game myGame = new Game {};
        public static int counter = 0;
        public static bool red = false;
        public static bool green = false;
        public static bool yellow = false;
        public static bool blue = false;

        // GET: /Ludo/
        public ActionResult StartPage()
        {
            string userNickName = Request.Form["myTextBox"];
            string userColorChoice = Request.Form["colorChoice"];

            if(Request.Cookies["UserCookie"] == null)
            {
                HttpCookie myCookie = new HttpCookie("UserCookie");
                Guid guid = Guid.NewGuid();
                myCookie.Value = guid.ToString();
                myCookie.Expires = DateTime.Now.AddDays(10);
                Response.SetCookie(myCookie);
            }

            if (counter < 4 && userNickName != null && userColorChoice != null)
            {
                
                //myGame.Players.Add(new GamePlayer { Name = ""/*Example variable*/, Color = ""/*colorChoice*/ });
                myGame.Players.Add(new GamePlayer { Name = userNickName, Color = userColorChoice, PlayerID = Request.Cookies["UserCookie"].Value });
                myGame.Players[0].Turn = true;
                counter++;
            }
            if (myGame.Players.Count > 0)
            {
                foreach (GameEngine.GamePlayer player in LudoGame.Controllers.LudoController.myGame.Players)
                {
                    if (player.Color == "Red")
                    {
                        @LudoGame.Controllers.LudoController.red = true;
                    }
                    if (player.Color == "Yellow")
                    {
                        @LudoGame.Controllers.LudoController.yellow = true;
                    }
                    if (player.Color == "Blue")
                    {
                        @LudoGame.Controllers.LudoController.blue = true;
                    }
                    if (player.Color == "Green")
                    {
                        @LudoGame.Controllers.LudoController.green = true;
                    }
                }
            }
            return View(myGame);
        }

        public ActionResult Index()
        {
            return View(myGame);
        }
        public ActionResult RollDice()
        {
            myGame.Dice.Value = myGame.Dice.RollTheDice();
            return RedirectToAction("Index", "Ludo");
        }
        public ActionResult MovePiece1()
        {
            if (myGame.Players[0].Turn == true)
            {
                if (myGame.Players[0].Color == "Red")
                {
                    if (myGame.Players[0].One.InPlay == true)
                    {
                        if (myGame.Players[0].One.Position == 0 && myGame.Dice.Value == 6)
                        {
                            myGame.Players[0].One.Position = 40;
                        }
                        else if (myGame.Players[0].One.Position >= 40 && myGame.Players[0].One.Position <= 52)
                        {
                            myGame.Players[0].One.Position += myGame.Dice.Value;
                            if(myGame.Players[0].One.Position > 52)
                            {
                                int x = myGame.Players[0].One.Position - 52;
                                myGame.Players[0].One.Position = 0;
                                myGame.Players[0].One.Position += x;
                            }
                        }
                        else if (myGame.Players[0].One.Position >= 1 && myGame.Players[0].One.Position <= 38)
                        {
                            myGame.Players[0].One.Position += myGame.Dice.Value;
                            if(myGame.Players[0].One.Position > 38)
                            {
                                int x = myGame.Players[0].One.Position - 38;
                                myGame.Players[0].One.Position = 52;
                                myGame.Players[0].One.Position += x;
                            }
                        }
                        else if (myGame.Players[0].One.Position >= 53 && myGame.Players[0].One.Position <= 58)
                        {
                            myGame.Players[0].One.Position += myGame.Dice.Value;
                        }

                        if (myGame.Players[0].One.Position > 58)
                        {
                            int x = ((myGame.Players[0].One.Position) - 58);
                            myGame.Players[0].One.Position = (58 - x);
                        }
                        else if (myGame.Players[0].One.Position == 58)
                        {
                            //win condition
                            myGame.Players[0].One.InPlay = false;
                        }
                    }
                }

                if (myGame.Players[0].Color == "Green")
                {
                    if (myGame.Players[0].One.InPlay == true)
                    {
                        if (myGame.Players[0].One.Position == 0 && myGame.Dice.Value == 6)
                        {
                            myGame.Players[0].One.Position = 1;
                        }
                        else if (myGame.Players[0].One.Position >= 1 && myGame.Players[0].One.Position <= 51)
                        {
                            myGame.Players[0].One.Position += myGame.Dice.Value;
                            if (myGame.Players[0].One.Position >= 52)
                            {
                                int x = myGame.Players[0].One.Position - 51;
                                myGame.Players[0].One.Position = 52;
                                myGame.Players[0].One.Position += x;
                            }
                        }
                        else if (myGame.Players[0].One.Position >= 53 && myGame.Players[0].One.Position <= 58)
                        {
                            myGame.Players[0].One.Position += myGame.Dice.Value;
                        }

                        if (myGame.Players[0].One.Position > 58)
                        {
                            int x = ((myGame.Players[0].One.Position) - 58);
                            myGame.Players[0].One.Position = (58 - x);
                        }
                        else if (myGame.Players[0].One.Position == 58)
                        {
                            //win condition
                            myGame.Players[0].One.InPlay = false;
                        }
                    }
                }

                if (myGame.Players[0].Color == "Yellow")
                {
                    if (myGame.Players[0].One.InPlay == true)
                    {
                        if (myGame.Players[0].One.Position == 0 && myGame.Dice.Value == 6)
                        {
                            myGame.Players[0].One.Position = 27;
                        }
                        else if (myGame.Players[0].One.Position >= 27 && myGame.Players[0].One.Position <= 52)
                        {
                            myGame.Players[0].One.Position += myGame.Dice.Value;
                            if (myGame.Players[0].One.Position > 52)
                            {
                                int x = myGame.Players[0].One.Position - 52;
                                myGame.Players[0].One.Position = 0;
                                myGame.Players[0].One.Position += x;
                            }
                        }
                        else if (myGame.Players[0].One.Position >= 1 && myGame.Players[0].One.Position <= 25)
                        {
                            myGame.Players[0].One.Position += myGame.Dice.Value;
                            if (myGame.Players[0].One.Position > 25)
                            {
                                int x = myGame.Players[0].One.Position - 25;
                                myGame.Players[0].One.Position = 52;
                                myGame.Players[0].One.Position += x;
                            }
                        }
                        else if (myGame.Players[0].One.Position >= 53 && myGame.Players[0].One.Position <= 58)
                        {
                            myGame.Players[0].One.Position += myGame.Dice.Value;
                        }

                        if (myGame.Players[0].One.Position > 58)
                        {
                            int x = ((myGame.Players[0].One.Position) - 58);
                            myGame.Players[0].One.Position = (58 - x);
                        }
                        else if (myGame.Players[0].One.Position == 58)
                        {
                            //win condition
                            myGame.Players[0].One.InPlay = false;
                        }
                    }
                }

                if (myGame.Players[0].Color == "Blue")
                {
                    if (myGame.Players[0].One.InPlay == true)
                    {
                        if (myGame.Players[0].One.Position == 0 && myGame.Dice.Value == 6)
                        {
                            myGame.Players[0].One.Position = 14;
                        }
                        else if (myGame.Players[0].One.Position >= 14 && myGame.Players[0].One.Position <= 52)
                        {
                            myGame.Players[0].One.Position += myGame.Dice.Value;
                            if (myGame.Players[0].One.Position > 52)
                            {
                                int x = myGame.Players[0].One.Position - 52;
                                myGame.Players[0].One.Position = 0;
                                myGame.Players[0].One.Position += x;
                            }
                        }
                        else if (myGame.Players[0].One.Position >= 1 && myGame.Players[0].One.Position <= 12)
                        {
                            myGame.Players[0].One.Position += myGame.Dice.Value;
                            if (myGame.Players[0].One.Position > 12)
                            {
                                int x = myGame.Players[0].One.Position - 12;
                                myGame.Players[0].One.Position = 52;
                                myGame.Players[0].One.Position += x;
                            }
                        }
                        else if (myGame.Players[0].One.Position >= 53 && myGame.Players[0].One.Position <= 58)
                        {
                            myGame.Players[0].One.Position += myGame.Dice.Value;
                        }

                        if (myGame.Players[0].One.Position > 58)
                        {
                            int x = ((myGame.Players[0].One.Position) - 58);
                            myGame.Players[0].One.Position = (58 - x);
                        }
                        else if (myGame.Players[0].One.Position == 58)
                        {
                            //win condition
                            myGame.Players[0].One.InPlay = false;
                        }
                    }
                }
            }
            return RedirectToAction("Index", "Ludo");
        }
        public ActionResult MovePiece2()
        {
            if (myGame.Players[0].Turn == true)
            {
                if (myGame.Players[0].Color == "Red")
                {
                    if (myGame.Players[0].Two.InPlay == true)
                    {
                        if (myGame.Players[0].Two.Position == 0 && myGame.Dice.Value == 6)
                        {
                            myGame.Players[0].Two.Position = 40;
                        }
                        else if (myGame.Players[0].Two.Position >= 40 && myGame.Players[0].Two.Position <= 52)
                        {
                            myGame.Players[0].Two.Position += myGame.Dice.Value;
                            if (myGame.Players[0].Two.Position > 52)
                            {
                                int x = myGame.Players[0].Two.Position - 52;
                                myGame.Players[0].Two.Position = 0;
                                myGame.Players[0].Two.Position += x;
                            }
                        }
                        else if (myGame.Players[0].Two.Position >= 1 && myGame.Players[0].Two.Position <= 38)
                        {
                            myGame.Players[0].Two.Position += myGame.Dice.Value;
                            if (myGame.Players[0].Two.Position > 38)
                            {
                                int x = myGame.Players[0].Two.Position - 38;
                                myGame.Players[0].Two.Position = 52;
                                myGame.Players[0].Two.Position += x;
                            }
                        }
                        else if (myGame.Players[0].Two.Position >= 53 && myGame.Players[0].Two.Position <= 58)
                        {
                            myGame.Players[0].Two.Position += myGame.Dice.Value;
                        }

                        if (myGame.Players[0].Two.Position > 58)
                        {
                            int x = ((myGame.Players[0].Two.Position) - 58);
                            myGame.Players[0].Two.Position = (58 - x);
                        }
                        else if (myGame.Players[0].Two.Position == 58)
                        {
                            //win condition
                            myGame.Players[0].Two.InPlay = false;
                        }
                    }
                }

                if (myGame.Players[0].Color == "Green")
                {
                    if (myGame.Players[0].Two.InPlay == true)
                    {
                        if (myGame.Players[0].Two.Position == 0 && myGame.Dice.Value == 6)
                        {
                            myGame.Players[0].Two.Position = 1;
                        }
                        else if (myGame.Players[0].Two.Position >= 1 && myGame.Players[0].Two.Position <= 51)
                        {
                            myGame.Players[0].Two.Position += myGame.Dice.Value;
                            if (myGame.Players[0].Two.Position >= 52)
                            {
                                int x = myGame.Players[0].Two.Position - 51;
                                myGame.Players[0].Two.Position = 52;
                                myGame.Players[0].Two.Position += x;
                            }
                        }
                        else if (myGame.Players[0].Two.Position >= 53 && myGame.Players[0].Two.Position <= 58)
                        {
                            myGame.Players[0].Two.Position += myGame.Dice.Value;
                        }

                        if (myGame.Players[0].Two.Position > 58)
                        {
                            int x = ((myGame.Players[0].Two.Position) - 58);
                            myGame.Players[0].Two.Position = (58 - x);
                        }
                        else if (myGame.Players[0].Two.Position == 58)
                        {
                            //win condition
                            myGame.Players[0].Two.InPlay = false;
                        }
                    }
                }

                if (myGame.Players[0].Color == "Yellow")
                {
                    if (myGame.Players[0].Two.InPlay == true)
                    {
                        if (myGame.Players[0].Two.Position == 0 && myGame.Dice.Value == 6)
                        {
                            myGame.Players[0].Two.Position = 27;
                        }
                        else if (myGame.Players[0].Two.Position >= 27 && myGame.Players[0].Two.Position <= 52)
                        {
                            myGame.Players[0].Two.Position += myGame.Dice.Value;
                            if (myGame.Players[0].Two.Position > 52)
                            {
                                int x = myGame.Players[0].Two.Position - 52;
                                myGame.Players[0].Two.Position = 0;
                                myGame.Players[0].Two.Position += x;
                            }
                        }
                        else if (myGame.Players[0].Two.Position >= 1 && myGame.Players[0].Two.Position <= 25)
                        {
                            myGame.Players[0].Two.Position += myGame.Dice.Value;
                            if (myGame.Players[0].Two.Position > 25)
                            {
                                int x = myGame.Players[0].Two.Position - 25;
                                myGame.Players[0].Two.Position = 52;
                                myGame.Players[0].Two.Position += x;
                            }
                        }
                        else if (myGame.Players[0].Two.Position >= 53 && myGame.Players[0].Two.Position <= 58)
                        {
                            myGame.Players[0].Two.Position += myGame.Dice.Value;
                        }

                        if (myGame.Players[0].Two.Position > 58)
                        {
                            int x = ((myGame.Players[0].Two.Position) - 58);
                            myGame.Players[0].Two.Position = (58 - x);
                        }
                        else if (myGame.Players[0].Two.Position == 58)
                        {
                            //win condition
                            myGame.Players[0].Two.InPlay = false;
                        }
                    }
                }

                if (myGame.Players[0].Color == "Blue")
                {
                    if (myGame.Players[0].Two.InPlay == true)
                    {
                        if (myGame.Players[0].Two.Position == 0 && myGame.Dice.Value == 6)
                        {
                            myGame.Players[0].Two.Position = 14;
                        }
                        else if (myGame.Players[0].Two.Position >= 14 && myGame.Players[0].Two.Position <= 52)
                        {
                            myGame.Players[0].Two.Position += myGame.Dice.Value;
                            if (myGame.Players[0].Two.Position > 52)
                            {
                                int x = myGame.Players[0].Two.Position - 52;
                                myGame.Players[0].Two.Position = 0;
                                myGame.Players[0].Two.Position += x;
                            }
                        }
                        else if (myGame.Players[0].Two.Position >= 1 && myGame.Players[0].Two.Position <= 12)
                        {
                            myGame.Players[0].Two.Position += myGame.Dice.Value;
                            if (myGame.Players[0].Two.Position > 12)
                            {
                                int x = myGame.Players[0].Two.Position - 12;
                                myGame.Players[0].Two.Position = 52;
                                myGame.Players[0].Two.Position += x;
                            }
                        }
                        else if (myGame.Players[0].Two.Position >= 53 && myGame.Players[0].Two.Position <= 58)
                        {
                            myGame.Players[0].Two.Position += myGame.Dice.Value;
                        }

                        if (myGame.Players[0].Two.Position > 58)
                        {
                            int x = ((myGame.Players[0].Two.Position) - 58);
                            myGame.Players[0].Two.Position = (58 - x);
                        }
                        else if (myGame.Players[0].Two.Position == 58)
                        {
                            //win condition
                            myGame.Players[0].Two.InPlay = false;
                        }
                    }
                }
            }
            return RedirectToAction("Index", "Ludo");
        }
        public ActionResult MovePiece3()
        {
            if (myGame.Players[0].Turn == true)
            {
                if (myGame.Players[0].Color == "Red")
                {
                    if (myGame.Players[0].Three.InPlay == true)
                    {
                        if (myGame.Players[0].Three.Position == 0 && myGame.Dice.Value == 6)
                        {
                            myGame.Players[0].Three.Position = 40;
                        }
                        else if (myGame.Players[0].Three.Position >= 40 && myGame.Players[0].Three.Position <= 52)
                        {
                            myGame.Players[0].Three.Position += myGame.Dice.Value;
                            if (myGame.Players[0].Three.Position > 52)
                            {
                                int x = myGame.Players[0].Three.Position - 52;
                                myGame.Players[0].Three.Position = 0;
                                myGame.Players[0].Three.Position += x;
                            }
                        }
                        else if (myGame.Players[0].Three.Position >= 1 && myGame.Players[0].Three.Position <= 38)
                        {
                            myGame.Players[0].Three.Position += myGame.Dice.Value;
                            if (myGame.Players[0].Three.Position > 38)
                            {
                                int x = myGame.Players[0].Three.Position - 38;
                                myGame.Players[0].Three.Position = 52;
                                myGame.Players[0].Three.Position += x;
                            }
                        }
                        else if (myGame.Players[0].Three.Position >= 53 && myGame.Players[0].Three.Position <= 58)
                        {
                            myGame.Players[0].Three.Position += myGame.Dice.Value;
                        }

                        if (myGame.Players[0].Three.Position > 58)
                        {
                            int x = ((myGame.Players[0].Three.Position) - 58);
                            myGame.Players[0].Three.Position = (58 - x);
                        }
                        else if (myGame.Players[0].Three.Position == 58)
                        {
                            //win condition
                            myGame.Players[0].Three.InPlay = false;
                        }
                    }
                }

                if (myGame.Players[0].Color == "Green")
                {
                    if (myGame.Players[0].Three.InPlay == true)
                    {
                        if (myGame.Players[0].Three.Position == 0 && myGame.Dice.Value == 6)
                        {
                            myGame.Players[0].Three.Position = 1;
                        }
                        else if (myGame.Players[0].Three.Position >= 1 && myGame.Players[0].Three.Position <= 51)
                        {
                            myGame.Players[0].Three.Position += myGame.Dice.Value;
                            if (myGame.Players[0].Three.Position >= 52)
                            {
                                int x = myGame.Players[0].Three.Position - 51;
                                myGame.Players[0].Three.Position = 52;
                                myGame.Players[0].Three.Position += x;
                            }
                        }
                        else if (myGame.Players[0].Three.Position >= 53 && myGame.Players[0].Three.Position <= 58)
                        {
                            myGame.Players[0].Three.Position += myGame.Dice.Value;
                        }

                        if (myGame.Players[0].Three.Position > 58)
                        {
                            int x = ((myGame.Players[0].Three.Position) - 58);
                            myGame.Players[0].Three.Position = (58 - x);
                        }
                        else if (myGame.Players[0].Three.Position == 58)
                        {
                            //win condition
                            myGame.Players[0].Three.InPlay = false;
                        }
                    }
                }

                if (myGame.Players[0].Color == "Yellow")
                {
                    if (myGame.Players[0].Three.InPlay == true)
                    {
                        if (myGame.Players[0].Three.Position == 0 && myGame.Dice.Value == 6)
                        {
                            myGame.Players[0].Three.Position = 27;
                        }
                        else if (myGame.Players[0].Three.Position >= 27 && myGame.Players[0].Three.Position <= 52)
                        {
                            myGame.Players[0].Three.Position += myGame.Dice.Value;
                            if (myGame.Players[0].Three.Position > 52)
                            {
                                int x = myGame.Players[0].Three.Position - 52;
                                myGame.Players[0].Three.Position = 0;
                                myGame.Players[0].Three.Position += x;
                            }
                        }
                        else if (myGame.Players[0].Three.Position >= 1 && myGame.Players[0].Three.Position <= 25)
                        {
                            myGame.Players[0].Three.Position += myGame.Dice.Value;
                            if (myGame.Players[0].Three.Position > 25)
                            {
                                int x = myGame.Players[0].Three.Position - 25;
                                myGame.Players[0].Three.Position = 52;
                                myGame.Players[0].Three.Position += x;
                            }
                        }
                        else if (myGame.Players[0].Three.Position >= 53 && myGame.Players[0].Three.Position <= 58)
                        {
                            myGame.Players[0].Three.Position += myGame.Dice.Value;
                        }

                        if (myGame.Players[0].Three.Position > 58)
                        {
                            int x = ((myGame.Players[0].Three.Position) - 58);
                            myGame.Players[0].Three.Position = (58 - x);
                        }
                        else if (myGame.Players[0].Three.Position == 58)
                        {
                            //win condition
                            myGame.Players[0].Three.InPlay = false;
                        }
                    }
                }

                if (myGame.Players[0].Color == "Blue")
                {
                    if (myGame.Players[0].Three.InPlay == true)
                    {
                        if (myGame.Players[0].Three.Position == 0 && myGame.Dice.Value == 6)
                        {
                            myGame.Players[0].Three.Position = 14;
                        }
                        else if (myGame.Players[0].Three.Position >= 14 && myGame.Players[0].Three.Position <= 52)
                        {
                            myGame.Players[0].Three.Position += myGame.Dice.Value;
                            if (myGame.Players[0].Three.Position > 52)
                            {
                                int x = myGame.Players[0].Three.Position - 52;
                                myGame.Players[0].Three.Position = 0;
                                myGame.Players[0].Three.Position += x;
                            }
                        }
                        else if (myGame.Players[0].Three.Position >= 1 && myGame.Players[0].Three.Position <= 12)
                        {
                            myGame.Players[0].Three.Position += myGame.Dice.Value;
                            if (myGame.Players[0].Three.Position > 12)
                            {
                                int x = myGame.Players[0].Three.Position - 12;
                                myGame.Players[0].Three.Position = 52;
                                myGame.Players[0].Three.Position += x;
                            }
                        }
                        else if (myGame.Players[0].Three.Position >= 53 && myGame.Players[0].Three.Position <= 58)
                        {
                            myGame.Players[0].Three.Position += myGame.Dice.Value;
                        }

                        if (myGame.Players[0].Three.Position > 58)
                        {
                            int x = ((myGame.Players[0].Three.Position) - 58);
                            myGame.Players[0].Three.Position = (58 - x);
                        }
                        else if (myGame.Players[0].Three.Position == 58)
                        {
                            //win condition
                            myGame.Players[0].Three.InPlay = false;
                        }
                    }
                }
            }
            return RedirectToAction("Index", "Ludo");
        }
        public ActionResult MovePiece4()
        {
            if (myGame.Players[0].Turn == true)
            {
                if (myGame.Players[0].Color == "Red")
                {
                    if (myGame.Players[0].Four.InPlay == true)
                    {
                        if (myGame.Players[0].Four.Position == 0 && myGame.Dice.Value == 6)
                        {
                            myGame.Players[0].Four.Position = 40;
                        }
                        else if (myGame.Players[0].Four.Position >= 40 && myGame.Players[0].Four.Position <= 52)
                        {
                            myGame.Players[0].Four.Position += myGame.Dice.Value;
                            if (myGame.Players[0].Four.Position > 52)
                            {
                                int x = myGame.Players[0].Four.Position - 52;
                                myGame.Players[0].Four.Position = 0;
                                myGame.Players[0].Four.Position += x;
                            }
                        }
                        else if (myGame.Players[0].Four.Position >= 1 && myGame.Players[0].Four.Position <= 38)
                        {
                            myGame.Players[0].Four.Position += myGame.Dice.Value;
                            if (myGame.Players[0].Four.Position > 38)
                            {
                                int x = myGame.Players[0].Four.Position - 38;
                                myGame.Players[0].Four.Position = 52;
                                myGame.Players[0].Four.Position += x;
                            }
                        }
                        else if (myGame.Players[0].Four.Position >= 53 && myGame.Players[0].Four.Position <= 58)
                        {
                            myGame.Players[0].Four.Position += myGame.Dice.Value;
                        }

                        if (myGame.Players[0].Four.Position > 58)
                        {
                            int x = ((myGame.Players[0].Four.Position) - 58);
                            myGame.Players[0].Four.Position = (58 - x);
                        }
                        else if (myGame.Players[0].Four.Position == 58)
                        {
                            //win condition
                            myGame.Players[0].Four.InPlay = false;
                        }
                    }
                }

                if (myGame.Players[0].Color == "Green")
                {
                    if (myGame.Players[0].Four.InPlay == true)
                    {
                        if (myGame.Players[0].Four.Position == 0 && myGame.Dice.Value == 6)
                        {
                            myGame.Players[0].Four.Position = 1;
                        }
                        else if (myGame.Players[0].Four.Position >= 1 && myGame.Players[0].Four.Position <= 51)
                        {
                            myGame.Players[0].Four.Position += myGame.Dice.Value;
                            if (myGame.Players[0].Four.Position >= 52)
                            {
                                int x = myGame.Players[0].Four.Position - 51;
                                myGame.Players[0].Four.Position = 52;
                                myGame.Players[0].Four.Position += x;
                            }
                        }
                        else if (myGame.Players[0].Four.Position >= 53 && myGame.Players[0].Four.Position <= 58)
                        {
                            myGame.Players[0].Four.Position += myGame.Dice.Value;
                        }

                        if (myGame.Players[0].Four.Position > 58)
                        {
                            int x = ((myGame.Players[0].Four.Position) - 58);
                            myGame.Players[0].Four.Position = (58 - x);
                        }
                        else if (myGame.Players[0].Four.Position == 58)
                        {
                            //win condition
                            myGame.Players[0].Four.InPlay = false;
                        }
                    }
                }

                if (myGame.Players[0].Color == "Yellow")
                {
                    if (myGame.Players[0].Four.InPlay == true)
                    {
                        if (myGame.Players[0].Four.Position == 0 && myGame.Dice.Value == 6)
                        {
                            myGame.Players[0].Four.Position = 27;
                        }
                        else if (myGame.Players[0].Four.Position >= 27 && myGame.Players[0].Four.Position <= 52)
                        {
                            myGame.Players[0].Four.Position += myGame.Dice.Value;
                            if (myGame.Players[0].Four.Position > 52)
                            {
                                int x = myGame.Players[0].Four.Position - 52;
                                myGame.Players[0].Four.Position = 0;
                                myGame.Players[0].Four.Position += x;
                            }
                        }
                        else if (myGame.Players[0].Four.Position >= 1 && myGame.Players[0].Four.Position <= 25)
                        {
                            myGame.Players[0].Four.Position += myGame.Dice.Value;
                            if (myGame.Players[0].Four.Position > 25)
                            {
                                int x = myGame.Players[0].Four.Position - 25;
                                myGame.Players[0].Four.Position = 52;
                                myGame.Players[0].Four.Position += x;
                            }
                        }
                        else if (myGame.Players[0].Four.Position >= 53 && myGame.Players[0].Four.Position <= 58)
                        {
                            myGame.Players[0].Four.Position += myGame.Dice.Value;
                        }

                        if (myGame.Players[0].Four.Position > 58)
                        {
                            int x = ((myGame.Players[0].Four.Position) - 58);
                            myGame.Players[0].Four.Position = (58 - x);
                        }
                        else if (myGame.Players[0].Four.Position == 58)
                        {
                            //win condition
                            myGame.Players[0].Four.InPlay = false;
                        }
                    }
                }

                if (myGame.Players[0].Color == "Blue")
                {
                    if (myGame.Players[0].Four.InPlay == true)
                    {
                        if (myGame.Players[0].Four.Position == 0 && myGame.Dice.Value == 6)
                        {
                            myGame.Players[0].Four.Position = 14;
                        }
                        else if (myGame.Players[0].Four.Position >= 14 && myGame.Players[0].Four.Position <= 52)
                        {
                            myGame.Players[0].Four.Position += myGame.Dice.Value;
                            if (myGame.Players[0].Four.Position > 52)
                            {
                                int x = myGame.Players[0].Four.Position - 52;
                                myGame.Players[0].Four.Position = 0;
                                myGame.Players[0].Four.Position += x;
                            }
                        }
                        else if (myGame.Players[0].Four.Position >= 1 && myGame.Players[0].Four.Position <= 12)
                        {
                            myGame.Players[0].Four.Position += myGame.Dice.Value;
                            if (myGame.Players[0].Four.Position > 12)
                            {
                                int x = myGame.Players[0].Four.Position - 12;
                                myGame.Players[0].Four.Position = 52;
                                myGame.Players[0].Four.Position += x;
                            }
                        }
                        else if (myGame.Players[0].Four.Position >= 53 && myGame.Players[0].Four.Position <= 58)
                        {
                            myGame.Players[0].Four.Position += myGame.Dice.Value;
                        }

                        if (myGame.Players[0].Four.Position > 58)
                        {
                            int x = ((myGame.Players[0].Four.Position) - 58);
                            myGame.Players[0].Four.Position = (58 - x);
                        }
                        else if (myGame.Players[0].Four.Position == 58)
                        {
                            //win condition
                            myGame.Players[0].Four.InPlay = false;
                        }
                    }
                }
            }
            return RedirectToAction("Index", "Ludo");
        }


    }
}