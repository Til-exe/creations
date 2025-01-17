using Gruppenprojekt.App.Menus;
using KWEngine3;
using KWEngine3.GameObjects;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppenprojekt.App.death_winscreen
{
    public class death1 : World
    {
        float finalOP = float.Epsilon;
        
        int counter = 0;
       
        private HUDObjectText[] myTextObjects = new HUDObjectText[5];
        private bool[] myTextObjectsFall = new bool[5];
        
        public override void Act()
        {
            
            
            myTextObjects[0] = GetHUDObjectTextByName("main");
            myTextObjects[1] = GetHUDObjectTextByName("tryagain");
            myTextObjects[2] = GetHUDObjectTextByName("yes");
            myTextObjects[3] = GetHUDObjectTextByName("no");
            myTextObjects[4] = GetHUDObjectTextByName("menu");

            if(counter == 0)
            {
                // Fall: opacity steigt an
                if (myTextObjectsFall[0] == false)
                {
                    finalOP += 0.0025f;
                    myTextObjects[0].SetOpacity(finalOP);

                    if(finalOP >= 1)
                    {
                        myTextObjectsFall[counter] = true;
                    }
                }
                else
                {
                    finalOP -= 0.005f;
                    myTextObjects[0].SetOpacity(finalOP);
                    if(finalOP <= 0)
                    {
                        counter++;
                    }
                }
            }
            if(counter >= 1 && counter < 5)
            {
                if (myTextObjectsFall[counter] == false && myTextObjectsFall[counter] != null)
                {
                    finalOP += 0.0025f;
                    myTextObjects[counter].SetOpacity(finalOP);

                    if (finalOP >= 1)
                    {
                        myTextObjectsFall[counter] = true;
                        finalOP = 0;
                        counter++;
                    }
                    
                }
                
            }



            if (myTextObjects[4] != null)
            {
                if (myTextObjects[4].IsMouseCursorOnMe() == true)
                {
                    myTextObjects[4].SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    myTextObjects[4].SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && myTextObjects[4].IsMouseCursorOnMe() == true)
                {
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/click.wav", false, 0.2f);
                    GameWorldStartMenu gm = new GameWorldStartMenu();
                    Window.SetWorld(gm);
                }
            }

            if (myTextObjects[3] != null)
            {
                if (myTextObjects[3].IsMouseCursorOnMe() == true)
                {
                    myTextObjects[3].SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    myTextObjects[3].SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && myTextObjects[3].IsMouseCursorOnMe() == true)
                {
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/click.wav", false, 0.2f);
                    Window.Close();
                }
            }

            if (myTextObjects[2] != null)
            {
                if (myTextObjects[2].IsMouseCursorOnMe() == true)
                {
                    myTextObjects[2].SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    myTextObjects[2].SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && myTextObjects[2].IsMouseCursorOnMe() == true)
                {
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/click.wav", false, 0.2f);
                    GameWorldStart gm = new GameWorldStart();   
                    Window.SetWorld(gm);
                }
            }
        }

        public override void Prepare()
        {
            HUDObjectText main = new HUDObjectText("You died");
            main.SetTextAlignment(TextAlignMode.Center);
            main.Name = "main";
            main.SetColor(1, 0, 0);
            main.SetPosition(540, 360);

            HUDObjectText tryagain = new HUDObjectText("Do you want to try again ?");
            tryagain.SetTextAlignment(TextAlignMode.Center);
            tryagain.Name = "tryagain";
            tryagain.SetColor(1, 0, 0);
            tryagain.SetPosition(590, 360);
            tryagain.SetOpacity(0);

            HUDObjectText yes = new HUDObjectText("YES");
            yes.Name = "yes";
            yes.SetColor(1, 0, 0);
            yes.SetPosition(350, 460);
            yes.SetOpacity(0);

            HUDObjectText no = new HUDObjectText("NO");
            no.Name = "no"; 
            no.SetColor(1, 0, 0);
            no.SetPosition(550, 460);
            no.SetOpacity(0);

            HUDObjectText menu = new HUDObjectText("MENU");
            menu.Name = "menu";
            menu.SetColor(1, 0, 0);
            menu.SetPosition(750, 460);
            menu.SetOpacity(0);

            AddHUDObject(main);
            AddHUDObject(tryagain);
            AddHUDObject(yes);
            AddHUDObject(no);
            AddHUDObject(menu);
        }
    }
}
