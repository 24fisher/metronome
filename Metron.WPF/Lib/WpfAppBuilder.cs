﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metron;

namespace Metron
{
    public class WpfAppBuilder: IAppBuilder
    {

        public WpfAppBuilder()
        {
            TimerImplementor = new TimerWin32Adapted();
            SoundImplementor = new WPFAudioFileBeep();
            ColorImplementor = new ColorWPF();
            XmlDocImplementor = new WpfPlatformSpecificXmlDoc();
        }

        public ITimer TimerImplementor { get; set; }
        public IMetromomeSound SoundImplementor { get; set; }
        public IColor ColorImplementor { get; set; }
        public IPlatformSpecificXMLDoc XmlDocImplementor { get; set; }
    }
}
