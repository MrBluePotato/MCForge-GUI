using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using net.mcforge.system;

namespace MCForge.Gui
{
    public class GUISettings
    {
        private net.mcforge.util.properties.Properties prop;

        public bool showNews
        {
            get
            {
                if (!prop.hasValue("show-news"))
                    prop.addSetting("show-news", true);
                return prop.getBool("show-news");
            }
            set
            {
                prop.updateSetting("show-news", value);
                save();
            }
        }

        public bool showUpdateNotification
        {
            get
            {
                if (!prop.hasValue("show-update"))
                    prop.addSetting("show-update", true);
                return prop.getBool("show-update");
            }
            set
            {
                prop.updateSetting("show-update", value);
                save();
            }
        }

        public GUISettings()
        {
            prop = new net.mcforge.util.properties.Properties();
            load();
        }

        public void save()
        {
            prop.save("guisettings.config");
        }

        public void load()
        {
            prop.load("guisettings.config");
        }
    }
}
