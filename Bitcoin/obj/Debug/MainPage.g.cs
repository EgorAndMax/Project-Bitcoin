﻿

#pragma checksum "C:\Users\Максим\Pictures\Project-Bitcoin\Bitcoin\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FC2901E7B56B7CB8A0F54BD6F3A5CF84"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bitcoin
{
    partial class HubPage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 48 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Hub)(target)).SectionHeaderClick += this.Hub_SectionHeaderClick_Articles;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 125 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.ListViewBase)(target)).ItemClick += this.ItemView_ItemClick;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


