using KWEngine3;
using KWEngine3.GameObjects;
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
        float framecounter = 0;
        bool OPcheck = false;
        bool HUD1_removed = false;
        int counter = 0;
        bool finish = false;
        private HUDObjectText[] myTextObjects = new HUDObjectText[5];
        private bool[] myTextObjectsFall = new bool[5];
        private int _phase = 0; // 0 = you died, 1 = try again, 2 = rest
        public override void Act()
        {
            framecounter++; 
            
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
            /*
            if (finalOP < 2.5f && OPcheck == false)
            {
                finalOP += 0.005f;
            }
            if (finalOP >=2.5f) { OPcheck = true; }

            if(OPcheck && finish == false) {
                Console.WriteLine(finalOP);
                finalOP -= 0.005f; 
            }
            if (myTextObjects[counter] != null)
            {
                myTextObjects[counter].SetOpacity(finalOP);

                if(HUD1_removed == true && finalOP < 0) 
                {
                    finish = true;
                    

                    myTextObjects[2].SetOpacity(finalOP);
                    myTextObjects[3].SetOpacity(finalOP);
                    myTextObjects[4].SetOpacity(finalOP);
                    OPcheck = false;

                }
            }

            
            

            if(finalOP < 0 && finish == false )
            {
                RemoveHUDObject(myTextObjects[0]);
                finalOP = 0;
                
                counter++;
                HUD1_removed = true;
            }
            if (finalOP < 0) { OPcheck = false; }
            */
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
