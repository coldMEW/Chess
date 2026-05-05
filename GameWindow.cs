using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chess
{
    // Main game form. It draws the board, handles player input, updates clocks, and shows end-game controls.
    public partial class GameWindow : Form
    {
        public static string Player1Name = "Player 1";
        public static string Player2Name = "Player 2";
        public static int TimeControl = 120;

        public static bool ShowBoardSquareNumbers = false;

        public static int WhiteTimeLeft;
        public static int BlackTimeLeft;

        public static EventHandler WhiteEv = new EventHandler(WhiteTimerTick);
        public static EventHandler BlackEv = new EventHandler(BlackTimerTick);

        public static ListView MoveStack;
        public static Button NewGameButton;
        public static Button HomeButton;
        public static Label TurnDisplay = new Label();
        public static string lastMove;
        public static List<Move> currentLegalMoves = new List<Move>();
        public static GameWindow ActiveGameWindow;

        private readonly bool singlePlayerGame;

        public GameWindow(bool singlePlayer)
        {
            InitializeComponent();
            singlePlayerGame = singlePlayer;
            ActiveGameWindow = this;
            MoveStack = MoveStackDisplay;
            GameControl.SetOriginalVariables(singlePlayer);
            if (TimeControl > 0)
            {
                WhiteTimeLeft = TimeControl;
                BlackTimeLeft = TimeControl;

                if (GameControl.NoGames == 1)
                {
                    GameControl.WhiteTimer.Tick += WhiteEv;
                    GameControl.BlackTimer.Tick += BlackEv;
                }
                BlackTimeDisplay.Text = TimeSpan.FromSeconds(BlackTimeLeft).ToString(@"mm\:ss");
                WhiteTimeDisplay.Text = TimeSpan.FromSeconds(WhiteTimeLeft).ToString(@"mm\:ss");
            }

            else
            {
                GameControl.WhiteTimer.Tick -= WhiteEv;
                GameControl.BlackTimer.Tick -= BlackEv;

                BlackTimeDisplay.Text = "";
                WhiteTimeDisplay.Text = "";
            }
        }

        public void GameWindow_Load(object sender, EventArgs e)
        {
            Size = new Size(1000, 1000);
            BackColor = Color.LightGray;

            DrawBoard();
            RuleBook.FindDistanceFromEdges();
        }
        public static void UpdateMoveStackDisplay(string MoveDesc)
        {
            if(GameControl.sideToMove == 8)
            {
                ListViewItem item = new ListViewItem(MoveDesc);
                MoveStack.Items.Add(item);
            }
            else
            {
 
 
 
                MoveStack.Items[MoveStack.Items.Count - 1].Remove();
                ListViewItem item = new ListViewItem(new[] {lastMove, MoveDesc});
                MoveStack.Items.Add(item);
            }
            lastMove = MoveDesc;
        }
        public static void SetLegalMoves()
        {
            currentLegalMoves = RuleBook.GenerateLegalMoves();
 
            if (currentLegalMoves.Count == 0 && RuleBook.KingInCheck == true)
            {
                GameControl.EndGame(GameControl.OpposingSide());
            }
            if (currentLegalMoves.Count == 0 && RuleBook.KingInCheck == false)
            {
                GameControl.EndGame(0);
            }
        }
        public static void WhiteTimerTick(object sender, EventArgs e)
        {
            if (GameControl.gameEnded || GameControl.sideToMove != Piece.White)
            {
                return;
            }

            if (WhiteTimeLeft > 0)
            {
                WhiteTimeLeft -= 1;
                WhiteTimeDisplay.Text = TimeSpan.FromSeconds(WhiteTimeLeft).ToString(@"mm\:ss");
                UpdateTurnDisplay();
            }
            else
            {
                GameControl.EndGame(Piece.Black);
            }
        }
        public static void BlackTimerTick(object sender, EventArgs e)
        {
            if (GameControl.gameEnded || GameControl.sideToMove != Piece.Black)
            {
                return;
            }

            if (BlackTimeLeft > 0)
            {
                BlackTimeLeft -= 1;
                BlackTimeDisplay.Text = TimeSpan.FromSeconds(BlackTimeLeft).ToString(@"mm\:ss");
                UpdateTurnDisplay();
            }
            else
            {
                GameControl.EndGame(Piece.White);
            }
        }
        readonly GameControl GameControl = new GameControl();
        const int tileSize = 80;
        int TileNo = 0;

        public static Label WinnerDisplay = new Label();
        public static Color Brown = ColorTranslator.FromHtml("#b0722c");
        public static Color White = ColorTranslator.FromHtml("#ede4d8");

        public void DrawBoard()
        {
            // Build the visible 8x8 board and connect each square to the input handlers.
            WinnerDisplay = new Label();
            WinnerDisplay.Location = new Point(250, 400);
            WinnerDisplay.AutoSize = true;
            WinnerDisplay.ForeColor = Color.Red;
            WinnerDisplay.Font = new Font("Arial", 24);
            WinnerDisplay.Text = "Winner: ";

            Controls.Add(WinnerDisplay);
            WinnerDisplay.Hide();

            TurnDisplay = new Label();
            TurnDisplay.Location = new Point(700, 55);
            TurnDisplay.AutoSize = true;
            TurnDisplay.Font = new Font("Arial", 14, FontStyle.Bold);
            Controls.Add(TurnDisplay);

            NewGameButton = new Button();
            NewGameButton.Text = "New Game";
            NewGameButton.Size = new Size(110, 40);
            NewGameButton.Location = new Point(350, 455);
            NewGameButton.Visible = false;
            NewGameButton.Click += NewGameButton_Click;
            Controls.Add(NewGameButton);

            HomeButton = new Button();
            HomeButton.Text = "Home";
            HomeButton.Size = new Size(110, 40);
            HomeButton.Location = new Point(480, 455);
            HomeButton.Visible = false;
            HomeButton.Click += HomeButton_Click;
            Controls.Add(HomeButton);
            P1Name.Text = Player1Name;
            P2Name.Text = Player2Name;
            for (var row = 0; row < 8; row++)
            {
                for (var col = 0; col < 8; col++)
                {
                    var newSquare = new BoardSquare
                    {
                        Size = new Size(tileSize, tileSize),
                        Location = new Point((tileSize * col) + 20, (tileSize * row) + 100),
                        AllowDrop = true,
                        SizeMode = PictureBoxSizeMode.CenterImage,
                        SquareNumber = TileNo,
                    };
                    if (row % 8 == 7)
                    {
                        var boardNotationLabel = new Label {
                            Text = Convert.ToChar(col + 97).ToString(),
                            AutoSize = true, 
                            Location = new Point((tileSize * col) + 21, (tileSize * row) + 180)
                        };
                        Controls.Add(boardNotationLabel);
                    }
                    if (col % 8 == 0)
                    {
                        var boardNotationLabel = new Label
                        {
                            Text = (8-row).ToString(),
                            AutoSize = true,
                            Location = new Point((tileSize * col)+5, (tileSize * row)+100)
                        };
                        Controls.Add(boardNotationLabel);
                    }
                    if(ShowBoardSquareNumbers == true)
                    {
                        Label lbl = new Label();
                        lbl.Parent = newSquare;
                        lbl.BackColor = Color.Transparent;
                        lbl.Text = newSquare.SquareNumber.ToString();
                    }
                    Controls.Add(newSquare);
                    GameControl.Board[TileNo] = newSquare;
                    if (col % 2 == 0)
                    {
                        newSquare.BackColor = row % 2 != 0 ? Brown : White;
                    }
                    else
                    {
                        newSquare.BackColor = row % 2 != 0 ? White : Brown;
                    }
                    newSquare.MouseEnter += new EventHandler(MouseEnter);
                    newSquare.MouseLeave += new EventHandler(MouseLeave);
                    newSquare.MouseDown += new MouseEventHandler(MouseDown);
                    newSquare.MouseMove += new MouseEventHandler(MouseMove);
                    newSquare.MouseUp += new MouseEventHandler(MouseUp);

                    TileNo += 1;
                }
            }

            BoardSetup.LoadStartingBoard();

            Console.WriteLine("Finished initialising board");

            RuleBook.FindDistanceFromEdges();
            currentLegalMoves = RuleBook.GenerateLegalMoves();
            GameControl.StartStopTimers();
            UpdateTurnDisplay();
        }

        public static void ShowGameOverControls()
        {
            if (NewGameButton != null)
            {
                NewGameButton.Visible = true;
                NewGameButton.BringToFront();
            }

            if (HomeButton != null)
            {
                HomeButton.Visible = true;
                HomeButton.BringToFront();
            }

            if (TurnDisplay != null)
            {
                TurnDisplay.Text = "Game Over";
            }
        }

        public static void UpdateTurnDisplay()
        {
            // Shows whose turn it is and when the computer is thinking.
            if (TurnDisplay == null)
            {
                return;
            }

            if (GameControl.gameEnded)
            {
                TurnDisplay.Text = "Game Over";
                return;
            }

            string sideName = Piece.ColourNameFromColourBin(GameControl.sideToMove);
            int secondsLeft = GameControl.sideToMove == Piece.White ? WhiteTimeLeft : BlackTimeLeft;
            string clockText = TimeControl > 0 ? $" - {TimeSpan.FromSeconds(Math.Max(0, secondsLeft)):mm\\:ss}" : "";

            if (GameControl.SinglePlayer && GameControl.sideToMove == GameControl.computerSide)
            {
                TurnDisplay.Text = $"{sideName}'s Turn (thinking){clockText}";
            }
            else
            {
                TurnDisplay.Text = $"{sideName}'s Turn{clockText}";
            }
        }

        private static int GetComputerDelayMilliseconds()
        {
            return Computer.CurrentBot.ThinkingDelayMilliseconds;
        }

        public async void BeginComputerTurn()
        {
            if (GameControl.gameEnded || GameControl.sideToMove != GameControl.computerSide)
            {
                return;
            }

            UpdateTurnDisplay();
            await Task.Delay(GetComputerDelayMilliseconds());

            if (GameControl.gameEnded || GameControl.sideToMove != GameControl.computerSide)
            {
                return;
            }

            var watch = System.Diagnostics.Stopwatch.StartNew();
            Move computerMove = Computer.GenerateMove();
            watch.Stop();

            ApplyComputerThinkingTime(watch.ElapsedMilliseconds);

            if ((GameControl.computerSide == Piece.White && WhiteTimeLeft <= 0) ||
                (GameControl.computerSide == Piece.Black && BlackTimeLeft <= 0))
            {
                GameControl.EndGame(GameControl.computerSide == Piece.White ? Piece.Black : Piece.White);
                return;
            }

            UpdateTurnDisplay();
            GameControl.Move(computerMove);
        }

        private static void ApplyComputerThinkingTime(long elapsedMilliseconds)
        {
            if (TimeControl <= 0)
            {
                return;
            }

            int secondsUsed = (int)Math.Ceiling(elapsedMilliseconds / 1000.0);
            if (secondsUsed <= 0)
            {
                return;
            }

            if (GameControl.computerSide == Piece.White)
            {
                WhiteTimeLeft = Math.Max(0, WhiteTimeLeft - secondsUsed);
                WhiteTimeDisplay.Text = TimeSpan.FromSeconds(WhiteTimeLeft).ToString(@"mm\:ss");
            }
            else
            {
                BlackTimeLeft = Math.Max(0, BlackTimeLeft - secondsUsed);
                BlackTimeDisplay.Text = TimeSpan.FromSeconds(BlackTimeLeft).ToString(@"mm\:ss");
            }
        }

        public static void resetColours()
        {
            // Clears move highlights and restores the normal board colours.
            for (int i = 0; i < 64; i++)
            {
                if ((i / 8) % 2 == 0){GameControl.Board[i].BackColor = i % 2 == 0 ? White : Brown;}
                if ((i / 8) % 2 != 0){GameControl.Board[i].BackColor = i % 2 == 0 ? Brown : White;}
            }
            if(RuleBook.KingInCheck == true)
            {
                GameControl.Board[RuleBook.FriendlyKingSquare].BackColor = Color.Red;
            }
        }
        Cursor Pointer = Cursor.Current;
        public int copiedPiece = 0;
        public int oldLocation = 0;
        private int selectedLocation = -1;
        private int pendingDragPiece = 0;
        private int pendingDragLocation = -1;
        private Point pendingDragPoint = Point.Empty;
        private bool isDraggingPiece = false;

        private Move FindLegalMove(int from, int to)
        {
            foreach (Move move in currentLegalMoves)
            {
                if (move.MoveFrom == from && move.MoveTo == to)
                {
                    return move;
                }
            }

            return null;
        }

        private void SelectSquare(int location)
        {
            selectedLocation = location;
            resetColours();
            GameControl.Board[location].BackColor = Color.Gold;

            foreach (Move move in currentLegalMoves)
            {
                if (move.MoveFrom == location)
                {
                    GameControl.Board[move.MoveTo].BackColor = Color.Crimson;
                }
            }
        }

        private void ClearSelection()
        {
            selectedLocation = -1;
            resetColours();
        }

        private bool IsSelectablePiece(int location)
        {
            int piece = GameControl.Board[location].PieceOnSquare;
            return piece != 0 && Piece.Colour(piece) == GameControl.sideToMove;
        }

        private bool HumanCanMove()
        {
            return !GameControl.gameEnded && (!GameControl.SinglePlayer || GameControl.sideToMove != GameControl.computerSide);
        }

        private void ResetDragState()
        {
            copiedPiece = 0;
            oldLocation = 0;
            pendingDragPiece = 0;
            pendingDragLocation = -1;
            pendingDragPoint = Point.Empty;
            isDraggingPiece = false;
            Cursor = Pointer;
        }

        private bool TrySelectedMove(int location)
        {
            if (selectedLocation == -1)
            {
                return false;
            }

            Move move = FindLegalMove(selectedLocation, location);
            if (move != null)
            {
                ClearSelection();
                GameControl.Move(move);
                return true;
            }

            if (IsSelectablePiece(location))
            {
                SelectSquare(location);
                return true;
            }

            ClearSelection();
            return true;
        }

        new void MouseEnter(object sender, EventArgs e)
        {
        }
        new void MouseLeave(object sender, EventArgs e)
        {
        }
        new void MouseMove(object sender, MouseEventArgs e)
        {
            if (!HumanCanMove() || pendingDragPiece == 0 || isDraggingPiece)
            {
                return;
            }

            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            Size dragSize = SystemInformation.DragSize;
            Rectangle dragBounds = new Rectangle(
                pendingDragPoint.X - (dragSize.Width / 2),
                pendingDragPoint.Y - (dragSize.Height / 2),
                dragSize.Width,
                dragSize.Height);

            if (dragBounds.Contains(e.Location))
            {
                return;
            }

            copiedPiece = pendingDragPiece;
            oldLocation = pendingDragLocation;
            isDraggingPiece = true;

            Bitmap bmp = (Bitmap)GameControl.Board[oldLocation].Image;
            Cursor = new Cursor(bmp.GetHicon());

            GameControl.RemovePiece(copiedPiece, oldLocation);
            SelectSquare(oldLocation);
        }
        new void MouseDown(object sender, EventArgs e)
        {
            if (!HumanCanMove())
            {
                return;
            }

            BoardSquare currentPictureBox = (BoardSquare)sender;
            int location = currentPictureBox.SquareNumber;

            pendingDragLocation = location;
            pendingDragPoint = currentPictureBox.PointToClient(Control.MousePosition);
            pendingDragPiece = IsSelectablePiece(location) ? GameControl.Board[location].PieceOnSquare : 0;
            isDraggingPiece = false;
        }
        new void MouseUp(object sender, EventArgs e)
        {
            if (!HumanCanMove())
            {
                return;
            }

            BoardSquare currentPictureBox = (BoardSquare)sender;
            int location = currentPictureBox.SquareNumber;

            if (isDraggingPiece && copiedPiece != 0)
            {
                Move attemptedMove = FindLegalMove(oldLocation, location);

                if (attemptedMove != null)
                {
                    ResetDragState();
                    ClearSelection();
                    GameControl.Move(attemptedMove);
                }
                else
                {
                    GameControl.AddPiece(copiedPiece, oldLocation);

                    if (location != oldLocation)
                    {
                        ClearSelection();
                    }
                    else
                    {
                        SelectSquare(oldLocation);
                    }

                    ResetDragState();
                }
                return;
            }

            int clickedLocation = currentPictureBox.SquareNumber;
            pendingDragPiece = 0;
            pendingDragLocation = -1;
            pendingDragPoint = Point.Empty;

            if (TrySelectedMove(clickedLocation))
            {
                return;
            }

            if (IsSelectablePiece(clickedLocation))
            {
                SelectSquare(clickedLocation);
            }
            else
            {
                ClearSelection();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameControl.EndGame(GameControl.OpposingSide());
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            var gameWindow = new GameWindow(singlePlayerGame);
            gameWindow.Show();
            Close();
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            Menu existingMenu = null;

            foreach (Form form in Application.OpenForms)
            {
                if (form is Menu)
                {
                    existingMenu = (Menu)form;
                    break;
                }
            }

            if (existingMenu != null)
            {
                existingMenu.Show();
                existingMenu.WindowState = FormWindowState.Normal;
                existingMenu.BringToFront();
                existingMenu.Activate();
            }
            else
            {
                var menu = new Menu();
                menu.Show();
            }

            Close();
        }
    }
}

