﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 15.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace HackerNewsUwp.Ui.Tests.Screens.MainPage.MainPageMapClasses
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITest.Input;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.WindowsRuntimeControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = Microsoft.VisualStudio.TestTools.UITest.Input.MouseButtons;
    
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public partial class MainPageMap
    {
        
        #region Properties
        public UIHackerNewsUwpWindow UIHackerNewsUwpWindow
        {
            get
            {
                if ((this.mUIHackerNewsUwpWindow == null))
                {
                    this.mUIHackerNewsUwpWindow = new UIHackerNewsUwpWindow();
                }
                return this.mUIHackerNewsUwpWindow;
            }
        }
        #endregion
        
        #region Fields
        private UIHackerNewsUwpWindow mUIHackerNewsUwpWindow;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UIHackerNewsUwpWindow : XamlWindow
    {
        
        public UIHackerNewsUwpWindow()
        {
            #region Search Criteria
            this.SearchProperties[XamlControl.PropertyNames.Name] = "HackerNewsUwp";
            this.SearchProperties[XamlControl.PropertyNames.ClassName] = "Windows.UI.Core.CoreWindow";
            this.WindowTitles.Add("HackerNewsUwp");
            #endregion
        }
        
        #region Properties
        public XamlEdit UITxtTitleEdit
        {
            get
            {
                if ((this.mUITxtTitleEdit == null))
                {
                    this.mUITxtTitleEdit = new XamlEdit(this);
                    #region Search Criteria
                    this.mUITxtTitleEdit.SearchProperties[XamlEdit.PropertyNames.AutomationId] = "TxtTitle";
                    this.mUITxtTitleEdit.WindowTitles.Add("HackerNewsUwp");
                    #endregion
                }
                return this.mUITxtTitleEdit;
            }
        }
        #endregion
        
        #region Fields
        private XamlEdit mUITxtTitleEdit;
        #endregion
    }
}