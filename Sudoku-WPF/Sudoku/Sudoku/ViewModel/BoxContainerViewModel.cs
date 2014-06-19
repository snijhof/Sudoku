using Sudoku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SudokuGame.ViewModel
{
    class BoxContainerViewModel : AbstractViewModel
    {
        private IGame myGame = new Game();
        private short xPosition;
        private short yPosition;
        private string topLeft, topCenter, topRight;
        private string middleLeft, middleCenter, middleRight;
        private string bottomLeft, bottomCenter, bottomRight;
        private int succeeded;

        private Brush topLeftColor, topCenterColor, topRightColor;
        private Brush middleLeftColor, middleCenterColor, middleRightColor;
        private Brush bottomLeftColor, bottomCenterColor, bottomRightColor;

        #region DataBinding

        public string TopLeft 
        { 
            get
            {
                return topLeft;
            }
            set
            {
                if (succeeded == 0)
                {
                    BorderColorTopLeft = new SolidColorBrush(Colors.Red);
                }
                topLeft = value;
                OnPropertyChanged("TopLeft");
            }
        }
        public string TopCenter
        {
            get
            {
                return topCenter;
            }
            set
            {
                if (succeeded == 0)
                {
                    BorderColorTopCenter = new SolidColorBrush(Colors.Red);
                }
                topCenter = value;
                OnPropertyChanged("TopCenter");
            }
        }
        public string TopRight
        {
            get
            {
                return topRight;
            }
            set
            {
                if (succeeded == 0)
                {
                    BorderColorTopRight = new SolidColorBrush(Colors.Red);
                }
                topRight = value;
                OnPropertyChanged("TopRight");
            }
        }

        public string MiddleLeft
        {
            get
            {
                return middleLeft;
            }
            set
            {
                if (succeeded == 0)
                {
                    BorderColorMiddleLeft = new SolidColorBrush(Colors.Red);
                }
                middleLeft = value;
                OnPropertyChanged("MiddleLeft");
            }
        }
        public string MiddleCenter
        {
            get
            {
                return middleCenter;
            }
            set
            {
                if (succeeded == 0)
                {
                    BorderColorMiddleCenter = new SolidColorBrush(Colors.Red);
                }
                middleCenter = value;
                OnPropertyChanged("MiddleCenter");
            }
        }
        public string MiddleRight
        {
            get
            {
                return middleRight;
            }
            set
            {
                if (succeeded == 0)
                {
                    BorderColorMiddleRight = new SolidColorBrush(Colors.Red);
                }
                middleRight = value;
                OnPropertyChanged("MiddleRight");
            }
        }

        public string BottomLeft
        {
            get
            {
                return bottomLeft;
            }
            set
            {
                if (succeeded == 0)
                {
                    BorderColorBottomLeft = new SolidColorBrush(Colors.Red);
                }
                bottomLeft = value;
                OnPropertyChanged("BottomLeft");
            }
        }
        public string BottomCenter
        {
            get
            {
                return bottomCenter;
            }
            set
            {
                if (succeeded == 0)
                {
                    BorderColorBottomCenter = new SolidColorBrush(Colors.Red);
                }
                bottomCenter = value;
                OnPropertyChanged("BottomCenter");
            }
        }
        public string BottomRight
        {
            get
            {
                return bottomRight;
            }
            set
            {
                if (succeeded == 0)
                {
                    BorderColorBottomRight = new SolidColorBrush(Colors.Red);
                }
                bottomRight = value;
                OnPropertyChanged("BottomRight");
            }
        }

        public bool TopLeftEnabled { get; set; }
        public bool TopCenterEnabled { get; set; }
        public bool TopRightEnabled { get; set; }

        public bool MiddleLeftEnabled { get; set; }
        public bool MiddleCenterEnabled { get; set; }
        public bool MiddleRightEnabled { get; set; }

        public bool BottomLeftEnabled { get; set; }
        public bool BottomCenterEnabled { get; set; }
        public bool BottomRightEnabled { get; set; }

        public Brush BorderColorTopLeft
        {
            get
            {
                return topLeftColor;
            }
            set
            {
                topLeftColor = value;
                OnPropertyChanged("BorderColorTopLeft");
            }
        }
        public Brush BorderColorTopCenter
        {
            get
            {
                return topCenterColor;
            }
            set
            {
                topCenterColor = value;
                OnPropertyChanged("BorderColorTopCenter");
            }
        }
        public Brush BorderColorTopRight
        {
            get
            {
                return topRightColor;
            }
            set
            {
                topRightColor = value;
                OnPropertyChanged("BorderColorTopRight");
            }
        }

        public Brush BorderColorMiddleLeft
        {
            get
            {
                return middleLeftColor;
            }
            set
            {
                middleLeftColor = value;
                OnPropertyChanged("BorderColorMiddleLeft");

            }
        }
        public Brush BorderColorMiddleCenter
        {
            get
            {
                return middleCenterColor;
            }
            set
            {
                middleCenterColor = value;
                OnPropertyChanged("BorderColorMiddleCenter");
            }
        }
        public Brush BorderColorMiddleRight
        {
            get
            {
                return middleRightColor;
            }
            set
            {
                middleRightColor = value;
                OnPropertyChanged("BorderColorMiddleRight");
            }
        }

        public Brush BorderColorBottomLeft
        {
            get
            {
                return bottomLeftColor;
            }
            set
            {
                bottomLeftColor = value;
                OnPropertyChanged("BorderColorBottomLeft");
            }
        }
        public Brush BorderColorBottomCenter
        {
            get
            {
                return bottomCenterColor;
            }
            set
            {
                bottomCenterColor = value;
                OnPropertyChanged("BorderColorBottomCenter");
            }
        }
        public Brush BorderColorBottomRight
        {
            get
            {
                return bottomRightColor;
            }
            set
            {
                bottomRightColor = value;
                OnPropertyChanged("BorderColorBottomRight");
            }
        }

        #endregion

        public BoxContainerViewModel(short[] values)
        {
            // Set the values
            topLeft = values[0] == 0 ? "" : "" + values[0];
            topCenter = values[1] == 0 ? "" : "" + values[1];
            topRight = values[2] == 0 ? "" : "" + values[2];

            middleLeft = values[3] == 0 ? "" : "" + values[3];
            middleCenter = values[4] == 0 ? "" : "" + values[4];
            middleRight = values[5] == 0 ? "" : "" + values[5];

            bottomLeft = values[6] == 0 ? "" : "" + values[6];
            bottomCenter = values[7] == 0 ? "" : "" + values[7];
            bottomRight = values[8] == 0 ? "" : "" + values[8];

            // Enable and disable the comboboxes
            TopLeftEnabled = values[0] != 0 ? false : true;
            TopCenterEnabled = values[1] != 0 ? false : true;
            TopRightEnabled = values[2] != 0 ? false : true;
            MiddleLeftEnabled = values[3] != 0 ? false : true;
            MiddleCenterEnabled = values[4] != 0 ? false : true;
            MiddleRightEnabled = values[5] != 0 ? false : true;
            BottomLeftEnabled = values[6] != 0 ? false : true;
            BottomCenterEnabled = values[7] != 0 ? false : true;
            BottomRightEnabled = values[8] != 0 ? false : true;

            // Set the borders
            topLeftColor = new SolidColorBrush(Colors.Gray);
            topCenterColor = new SolidColorBrush(Colors.Gray);
            topRightColor = new SolidColorBrush(Colors.Gray);
            middleLeftColor = new SolidColorBrush(Colors.Gray);
            middleCenterColor = new SolidColorBrush(Colors.Gray);
            middleRightColor = new SolidColorBrush(Colors.Gray);
            bottomLeftColor = new SolidColorBrush(Colors.Gray);
            bottomCenterColor = new SolidColorBrush(Colors.Gray);
            bottomRightColor = new SolidColorBrush(Colors.Gray);
        }

        public void Submit(short x, short y, short value, int succeeded) 
        {
            this.succeeded = succeeded;

            if (x < 7 && x > 3)
            {
                x -= 3;
            }
            else if (x > 7)
            {
                x -= 6;
            }

            if (y < 7 && y > 3)
            {
                y -= 3;
            }
            else if (y > 7)
            {
                y -= 6;
            }

            switch (y)
            {
                case 1: 
                    switch (x)
                    {
                        case 1: TopLeft = "" + value; break;
                        case 2: TopCenter = "" + value; break;
                        case 3: TopRight = "" + value; break;
                    } break;
                case 2: 
                    switch (x)
                    {
                        case 1: MiddleLeft = "" + value; break;
                        case 2: MiddleCenter = "" + value; break;
                        case 3: MiddleRight = "" + value; break;
                    } break;
                case 3: 
                    switch (x)
                    {
                        case 1: BottomLeft = "" + value; break;
                        case 2: BottomCenter = "" + value; break;
                        case 3: BottomRight = "" + value; break;
                    } break;
            }
        }
        
        protected override void initRelayCommands()
        {
        }
    }
}
