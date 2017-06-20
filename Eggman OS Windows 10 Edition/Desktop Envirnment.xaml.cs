using System;
using Windows.System;
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
using Windows.UI.Core;
using Eggman_OS_Windows_10_Edition.Properties;
using Windows.Networking.Connectivity;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.ApplicationModel.Core;
using Windows.Media.SpeechSynthesis;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Eggman_OS_Windows_10_Edition
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Desktop_Envirnment : Page
    {
        public static DispatcherTimer typingdelay = new DispatcherTimer();

        string holdtext = "";
        private int count;
        private int maxcount;
        bool runonce = false;
        bool caretblick = false;
        bool scrollToBottom = false;
        public string commandstring = "";
        public static bool projecteggactive = false;
        static bool systemcommandeggopen = false;
        public string Text = "";
        int timeinterval = 1000000;

        public Desktop_Envirnment()
        {
            this.InitializeComponent();
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
        }

        ~Desktop_Envirnment()
        {
            Window.Current.CoreWindow.KeyDown -= CoreWindow_KeyDown;
        }

        public void Print(string text, int interval)
        {
            Text = text;
            typingdelay.Interval = new TimeSpan(interval);
            count = 0;
            maxcount = Text.Length;
        }

        private void Text_tick(object sender, object e)
        {
            if (count > maxcount - 1)
            {
                if (!runonce)
                {
                    typingdelay.Interval = new TimeSpan(timeinterval);
                    runonce = true;
                    Commandegg.Text = Commandegg.Text + Environment.NewLine + Eggkernel.username.Trim() + "$>";
                    holdtext = Commandegg.Text;
                    commandstring = "";
                }

                caretblick = !caretblick;
                if (caretblick)
                {
                    Commandegg.Text = holdtext + "_";
                }
                else
                {
                    Commandegg.Text = holdtext + "";
                }
                //Text = commandstring;

                
            }
            else
            {
                runonce = false;
                Commandegg.Text = Commandegg.Text + Text.Substring(count, 1);
                count++;
            }

            if (scrollToBottom)
            {
                scrollviewer.UpdateLayout();
                scrollviewer.ChangeView(0, scrollviewer.ScrollableHeight, 1);
                scrollToBottom = false;
            }
        }

        private void CoreWindow_KeyDown(CoreWindow sender, KeyEventArgs args)
        {
            if (runonce)
            {
                CoreVirtualKeyStates ModKeyShift = Window.Current.CoreWindow.GetKeyState(VirtualKey.Shift);
                scrollToBottom = true;


                if (args.VirtualKey >= VirtualKey.A && args.VirtualKey <= VirtualKey.Z)
                {
                    if (ModKeyShift.HasFlag(CoreVirtualKeyStates.Down))
                    {
                        holdtext = holdtext + args.VirtualKey.ToString();
                        Commandegg.Text = holdtext;
                        commandstring = commandstring + args.VirtualKey.ToString();
                    }
                    else
                    {
                        holdtext = holdtext + args.VirtualKey.ToString().ToLower();
                        Commandegg.Text = holdtext;
                        commandstring = commandstring + args.VirtualKey.ToString().ToLower();
                    }
                }
                else if (args.VirtualKey.ToString() == "220")
                {
                    if (ModKeyShift.HasFlag(CoreVirtualKeyStates.Down))
                    {
                        holdtext = holdtext + "|";
                        Commandegg.Text = holdtext;
                        commandstring = commandstring + "|";
                    }
                    else
                    {
                        holdtext = holdtext + "\\";
                        Commandegg.Text = holdtext;
                        commandstring = commandstring + "\\";
                    }
                }
                else if (args.VirtualKey.ToString() == "190")
                {
                    if (ModKeyShift.HasFlag(CoreVirtualKeyStates.Down))
                    {
                        holdtext = holdtext + ">";
                        Commandegg.Text = holdtext;
                        commandstring = commandstring + ">";
                    }
                    else
                    {
                        holdtext = holdtext + ".";
                        Commandegg.Text = holdtext;
                        commandstring = commandstring + ".";
                    }
                }
                else if (args.VirtualKey.ToString() == "188")
                {
                    if (ModKeyShift.HasFlag(CoreVirtualKeyStates.Down))
                    {
                        holdtext = holdtext + "<";
                        Commandegg.Text = holdtext;
                        commandstring = commandstring + "<";
                    }
                    else
                    {
                        holdtext = holdtext + ",";
                        Commandegg.Text = holdtext;
                        commandstring = commandstring + ",";
                    }
                }
                else if (args.VirtualKey.ToString() == "191")
                {
                    if (ModKeyShift.HasFlag(CoreVirtualKeyStates.Down))
                    {
                        holdtext = holdtext + "?";
                        Commandegg.Text = holdtext;
                        commandstring = commandstring + "?";
                    }
                    else
                    {
                        holdtext = holdtext + "/";
                        Commandegg.Text = holdtext;
                        commandstring = commandstring + "/";
                    }
                }
                else if (args.VirtualKey == VirtualKey.Number0)
                {
                    if (ModKeyShift.HasFlag(CoreVirtualKeyStates.Down))
                    {
                        holdtext = holdtext + ")";
                        Commandegg.Text = holdtext;
                        commandstring = commandstring + ")";
                    }
                    else
                    {
                        holdtext = holdtext + "0";
                        Commandegg.Text = holdtext;
                        commandstring = commandstring + "0";
                    }
                }
                else if (args.VirtualKey == VirtualKey.Number1)
                {
                    if (ModKeyShift.HasFlag(CoreVirtualKeyStates.Down))
                    {
                        holdtext = holdtext + "!";
                        Commandegg.Text = holdtext;
                        commandstring = commandstring + "!";
                    }
                    else
                    {
                        holdtext = holdtext + "1";
                        Commandegg.Text = holdtext;
                        commandstring = commandstring + "1";
                    }
                }
                else if (args.VirtualKey == VirtualKey.Number2)
                {
                    if (ModKeyShift.HasFlag(CoreVirtualKeyStates.Down))
                    {
                        holdtext = holdtext + "@";
                        Commandegg.Text = holdtext;
                        commandstring = commandstring + "@";
                    }
                    else
                    {
                        holdtext = holdtext + "2";
                        Commandegg.Text = holdtext;
                        commandstring = commandstring + "2";
                    }
                }
                else if (args.VirtualKey == VirtualKey.Number3)
                {
                    if (ModKeyShift.HasFlag(CoreVirtualKeyStates.Down))
                    {
                        holdtext = holdtext + "#";
                        Commandegg.Text = holdtext;
                        commandstring = commandstring + "#";
                    }
                    else
                    {
                        holdtext = holdtext + "3";
                        Commandegg.Text = holdtext;
                        commandstring = commandstring + "3";
                    }
                }
                else if (args.VirtualKey == VirtualKey.Number4)
                {
                    if (ModKeyShift.HasFlag(CoreVirtualKeyStates.Down))
                    {
                        holdtext = holdtext + "$";
                        Commandegg.Text = holdtext;
                        commandstring = commandstring + "$";
                    }
                    else
                    {
                        holdtext = holdtext + "4";
                        Commandegg.Text = holdtext;
                        commandstring = commandstring + "4";
                    }
                }
                else if (args.VirtualKey == VirtualKey.Number5)
                {
                    if (ModKeyShift.HasFlag(CoreVirtualKeyStates.Down))
                    {
                        holdtext = holdtext + "%";
                        Commandegg.Text = holdtext;
                        commandstring = commandstring + "%";
                    }
                    else
                    {
                        holdtext = holdtext + "5";
                        Commandegg.Text = holdtext;
                        commandstring = commandstring + "5";
                    }
                }
                else if (args.VirtualKey == VirtualKey.Number6)
                {
                    if (ModKeyShift.HasFlag(CoreVirtualKeyStates.Down))
                    {
                        holdtext = holdtext + "^";
                        Commandegg.Text = holdtext;
                        commandstring = commandstring + "^";
                    }
                    else
                    {
                        holdtext = holdtext + "6";
                        Commandegg.Text = holdtext;
                        commandstring = commandstring + "6";
                    }
                }
                else if (args.VirtualKey == VirtualKey.Number7)
                {
                    if (ModKeyShift.HasFlag(CoreVirtualKeyStates.Down))
                    {
                        holdtext = holdtext + "&";
                        Commandegg.Text = holdtext;
                        commandstring = commandstring + "&";
                    }
                    else
                    {
                        holdtext = holdtext + "7";
                        Commandegg.Text = holdtext;
                        commandstring = commandstring + "7";
                    }
                }
                else if (args.VirtualKey == VirtualKey.Number8)
                {
                    if (ModKeyShift.HasFlag(CoreVirtualKeyStates.Down))
                    {
                        holdtext = holdtext + "*";
                        Commandegg.Text = holdtext;
                        commandstring = commandstring + "*";
                    }
                    else
                    {
                        holdtext = holdtext + "8";
                        Commandegg.Text = holdtext;
                        commandstring = commandstring + "8";
                    }
                }
                else if (args.VirtualKey == VirtualKey.Number9)
                {
                    if (ModKeyShift.HasFlag(CoreVirtualKeyStates.Down))
                    {
                        holdtext = holdtext + "(";
                        Commandegg.Text = holdtext;
                        commandstring = commandstring + "(";
                    }
                    else
                    {
                        holdtext = holdtext + "9";
                        Commandegg.Text = holdtext;
                        commandstring = commandstring + "9";
                    }
                }
                else if (args.VirtualKey.ToString() == "189")
                {
                    if (ModKeyShift.HasFlag(CoreVirtualKeyStates.Down))
                    {
                        holdtext = holdtext + "_";
                        Commandegg.Text = holdtext;
                        commandstring = commandstring + "_";
                    }
                    else
                    {
                        holdtext = holdtext + "-";
                        Commandegg.Text = holdtext;
                        commandstring = commandstring + "-";
                    }
                }
                else if (args.VirtualKey.ToString() == "187")
                {
                    if (ModKeyShift.HasFlag(CoreVirtualKeyStates.Down))
                    {
                        holdtext = holdtext + "+";
                        Commandegg.Text = holdtext;
                        commandstring = commandstring + "+";
                    }
                    else
                    {
                        holdtext = holdtext + "=";
                        Commandegg.Text = holdtext;
                        commandstring = commandstring + "=";
                    }
                }
                else if (args.VirtualKey == VirtualKey.Space)
                {
                    holdtext = holdtext + " ";
                    Commandegg.Text = holdtext;
                    commandstring = commandstring + " ";
                }
                else if (args.VirtualKey == VirtualKey.Back)
                {
                    if (commandstring.Length > 0)
                    {
                        holdtext = holdtext.Substring(0, holdtext.Length - 1);
                        Commandegg.Text = holdtext;
                        commandstring = commandstring.Substring(0, commandstring.Length - 1);
                    }
                }
                else if (args.VirtualKey == VirtualKey.Add)
                {
                    holdtext = holdtext + "+";
                    Commandegg.Text = holdtext;
                    commandstring = commandstring + "+";
                }
                else if (args.VirtualKey == VirtualKey.Subtract)
                {
                    holdtext = holdtext + "-";
                    Commandegg.Text = holdtext;
                    commandstring = commandstring + "-";
                }
                else if (args.VirtualKey == VirtualKey.Multiply)
                {
                    holdtext = holdtext + "*";
                    Commandegg.Text = holdtext;
                    commandstring = commandstring + "*";
                }
                else if (args.VirtualKey == VirtualKey.Divide)
                {
                    holdtext = holdtext + "/";
                    Commandegg.Text = holdtext;
                    commandstring = commandstring + "/";
                }
                else if (args.VirtualKey == VirtualKey.Enter)
                {
                    commandlistAsync();
                }
            }
            //Commandegg.Text = Commandegg.Text + args.VirtualKey.ToString() + Environment.NewLine;

        }

        public async void commandlistAsync()
        {
            holdtext = holdtext + Environment.NewLine;
            holdtext = holdtext + "EggmanOS status: ";
            if (commandstring == "help")
            {
                holdtext += "There is no help, just type in stuff";
                commandstring = "";
            }
            else if (commandstring == "log")
            {
                for (int i = 0; i <= Eggkernel.log.Count; i++)
                {
                    try
                    {
                        holdtext = holdtext + Environment.NewLine + Eggkernel.log[i];
                    }
                    catch
                    {

                    }
                }
                commandstring = "";
            }
            else if (commandstring.StartsWith("print"))
            {
                Commandegg.Text = holdtext;
                Print(commandstring.Remove(0, 5), timeinterval);
                commandstring = "";
            }
            else if (commandstring.StartsWith("ipaddress"))
            {
                Commandegg.Text = holdtext;

                try
                {
                    var icp = NetworkInformation.GetInternetConnectionProfile();

                    Windows.Networking.HostName hostname = NetworkInformation.GetHostNames().SingleOrDefault(hn => hn.IPInformation?.NetworkAdapter != null && hn.IPInformation.NetworkAdapter.NetworkAdapterId == icp.NetworkAdapter.NetworkAdapterId);

                    // the ip address
                    holdtext += hostname?.CanonicalName;
                }
                catch
                {
                    holdtext += "Not connected to the internet";
                }
                commandstring = "";
            }
            else if (commandstring == "shutdown")
            {
                CoreApplication.Exit();
            }
            else if (commandstring == "projectegg")
            {
                if (!projecteggactive)
                {
                    holdtext += "Loading old Eggman Window Environment Manager";
                    /*
                    Powereggman power = new Powereggman();
                    power.Show();
                    projecteggactive = true;
                    Commandegg.Hide();
                    if (!(Eggkernel.background == "Default"))
                        Desktop.switcher = true;
                        */
                    holdtext += Environment.NewLine + "Not coded yet";
                }
            }
            else if (commandstring.StartsWith("Speak "))
            {
                try
                {
                    // The string to speak with SSML customizations.
                    string Ssml =
                        @"<speak version='1.0' " +
                        "xmlns='http://www.w3.org/2001/10/synthesis' xml:lang='en-US'>" +
                        "<prosody contour='(0%,+80Hz) (10%,+80%) (40%,+80Hz)'>" + commandstring.Remove(0, 5) + "</prosody> " +
                        "</speak>";

                    // The media object for controlling and playing audio.
                    MediaElement mediaElement = new MediaElement();

                    // The object for controlling the speech synthesis engine (voice).
                    var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();

                    // Generate the audio stream from plain text.
                    SpeechSynthesisStream stream = await synth.SynthesizeSsmlToStreamAsync(Ssml/*commandstring.Remove(0, 5)*/);

                    // Send the stream to the media object.
                    mediaElement.SetSource(stream, stream.ContentType);
                    mediaElement.Play();
                }
                catch (Exception e)
                {
                    holdtext += "There is and error: " + e;
                    commandstring = "";
                }
            }
            else if (commandstring.StartsWith("checkpaths"))
            {
                try
                {
                    holdtext += Environment.NewLine + "Userpath: " + Eggkernel.userpath.Path;
                }
                catch(Exception e)
                {
                    holdtext += Environment.NewLine + "Userpath failed with" + e.Message;
                }
                try
                {
                    holdtext += Environment.NewLine + "Doc: " + Eggkernel.doc.Path;
                }
                catch (Exception e)
                {
                    holdtext += Environment.NewLine + "Doc failed with" + e.Message;
                }
                try
                {
                    holdtext += Environment.NewLine + "Videos: " + Eggkernel.video.Path;
                }
                catch (Exception e)
                {
                    holdtext += Environment.NewLine + "Videos failed with" + e.Message;
                }
                try
                {
                    holdtext += Environment.NewLine + "Music: " + Eggkernel.music.Path;
                }
                catch (Exception e)
                {
                    holdtext += Environment.NewLine + "Music failed with" + e.Message;
                }
                try
                {
                    holdtext += Environment.NewLine + "Pictures: " + Eggkernel.pictures.Path;
                }
                catch (Exception e)
                {
                    holdtext += Environment.NewLine + "Pictures failed with" + e.Message;
                }
                try
                {
                    holdtext += Environment.NewLine + "Desktop: " + Eggkernel.desktop.Path;
                }
                catch (Exception e)
                {
                    holdtext += Environment.NewLine + "Desktop failed with" + e.Message;
                }
                try
                {
                    holdtext += Environment.NewLine + "Startupsound: " + Eggkernel.startsound.Path;
                }
                catch (Exception e)
                {
                    holdtext += Environment.NewLine + "Startupsound failed with" + e.Message;
                }
                try
                {
                    holdtext += Environment.NewLine + "Errorsound: " + Eggkernel.errorsound.Path;
                }
                catch (Exception e)
                {
                    holdtext += Environment.NewLine + "Errorsound failed with" + e.Message;
                }
                try
                {
                    holdtext += Environment.NewLine + "Exclamation: " + Eggkernel.exclamationsound.Path;
                }
                catch (Exception e)
                {
                    holdtext += Environment.NewLine + "Exclamation failed with" + e.Message;
                }
                try
                {
                    holdtext += Environment.NewLine + "Welcomesound: " + Eggkernel.welcomesound.Path;
                }
                catch (Exception e)
                {
                    holdtext += Environment.NewLine + "Welcomesound failed with" + e.Message;
                }
                try
                {
                    holdtext += Environment.NewLine + "Background: " + Eggkernel.background.Path;
                }
                catch (Exception e)
                {
                    holdtext += Environment.NewLine + "Background failed with" + e.Message;
                }
                commandstring = "";
                //Process.Start(Eggkernel.eggsys32folder + "EggmanPlayer.exe");
            }
            else
            {
                holdtext += "The command \"" + commandstring + "\" does not have any meaning. " +
                    Environment.NewLine + "If this command is a name of a script, please install it";
            }
            holdtext = holdtext + Environment.NewLine + Eggkernel.username.Trim() + "$>";
            Commandegg.Text = holdtext;
            commandstring = "";
        }

        private void Commandegg_Loaded(object sender, RoutedEventArgs e)
        {
            typingdelay.Tick += Text_tick;
            typingdelay.Interval = new TimeSpan(timeinterval);
            typingdelay.Start();
            if (!systemcommandeggopen)
            {
                systemcommandeggopen = true;
                Print("Welcome to the EggmanOS" + Environment.NewLine + "However, there are some errors that are preventing the Eggman Window Environment Manager from loading. ", timeinterval);
                systemcommandeggopen = true;
            }
            else
            {
                Print("Welcome to the EggmanOS", timeinterval);
            }
            scrollToBottom = true;
        }
    }
}
