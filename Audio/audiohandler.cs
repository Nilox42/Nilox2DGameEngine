using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;
using System.Windows.Forms;

namespace Nilox2DGameEngine.Audio
{
    class audiohandler
    {
        WindowsMediaPlayer media;


        public audiohandler()
        {
            WindowsMediaPlayer media = new WindowsMediaPlayer();
            media.URL = Application.StartupPath + @"\Content\Audio\fireballthrow.mp3";
            //media.settings.volume = 10;
            media.controls.play();
        }

    }
}
