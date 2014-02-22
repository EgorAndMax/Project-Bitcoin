using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Bitcoin;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Bitcoin
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Graphic : Page
    {
        //HubPage rootPage = HubPage.
        public Graphic()
        {
            this.InitializeComponent();
            webView1.NavigationStarting += webView1_NavigationStarting;
            webView1.ContentLoading += webView1_ContentLoading;
            webView1.DOMContentLoaded += webView1_DOMContentLoaded;
            webView1.UnviewableContentIdentified += webView1_UnviewableContentIdentified;
            webView1.NavigationCompleted += webView1_NavigationCompleted;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            NavigateWebview("https://blockchain.info/ru/charts/market-price?timespan=30days&showDataPoints=false&daysAverageString=1&show_header=false&scale=0&address=");
        }
        private void NavigateWebview(string url)
        {
            try
            {
                Uri targetUri = new Uri(url);
                webView1.Navigate(targetUri);
            }
            catch (FormatException myE)
            {
                // Bad address
                webView1.NavigateToString(String.Format("<h1>Address is invalid, try again.  Details --> {0}.</h1>", myE.Message));
            }
        }
        private bool _pageIsLoading;
        bool pageIsLoading
        {
            get { return _pageIsLoading; }
            set
            {
                _pageIsLoading = value;
                progressRing1.Visibility = (value ? Visibility.Visible : Visibility.Collapsed);
            }
        }
        void webView1_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            string url = "";
            try { url = args.Uri.ToString(); }
            finally
            {
                pageIsLoading = true;
            }
        }
        void webView1_UnviewableContentIdentified(WebView sender, WebViewUnviewableContentIdentifiedEventArgs args)
        {
            // We turn around and hand the Uri to the system launcher to launch the default handler for it
            Windows.Foundation.IAsyncOperation<bool> b = Windows.System.Launcher.LaunchUriAsync(args.Uri);
            pageIsLoading = false;
        }
        void webView1_ContentLoading(WebView sender, WebViewContentLoadingEventArgs args)
        {
            string url = (args.Uri != null) ? args.Uri.ToString() : "<null>";
        }
        void webView1_DOMContentLoaded(WebView sender, WebViewDOMContentLoadedEventArgs args)
        {
            string url = (args.Uri != null) ? args.Uri.ToString() : "<null>";
        }
        void webView1_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            pageIsLoading = false;
            if (args.IsSuccess)
            {
                string url = (args.Uri != null) ? args.Uri.ToString() : "<null>";
            }
            else
            {
                string url = "";
                try { url = args.Uri.ToString(); }
                finally { }
            }
        }
    }
}
