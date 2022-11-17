using BD.Automation.Core.Common.Utils;
using BD.Automation.Core.Drivers.Interface;
using BD.Automation.Core.Drivers.Models;
using BD.Automation.Core.Drivers.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCESymp.UI.Utilities
{
    public abstract class GlobalPageSection<TypeOfSection> : BaseDriver where TypeOfSection : new()
    {        
        //private data members
        private static TypeOfSection section;
        protected Wrappers Utilities = new();

        //using properties
        public static TypeOfSection Section
        {
            get
            {
                if (section == null)
                {
                    section = new TypeOfSection();
                }
                return section;
            }
        }        

        /// <summary>
        /// Opens the link refered to by the element in a new tab.
        /// </summary>
        /// <param name="element">Element to be clicked so the action performed can be opened in a new tab.</param>
        public void OpenInNewTab(IElement element)
        {
            element.ThrowIfNull(nameof(element));

            driver.Action.ClearActions();
            driver.Action.KeyDown(Keys.LeftControl);
            driver.Action.Click(element);
            driver.Action.KeyUp(Keys.LeftControl);
            driver.Action.Perform(true);
            driver.Wait.UntilPageLoadIsComplete(15);
        }

        /// <summary>
        /// Opens the link refered to by the element in a new window.
        /// </summary>
        /// <param name="element">Element to be clicked so the action performed can be opened in a new tab.</param>
        public void OpenInNewWindow(IElement element)
        {
            element.ThrowIfNull(nameof(element));

            driver.Action.ClearActions();
            driver.Action.KeyDown(Keys.LeftShift);
            driver.Action.Click(element);
            driver.Action.Perform(true);
            driver.Wait.UntilPageLoadIsComplete(15);
        }
    }
}
