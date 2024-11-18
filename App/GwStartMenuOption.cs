using KWEngine3;
using KWEngine3.Audio;
using KWEngine3.GameObjects;
using Gruppenprojekt.App.Classes;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using static System.Net.Mime.MediaTypeNames;
using System;
using static Assimp.Metadata;

namespace Gruppenprojekt.App
{
    public class GwStartMenuOption : World
    {
        int value1 = 0;
        int value2 = 0;
        int value3 = 0;

        public static int ReturnCode;
        public override void Act()
        {
            
            HUDObjectText back = GetHUDObjectTextByName("back");
            HUDObjectText enter = GetHUDObjectTextByName("Enter");
            HUDObjectText plus1 = GetHUDObjectTextByName("plus1");
            HUDObjectText minus1 = GetHUDObjectTextByName("minus1");
            HUDObjectText score1 = GetHUDObjectTextByName("score1");

            HUDObjectText plus2 = GetHUDObjectTextByName("plus2");
            HUDObjectText minus2 = GetHUDObjectTextByName("minus2");
            HUDObjectText score2 = GetHUDObjectTextByName("score2");

            HUDObjectText plus3 = GetHUDObjectTextByName("plus3");
            HUDObjectText minus3 = GetHUDObjectTextByName("minus3");
            HUDObjectText score3 = GetHUDObjectTextByName("score3");

            HUDObjectText code = GetHUDObjectTextByName("code");





            if (back != null)                                                                     
            {
                //BACK

                if (back.IsMouseCursorOnMe() == true)
                {
                    back.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    back.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && back.IsMouseCursorOnMe() == true)
                {
                    GameWorldStartMenu gm = new GameWorldStartMenu();
                    Window.SetWorld(gm);
                }
            }   //back  
            if (enter != null)
            {
                //Leave game

                if (enter.IsMouseCursorOnMe() == true)
                {
                    enter.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    enter.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && enter.IsMouseCursorOnMe() == true)
                {
                    if (value1 == 1 && value2 == 1 && value3 == 1)
                    { code.SetText("YOU ENTERD THE RIGHT CODE!"); }
                    else { code.SetText(""); }
                    ReturnCode = 1;
                        
                        
                }
            }   //Enter
            if (plus1 != null)
            {
                //Option

                if (plus1.IsMouseCursorOnMe() == true)
                {
                    plus1.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    plus1.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && plus1.IsMouseCursorOnMe() == true)
                {
                    if(value1 < 37)
                    {
                        value1++;
                    }
                    
                }
            }   //option
            if (plus2 != null)
            {
                //Option

                if (plus2.IsMouseCursorOnMe() == true)
                {
                    plus2.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    plus2.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && plus2.IsMouseCursorOnMe() == true)
                {
                    if (value2 < 37)
                    {
                        value2++;
                    }

                }
            }   //option
            if (plus3 != null)
            {
                //Option

                if (plus3.IsMouseCursorOnMe() == true)
                {
                    plus3.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    plus3.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && plus3.IsMouseCursorOnMe() == true)
                {
                    if (value3 < 37)
                    {
                        value3++;
                    }

                }
            }   //option
            if (minus1 != null)
            {
                //Leave game

                if (minus1.IsMouseCursorOnMe() == true)
                {
                    minus1.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    minus1.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && minus1.IsMouseCursorOnMe() == true)
                {
                    if (value1  >= 1)
                    {
                        value1--;
                    }
                }
            }   //leave
            if (minus2 != null)
            {
                //Leave game

                if (minus2.IsMouseCursorOnMe() == true)
                {
                    minus2.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    minus2.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && minus2.IsMouseCursorOnMe() == true)
                {
                    if (value2 >= 1)
                    {
                        value2--;
                    }
                }
            }   //leave
            if (minus3 != null)
            {
                //Leave game

                if (minus3.IsMouseCursorOnMe() == true)
                {
                    minus3.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    minus3.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && minus3.IsMouseCursorOnMe() == true)
                {
                    if (value3 >= 1)
                    {
                        value3--;
                    }
                }
            }   //leave


            string text1 = transelateCode(Convert.ToString(value1));
            string text2 = transelateCode(Convert.ToString(value2));
            string text3 = transelateCode(Convert.ToString(value3));
            if(value1 == 37) { value1 = 0; }
            if(value2  == 37) { value2 = 0; }
            if(value3 == 37) { value3 = 0; }

            score1.SetText("| " + text1 + " |", true);  //update shown Value
            score2.SetText("| " + text2 + " |", true);  //update shown Value
            score3.SetText("| " + text3 + " |", true);  //update shown Value
        }


