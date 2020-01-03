using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        control game = new control();
        bool startIsClick = false;//所有点击事件必须是“开始游戏”键按完以后才可以触发       
        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent(); 
            CreateGridWithBoard();       
        }

        private void Button_Click_Start(object sender, RoutedEventArgs e)
        {
            startIsClick = true;
            RedrawGrid();
        }
        
        private void Button_Click_Restart(object sender, RoutedEventArgs e)
        {
            
        }

        public void CreateGridWithBoard()
        {
            
            ImageBrush b3 = new ImageBrush();
            b3.ImageSource = new BitmapImage(new Uri("C:/Users/75475/Desktop/WPFImage/Board/Board.jpg", UriKind.Relative));
            b3.Stretch = Stretch.Fill;           
            grid.Background = b3;           
            game.Board.InitializeBorad();
            for (int i = 0; i <= 8; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int j = 0; j <= 9; j++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }

            for (int row = 0; row <= 9; row++)
            {
                for (int col = 0; col <= 8; col++)
                {
                    Button button = new Button();                                   
                    button.SetValue(XQRowProperty, row);
                    button.SetValue(XQColProperty, col);
                    button.Click += Button_Click;                    
                    button.BorderBrush = Brushes.Transparent; //按钮边框透明
                    Grid.SetRow(button, row);
                    Grid.SetColumn(button, col);
                    grid.Children.Add(button);
                }
            }


        }
        
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(startIsClick == true)
            {
                int btnRow = (int)((Button)sender).GetValue(XQRowProperty);
                int btnCol = (int)((Button)sender).GetValue(XQColProperty);
                handleclick(btnRow, btnCol);
            }
            
        }

        

        public static readonly DependencyProperty XQRowProperty =
            DependencyProperty.Register("XQRow", typeof(int), typeof(Button));

        public static readonly DependencyProperty XQColProperty =
            DependencyProperty.Register("XQCol", typeof(int), typeof(Button));

        public void RedrawGrid()
        {
            int z = 0;
            foreach (chess i in game.Board.Chess)
            {
                Button btnSelected = (Button)grid.Children[z];
                btnSelected.SetValue(BackgroundProperty, null);
                btnSelected.SetValue(BackgroundProperty, Brushes.Transparent);
                if (i.Getname() == "nochess")
                {
                    
                    ImageBrush brushEmpty = new ImageBrush();
                    brushEmpty.ImageSource = new BitmapImage(new Uri(i.GetImage(), UriKind.Relative));
                    btnSelected.SetValue(BackgroundProperty, brushEmpty);

                }
                else
                {
                    
                    if (i.Getcolor() == "red")
                    {
                        ImageBrush brushRed = new ImageBrush();
                        brushRed.ImageSource = new BitmapImage(new Uri(i.GetImage(), UriKind.Relative));
                        btnSelected.Background = brushRed;
                        btnSelected.SetValue(BackgroundProperty,brushRed);
                        
                    }
                    else if (i.Getcolor() == "black")
                    {
                        ImageBrush brushBlack = new ImageBrush();
                        brushBlack.ImageSource = new BitmapImage(new Uri(i.GetImage(), UriKind.Relative));
                        btnSelected.Background = brushBlack;
                        btnSelected.SetValue(BackgroundProperty, brushBlack);
                    }
                }
                if (i.Cango == true)
                {
                    if(i.Getname() == "nochess")
                    {
                        ImageBrush brushGo = new ImageBrush();
                        brushGo.ImageSource = new BitmapImage(new Uri("C:/Users/75475/Desktop/WPFImage/Chess/OOS.gif", UriKind.Relative));
                        btnSelected.Background = brushGo;
                    }
                    else
                    {                       
                        ImageBrush brushEat = new ImageBrush();
                        brushEat.ImageSource = new BitmapImage(new Uri(i.GetImageEat(), UriKind.Relative));
                        btnSelected.Background = brushEat;
                    }                   
                }
                z++;
            }

        }       

        public void handleclick(int row, int col)
        {
            try
            {
                switch (game.state)
                {
                    case true:
                        game.Playchoose(row, col);
                        game.Board.Wherecanchessgo(col, row);
                        ChangeState();
                        break;

                    case false:
                        game.Movechess(row, col);
                        game.RefreshCanGo(row, col);
                        ChangeState();
                        break;

                }
            }
            catch (MyException ex)
            {
                MessageBox.Show(ex.Message);
                changeState();
                game.RefreshCanGo(row, col);
            }
            RedrawGrid();
        }

        public void ChangeState()
        {
            switch (game.state)
            {
                case false:
                    
                    game.state = true;
                    break;

                case true:
                    
                    game.state = false;
                    break;
            }


        }

        public void changeState()
        {
            game.state = true;            
        }        
    }
}
