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
        float finalOP;
        bool OPcheck = false;
        int counter = 0;
        private HUDObjectText[] myTextObjects = new HUDObjectText[5];
        public override void Act()
        {
            
           myTextObjects[0] = GetHUDObjectTextByName("main");
            myTextObjects[1] = GetHUDObjectTextByName("tryagain");

            if (finalOP < 2.5f && OPcheck == false)
            {
                finalOP += 0.005f;
            }
            if (finalOP >=2.5f) { OPcheck = true; }

            if(OPcheck) {
                Console.WriteLine(finalOP);
                finalOP -= 0.005f; 
            }

            if (myTextObjects[counter] != null)
            {
                myTextObjects[counter].SetOpacity(finalOP);
            }
            

            if(finalOP < 0 )
            {
                RemoveHUDObject(myTextObjects[counter]);
                finalOP = 0;
                OPcheck = false;
                counter++;
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

            HUDObjectText no = new HUDObjectText("NO");
            no.Name = "no"; 
            no.SetColor(1, 0, 0);
            no.SetPosition(550, 460);

            HUDObjectText menu = new HUDObjectText("MENU");
            menu.Name = "menu";
            menu.SetColor(1, 0, 0);
            menu.SetPosition(750, 460);
            

            AddHUDObject(main);
            AddHUDObject(tryagain);
            AddHUDObject(yes);
            AddHUDObject(no);
            AddHUDObject(menu);
        }
    }
}