        public override void Prepare()
        {
            HUDObjectText h1 = new HUDObjectText("BACK");
            h1.SetPosition(160f, 200f);
            h1.Name = "back";
            h1.SetCharacterDistanceFactor(1.0f);
            h1.SetColor(1.0f, 0.0f, 0.0f);
            h1.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(h1);


            HUDObjectText Enter = new HUDObjectText("ENTER CODE");
            Enter.SetPosition(160f, 400f);
            Enter.Name = "Enter";
            Enter.SetCharacterDistanceFactor(1.0f);
            Enter.SetColor(1.0f, 0.0f, 0.0f);
            Enter.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(Enter);


            HUDObjectText code = new HUDObjectText("");
            code.SetPosition(160f, 500f);
            code.Name = "code";
            code.SetCharacterDistanceFactor(1.0f);
            code.SetColor(1.0f, 0.0f, 0.0f);
            code.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(code);

            


            HUDObjectText minus1 = new HUDObjectText("| - |");
            minus1.SetPosition(160f, 350f);
            minus1.Name = "minus1";
            minus1.SetCharacterDistanceFactor(1.0f);
            minus1.SetColor(1.0f, 0.0f, 0.0f);
            minus1.SetColorEmissive(1.0f, 1.0f, 1.0f);
            
            AddHUDObject(minus1);


            HUDObjectText score1 = new HUDObjectText("| " + value1 +  " |");
            score1.SetPosition(160f, 300f);
            score1.Name = "score1";
            score1.SetCharacterDistanceFactor(1.0f);
            score1.SetColor(1.0f, 0.0f, 0.0f);
            score1.SetColorEmissive(0.0f, 0.0f, 0.0f);
            score1.SetText(""+ value1, true);

            AddHUDObject(score1);


            HUDObjectText plus1 = new HUDObjectText("| + |");
            plus1.SetPosition(160f, 250f);
            plus1.Name = "plus1";
            plus1.SetCharacterDistanceFactor(1.0f);
            plus1.SetColor(1.0f, 0.0f, 0.0f);
            plus1.SetColorEmissive(1.0f, 1.0f, 1.0f);

            AddHUDObject(plus1);






            HUDObjectText minus2 = new HUDObjectText("| - |");
            minus2.SetPosition(310f, 350f);
            minus2.Name = "minus2";
            minus2.SetCharacterDistanceFactor(1.0f);
            minus2.SetColor(1.0f, 0.0f, 0.0f);
            minus2.SetColorEmissive(1.0f, 1.0f, 1.0f);

            AddHUDObject(minus2);


            HUDObjectText score2 = new HUDObjectText("| " + value2 + " |");
            score2.SetPosition(310f, 300f);
            score2.Name = "score2";
            score2.SetCharacterDistanceFactor(1.0f);
            score2.SetColor(1.0f, 0.0f, 0.0f);
            score2.SetColorEmissive(0.0f, 0.0f, 0.0f);
            score2.SetText("" + value2, true);

            AddHUDObject(score2);


            HUDObjectText plus2 = new HUDObjectText("| + |");
            plus2.SetPosition(310f, 250f);
            plus2.Name = "plus2";
            plus2.SetCharacterDistanceFactor(1.0f);
            plus2.SetColor(1.0f, 0.0f, 0.0f);
            plus2.SetColorEmissive(1.0f, 1.0f, 1.0f);

            AddHUDObject(plus2);






            HUDObjectText minus3 = new HUDObjectText("| - |");
            minus3.SetPosition(460f, 350f);
            minus3.Name = "minus3";
            minus3.SetCharacterDistanceFactor(1.0f);
            minus3.SetColor(1.0f, 0.0f, 0.0f);
            minus3.SetColorEmissive(1.0f, 1.0f, 1.0f);

            AddHUDObject(minus3);


            HUDObjectText score3 = new HUDObjectText("| " + value3 + " |");
            score3.SetPosition(460f, 300f);
            score3.Name = "score3";
            score3.SetCharacterDistanceFactor(1.0f);
            score3.SetColor(1.0f, 0.0f, 0.0f);
            score3.SetColorEmissive(0.0f, 0.0f, 0.0f);
            score3.SetText("" + value3, true);

            AddHUDObject(score3);


            HUDObjectText plus3 = new HUDObjectText("| + |");
            plus3.SetPosition(460f, 250f);
            plus3.Name = "plus3";
            plus3.SetCharacterDistanceFactor(1.0f);
            plus3.SetColor(1.0f, 0.0f, 0.0f);
            plus3.SetColorEmissive(1.0f, 1.0f, 1.0f);

            AddHUDObject(plus3);



        }
        public string transelateCode(string text)
        {
            if(text == "1") { text = "1"; }
            if(text == "2") { text = "2"; }
            if(text == "3") { text = "3"; }
            if(text == "4") { text = "4"; }
            if(text == "5") { text = "5"; }
            if(text == "6") { text = "6"; }
            if(text == "7") { text = "7"; }
            if(text == "8") { text = "8"; }
            if(text == "9") { text = "9"; }
            if(text == "10") { text = "0"; }

            if(text == "11"){ text = "A"; }
            if(text == "12"){ text = "B"; }
            if(text == "13"){ text = "C"; }
            if(text == "14"){ text = "D"; }
            if(text == "15"){ text = "E"; }
            if(text == "16"){ text = "F"; }
            if(text == "17"){ text = "G"; }
            if(text == "18"){ text = "H"; }
            if(text == "19"){ text = "I"; }
            if(text == "20"){ text = "J"; }
            if(text == "21"){ text = "K"; }
            if(text == "22"){ text = "L"; }
            if(text == "23"){ text = "M"; }
            if(text == "24"){ text = "N"; }
            if(text == "25"){ text = "O"; }
            if(text == "26"){ text = "P"; }
            if(text == "27"){ text = "Q"; }
            if(text == "28"){ text = "R"; }
            if(text == "29"){ text = "S"; }
            if(text == "30"){ text = "T"; }
            if(text == "31"){ text = "U"; }
            if(text == "32"){ text = "V"; }
            if(text == "33"){ text = "W"; }
            if(text == "34"){ text = "X"; }
            if(text == "35"){ text = "Y"; }
            if(text == "36"){ text = "Z"; }
            return text;
        }
    }
}
