﻿#pragma checksum "C:\Users\Joshua\Desktop\Eggman OS Windows 10 Edition\Eggman OS Windows 10 Edition\Install_Screen.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "558289601A0C0EF6B334E87251E6F642"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Eggman_OS_Windows_10_Edition
{
    partial class Install_Screen : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                    #line 7 "..\..\..\Install_Screen.xaml"
                    ((global::Windows.UI.Xaml.Controls.Page)element1).Loaded += this.Page_Loaded;
                    #line default
                }
                break;
            case 2:
                {
                    this.Installpic = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 3:
                {
                    this.Formatpnl = (global::Windows.UI.Xaml.Controls.RelativePanel)(target);
                }
                break;
            case 4:
                {
                    this.Installprog = (global::Windows.UI.Xaml.Controls.ProgressBar)(target);
                }
                break;
            case 5:
                {
                    this.Actionlbl = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6:
                {
                    this.installermusic = (global::Windows.UI.Xaml.Controls.MediaElement)(target);
                }
                break;
            case 7:
                {
                    this.Formatlbl = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    #line 12 "..\..\..\Install_Screen.xaml"
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.Formatlbl).Tapped += this.Formatlbl_Tapped;
                    #line default
                }
                break;
            case 8:
                {
                    this.Formattingbar = (global::Windows.UI.Xaml.Controls.ProgressBar)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

