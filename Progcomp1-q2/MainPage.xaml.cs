using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Progcomp1_q2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void DataChanged()
        {
            int x = 0, y = 0;
            foreach (Command c in list.Items)
            {
                if (c.Direction.Equals(Command.DIRECTION_NORTH))
                    y += c.Distance;
                else if (c.Direction.Equals(Command.DIRECTION_EAST))
                    x += c.Distance;
                else if (c.Direction.Equals(Command.DIRECTION_SOUTH))
                    y -= c.Distance;
                else if (c.Direction.Equals(Command.DIRECTION_WEST))
                    x -= c.Distance;
                else if (c.Direction.Equals(Command.DIRECTION_NORTHEAST))
                {
                    x += c.Distance; y += c.Distance;
                }
                else if (c.Direction.Equals(Command.DIRECTION_SOUTHEAST))
                {
                    x += c.Distance; y -= c.Distance;
                }
                else if (c.Direction.Equals(Command.DIRECTION_SOUTHWEST))
                {
                    x -= c.Distance; y -= c.Distance;
                }
                else if (c.Direction.Equals(Command.DIRECTION_NORTHWEST))
                {
                    x -= c.Distance; y += c.Distance;
                }
            }

            location.Text = "{" + x + ", " + y + "}";
        }

        public class Command
        {
            public const int DIRECTION_NORTH = 0;
            public const int DIRECTION_NORTHEAST = 1;
            public const int DIRECTION_EAST = 2;
            public const int DIRECTION_SOUTHEAST = 3;
            public const int DIRECTION_SOUTH = 4;
            public const int DIRECTION_SOUTHWEST = 5;
            public const int DIRECTION_WEST = 6;
            public const int DIRECTION_NORTHWEST = 7;

            public Command()
            {
            }

            public Command(int direction, int distance)
            {
                this.Direction = direction;
                this.Distance = distance;
            }

            public string DirectionString
            {
                get
                {
                    string dir;
                    switch (this.Direction)
                    {
                        case (DIRECTION_NORTH):
                            dir = "North";
                            break;
                        case (DIRECTION_NORTHEAST):
                            dir = "North East";
                            break;
                        case (DIRECTION_EAST):
                            dir = "East";
                            break;
                        case (DIRECTION_SOUTHEAST):
                            dir = "Sourth East";
                            break;
                        case (DIRECTION_SOUTH):
                            dir = "South";
                            break;
                        case (DIRECTION_SOUTHWEST):
                            dir = "South West";
                            break;
                        case (DIRECTION_WEST):
                            dir = "West";
                            break;
                        case (DIRECTION_NORTHWEST):
                            dir = "North West";
                            break;
                        default:
                            dir = "Unknown";
                            break;
                    }

                    return dir;
                }
            }

            public int Distance { set; get; }

            public int Direction { set; get; }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] moves = importText.Text.Split("\r\n".ToCharArray());

            foreach (string move in moves)
            {
                string[] a = move.Split(' ');

                if (a.Length == 2) {

                    Command c = new Command();

                    if (a[0].Equals("N"))
                    {
                        c.Direction = Command.DIRECTION_NORTH;
                    }
                    else if (a[0].Equals("NE"))
                    {
                        c.Direction = Command.DIRECTION_NORTHEAST;
                    }
                    else if (a[0].Equals("E"))
                    {
                        c.Direction = Command.DIRECTION_EAST;
                    }
                    else if (a[0].Equals("SE"))
                    {
                        c.Direction = Command.DIRECTION_SOUTHEAST;
                    }
                    else if (a[0].Equals("S"))
                    {
                        c.Direction = Command.DIRECTION_SOUTH;
                    }
                    else if (a[0].Equals("SW"))
                    {
                        c.Direction = Command.DIRECTION_SOUTHWEST;
                    }
                    else if (a[0].Equals("W"))
                    {
                        c.Direction = Command.DIRECTION_WEST;
                    }
                    else if (a[0].Equals("NW"))
                    {
                        c.Direction = Command.DIRECTION_NORTHWEST;
                    }

                    c.Distance = Int16.Parse(a[1]);

                    list.Items.Add(c);
                }
            }

            DataChanged();
            importText.Text = "";
        }
    }
}
