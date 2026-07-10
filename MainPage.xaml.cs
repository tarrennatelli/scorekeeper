namespace Score_Keeper
{
    public partial class MainPage : ContentPage
    {
        private const string CurrentVersion = "1.0";
        private const string VersionUrl = "https://raw.githubusercontent.com/tarrennatelli/scorekeeper/master/version.txt";
        private const string DownloadUrl = "https://github.com/tarrennatelli/scorekeeper/actions";
        public MainPage()
        {
            InitializeComponent();
            Dispatcher.Dispatch(async () => await CheckForUpdatesAsync());
            playerThree.IsVisible = false;
            playerThreeScore.IsVisible = false;
            entryOneThree.IsVisible = false;
            entryTwoThree.IsVisible = false;
            entryThreeThree.IsVisible = false;
            entryFourThree.IsVisible = false;
            entryFiveThree.IsVisible = false;
            entrySixThree.IsVisible = false;
            entrySevenThree.IsVisible = false;
            entryEightThree.IsVisible = false;
            entryNineThree.IsVisible = false;
            entryTenThree.IsVisible = false;
            entryElevenThree.IsVisible = false;
            entryTwelveThree.IsVisible = false;
            entryThirteenThree.IsVisible = false;
            entryFourteenThree.IsVisible = false;
            entryFifteenThree.IsVisible = false;

            playerFour.IsVisible = false;
            playerFourScore.IsVisible = false;
            entryOneFour.IsVisible = false;
            entryTwoFour.IsVisible = false;
            entryThreeFour.IsVisible = false;
            entryFourFour.IsVisible = false;
            entryFiveFour.IsVisible = false;
            entrySixFour.IsVisible = false;
            entrySevenFour.IsVisible = false;
            entryEightFour.IsVisible = false;
            entryNineFour.IsVisible = false;
            entryTenFour.IsVisible = false;
            entryElevenFour.IsVisible = false;
            entryTwelveFour.IsVisible = false;
            entryThirteenFour.IsVisible = false;
            entryFourteenFour.IsVisible = false;
            entryFifteenFour.IsVisible = false;

            playerFive.IsVisible = false;
            playerFiveScore.IsVisible = false;
            entryOneFive.IsVisible = false;
            entryTwoFive.IsVisible = false;
            entryThreeFive.IsVisible = false;
            entryFourFive.IsVisible = false;
            entryFiveFive.IsVisible = false;
            entrySixFive.IsVisible = false;
            entrySevenFive.IsVisible = false;
            entryEightFive.IsVisible = false;
            entryNineFive.IsVisible = false;
            entryTenFive.IsVisible = false;
            entryElevenFive.IsVisible = false;
            entryTwelveFive.IsVisible = false;
            entryThirteenFive.IsVisible = false;
            entryFourteenFive.IsVisible = false;
            entryFifteenFive.IsVisible = false;

            // Get the app's data directory
            var screenBigfilePath = Path.Combine(FileSystem.AppDataDirectory, "screenBig.txt");
            var firstTimeFilePath = Path.Combine(FileSystem.AppDataDirectory, "firstTime.txt");
            // Check if the file exists
            if (File.Exists(screenBigfilePath))
            {
                if (File.ReadAllText(screenBigfilePath) == "true")
                {
                    screenBig = true;
                }
                else if (File.ReadAllText(screenBigfilePath) == "false")
                {
                    screenBig = false;
                    entryFifteenOne.IsVisible = false;
                    entryFifteenTwo.IsVisible = false;
                    entryFourteenOne.IsVisible = false;
                    entryFourteenTwo.IsVisible = false;
                    entryThirteenOne.IsVisible = false;
                    entryThirteenTwo.IsVisible = false;
                }
            }
            else
            {

                File.WriteAllText(Path.Combine(FileSystem.AppDataDirectory, "screenBig.txt"), "false");
                screenBig = false;
                entryFifteenOne.IsVisible = false;
                entryFifteenTwo.IsVisible = false;
                entryFourteenOne.IsVisible = false;
                entryFourteenTwo.IsVisible = false;
                entryThirteenOne.IsVisible = false;
                entryThirteenTwo.IsVisible = false;
            }
            if (File.Exists(firstTimeFilePath))
            {
                if (File.ReadAllText(firstTimeFilePath) == "true")
                {
                    firstTime.IsVisible = true;
                    mainGrid.IsVisible = false;
                    File.WriteAllText(Path.Combine(FileSystem.AppDataDirectory, "firstTime.txt"), "false");
                }
            }
            else
            {
                firstTime.IsVisible = true;
                mainGrid.IsVisible = false;
                File.WriteAllText(Path.Combine(FileSystem.AppDataDirectory, "firstTime.txt"), "false");
            }

        }
        private async Task CheckForUpdatesAsync()
        {
            try
            {
                using HttpClient client = new HttpClient();
                // Fetch the text from your GitHub version.txt file
                string latestVersion = (await client.GetStringAsync(VersionUrl)).Trim();

                // 2. If the cloud version doesn't match your local version, trigger the alert
                if (latestVersion != CurrentVersion)
                {
                    bool downloadNow = await DisplayAlert(
                        "Update Available!",
                        $"A newer version ({latestVersion}) of Score Keeper is available. Would you like to update now?",
                        "Update",
                        "Later"
                    );

                    // 3. If they tap "Update", launch the browser automatically
                    if (downloadNow)
                    {
                        await Launcher.Default.OpenAsync(new Uri(DownloadUrl));
                    }
                }
            }
            catch
            {
                // Fails silently if they don't have an internet connection
            }
        }

        private void confirmClicked(object sender, EventArgs e)
        {
            if (!optionToggle.IsToggled)
            {
                screenBig = false;
                entryFifteenOne.IsVisible = false;
                entryFifteenTwo.IsVisible = false;
                entryFourteenOne.IsVisible = false;
                entryFourteenTwo.IsVisible = false;
                entryThirteenOne.IsVisible = false;
                entryThirteenTwo.IsVisible = false;
                if (!screenBig)
                {
                    File.WriteAllText(Path.Combine(FileSystem.AppDataDirectory, "screenBig.txt"), "false");
                    screenBig = false;
                }
                else
                {
                    File.WriteAllText(Path.Combine(FileSystem.AppDataDirectory, "screenBig.txt"), "true");
                    screenBig = true;
                }
            }
            else
            {
                screenBig = true;
                entryFifteenOne.IsVisible = true;
                entryFifteenTwo.IsVisible = true;
                entryFourteenOne.IsVisible = true;
                entryFourteenTwo.IsVisible = true;
                entryThirteenOne.IsVisible = true;
                entryThirteenTwo.IsVisible = true;
                if (!screenBig)
                {
                    File.WriteAllText(Path.Combine(FileSystem.AppDataDirectory, "screenBig.txt"), "false");
                    screenBig = false;
                }
                else
                {
                    File.WriteAllText(Path.Combine(FileSystem.AppDataDirectory, "screenBig.txt"), "true");
                    screenBig = true;
                }
            }
            firstTime.IsVisible = false;
            mainGrid.IsVisible = true;
        }

        private void OnCheckmarkClicked(object sender, EventArgs e)
        {
            // Cast sender to Entry
            var currentEntry = sender as Entry;
            if (currentEntry != null && currentEntry.Parent is Grid grid)
            {
                if (currentEntry == entryFifteenFive || currentEntry == entryTwoSixFive)
                {
                    shiftUp();
                }
                if (currentEntry == entryTwelveFive && !screenBig)
                {
                    shiftUp();
                }
                if (playerSix.IsVisible == true)
                {
                    if (currentEntry == entryOneFive)
                    {
                        entryTwoOneOne.Focus();
                    }
                    else if (currentEntry == entryTwoFive)
                    {
                        entryTwoTwoOne.Focus();
                    }
                    else if (currentEntry == entryThreeFive)
                    {
                        entryTwoThreeOne.Focus();
                    }
                    else if (currentEntry == entryFourFive)
                    {
                        entryTwoFourOne.Focus();
                    }
                    else if (currentEntry == entryFiveFive)
                    {
                        entryTwoFiveOne.Focus();
                    }
                    else if (currentEntry == entrySixFive)
                    {
                        entryTwoSixOne.Focus();
                    }
                    
                }
                // Get current entry's row and column
                int currentRow = Grid.GetRow(currentEntry);
                int currentColumn = Grid.GetColumn(currentEntry);

                // Find the next entry in the same row
                for (int nextColumn = currentColumn + 1; nextColumn < grid.ColumnDefinitions.Count; nextColumn++)
                {
                    // Search for the next entry
                    var nextEntry = grid.Children
                        .OfType<Entry>()
                        .FirstOrDefault(e => Grid.GetRow(e) == currentRow && Grid.GetColumn(e) == nextColumn);

                    // If a visible entry is found, set focus

                    if (currentEntry == entryFifteenFour && entryFifteenFive.IsVisible == false)
                    {
                        shiftUp();
                    }
                    else if (currentEntry == entryFifteenThree && entryFifteenFour.IsVisible == false)
                    {
                        shiftUp();
                    }
                    else if (currentEntry == entryFifteenTwo && entryFifteenThree.IsVisible == false)
                    {
                        shiftUp();
                    }
                    else if (currentEntry == entryFifteenOne && entryFifteenTwo.IsVisible == false)
                    {
                        shiftUp();
                    }
                    else if (!screenBig)
                    {

                        if (currentEntry == entryTwelveFour && entryTwelveFive.IsVisible == false)
                        {
                            shiftUp();
                        }
                        else if (currentEntry == entryTwelveThree && entryTwelveFour.IsVisible == false)
                        {
                            shiftUp();
                        }
                        else if (currentEntry == entryTwelveTwo && entryTwelveThree.IsVisible == false)
                        {
                            shiftUp();
                        }
                        else if (currentEntry == entryTwelveOne && entryTwelveTwo.IsVisible == false)
                        {
                            shiftUp();
                        }
                    }
                    if (currentEntry == entryTwoSixOne && entryTwoSixTwo.IsVisible == false)
                    {
                        shiftUp();
                    }
                    else if (currentEntry == entryTwoSixTwo && entryTwoSixThree.IsVisible == false)
                    {
                        shiftUp();
                    }
                    else if (currentEntry == entryTwoSixThree && entryTwoSixFour.IsVisible == false)
                    {
                        shiftUp();
                    }
                    else if (currentEntry == entryTwoSixFour && entryTwoSixFive.IsVisible == false)
                    {
                        shiftUp();
                    }
                    if (nextEntry != null && nextEntry.IsVisible)
                    {
                        nextEntry.Focus();
                        return;
                    }

                }
            }
        }

        private void shiftUp()
        {
            if (playerOneScore.Text == "0" && playerTwoScore.Text == "0" && playerThreeScore.Text == "0" && playerFourScore.Text == "0" && playerFiveScore.Text == "0" && playerSixScore.Text == "0" && playerSevenScore.Text == "0" && playerEightScore.Text == "0" && playerNineScore.Text == "0" && playerTenScore.Text == "0")
            {
                foreach (var child in secondaryEntryGrid.Children)
                {
                    if (child is Entry entry)
                    {
                        if (entry != playerSix && entry != playerSeven && entry != playerEight && entry != playerNine && entry != playerTen)
                        {
                            entry.Text = string.Empty;
                        }
                    }
                }
                foreach (var child in entryGrid.Children)
                {
                    if (child is Entry entry)
                    {
                        if (entry != playerOne && entry != playerTwo && entry != playerThree && entry != playerFour && entry != playerFive)
                        {
                            entry.Text = string.Empty;
                        }
                    }
                }
            }
            else
            {
                int currentPlayerOneScore = int.Parse(playerOneScore.Text);
                int currentPlayerTwoScore = int.Parse(playerTwoScore.Text);
                int currentPlayerThreeScore = int.Parse(playerThreeScore.Text);
                int currentPlayerFourScore = int.Parse(playerFourScore.Text);
                int currentPlayerFiveScore = int.Parse(playerFiveScore.Text);
                foreach (var child in entryGrid.Children)
                {
                    if (child is Entry entry)
                    {
                        if (entry != playerOne && entry != playerTwo && entry != playerThree && entry != playerFour && entry != playerFive)
                        {
                            entry.Text = string.Empty;
                        }
                    }
                }
                entryOneOne.Text = currentPlayerOneScore.ToString();
                entryOneTwo.Text = currentPlayerTwoScore.ToString();
                entryOneThree.Text = currentPlayerThreeScore.ToString();
                entryOneFour.Text = currentPlayerFourScore.ToString();
                entryOneFive.Text = currentPlayerFiveScore.ToString();

                int currentPlayerSixScore = int.Parse(playerSixScore.Text);
                int currentPlayerSevenScore = int.Parse(playerSevenScore.Text);
                int currentPlayerEightScore = int.Parse(playerEightScore.Text);
                int currentPlayerNineScore = int.Parse(playerNineScore.Text);
                int currentPlayerTenScore = int.Parse(playerTenScore.Text);
                foreach (var child in secondaryEntryGrid.Children)
                {
                    if (child is Entry entry)
                    {
                        if (entry != playerSix && entry != playerSeven && entry != playerEight && entry != playerNine && entry != playerTen)
                        {
                            entry.Text = string.Empty;
                        }
                    }
                }
                entryTwoOneOne.Text = currentPlayerSixScore.ToString();
                entryTwoOneTwo.Text = currentPlayerSevenScore.ToString();
                entryTwoOneThree.Text = currentPlayerEightScore.ToString();
                entryTwoOneFour.Text = currentPlayerNineScore.ToString();
                entryTwoOneFive.Text = currentPlayerTenScore.ToString();
            }
        }

        private void addValues(object sender, TextChangedEventArgs e)
        {
            // Safely parse and sum up the values for Column One
            try
            {
                int columnOne = (string.IsNullOrEmpty(entryOneOne.Text) ? 0 : int.Parse(entryOneOne.Text)) +
                                (string.IsNullOrEmpty(entryTwoOne.Text) ? 0 : int.Parse(entryTwoOne.Text)) +
                                (string.IsNullOrEmpty(entryThreeOne.Text) ? 0 : int.Parse(entryThreeOne.Text)) +
                                (string.IsNullOrEmpty(entryFourOne.Text) ? 0 : int.Parse(entryFourOne.Text)) +
                                (string.IsNullOrEmpty(entryFiveOne.Text) ? 0 : int.Parse(entryFiveOne.Text)) +
                                (string.IsNullOrEmpty(entrySixOne.Text) ? 0 : int.Parse(entrySixOne.Text)) +
                                (string.IsNullOrEmpty(entrySevenOne.Text) ? 0 : int.Parse(entrySevenOne.Text)) +
                                (string.IsNullOrEmpty(entryEightOne.Text) ? 0 : int.Parse(entryEightOne.Text)) +
                                (string.IsNullOrEmpty(entryNineOne.Text) ? 0 : int.Parse(entryNineOne.Text)) +
                                (string.IsNullOrEmpty(entryTenOne.Text) ? 0 : int.Parse(entryTenOne.Text)) +
                                (string.IsNullOrEmpty(entryElevenOne.Text) ? 0 : int.Parse(entryElevenOne.Text)) +
                                (string.IsNullOrEmpty(entryTwelveOne.Text) ? 0 : int.Parse(entryTwelveOne.Text)) +
                                (string.IsNullOrEmpty(entryThirteenOne.Text) ? 0 : int.Parse(entryThirteenOne.Text)) +
                                (string.IsNullOrEmpty(entryFourteenOne.Text) ? 0 : int.Parse(entryFourteenOne.Text)) +
                                (string.IsNullOrEmpty(entryFifteenOne.Text) ? 0 : int.Parse(entryFifteenOne.Text));

                // Similarly for Column Two
                int columnTwo = (string.IsNullOrEmpty(entryOneTwo.Text) ? 0 : int.Parse(entryOneTwo.Text)) +
                                (string.IsNullOrEmpty(entryTwoTwo.Text) ? 0 : int.Parse(entryTwoTwo.Text)) +
                                (string.IsNullOrEmpty(entryThreeTwo.Text) ? 0 : int.Parse(entryThreeTwo.Text)) +
                                (string.IsNullOrEmpty(entryFourTwo.Text) ? 0 : int.Parse(entryFourTwo.Text)) +
                                (string.IsNullOrEmpty(entryFiveTwo.Text) ? 0 : int.Parse(entryFiveTwo.Text)) +
                                (string.IsNullOrEmpty(entrySixTwo.Text) ? 0 : int.Parse(entrySixTwo.Text)) +
                                (string.IsNullOrEmpty(entrySevenTwo.Text) ? 0 : int.Parse(entrySevenTwo.Text)) +
                                (string.IsNullOrEmpty(entryEightTwo.Text) ? 0 : int.Parse(entryEightTwo.Text)) +
                                (string.IsNullOrEmpty(entryNineTwo.Text) ? 0 : int.Parse(entryNineTwo.Text)) +
                                (string.IsNullOrEmpty(entryTenTwo.Text) ? 0 : int.Parse(entryTenTwo.Text)) +
                                (string.IsNullOrEmpty(entryElevenTwo.Text) ? 0 : int.Parse(entryElevenTwo.Text)) +
                                (string.IsNullOrEmpty(entryTwelveTwo.Text) ? 0 : int.Parse(entryTwelveTwo.Text)) +
                                (string.IsNullOrEmpty(entryThirteenTwo.Text) ? 0 : int.Parse(entryThirteenTwo.Text)) +
                                (string.IsNullOrEmpty(entryFourteenTwo.Text) ? 0 : int.Parse(entryFourteenTwo.Text)) +
                                (string.IsNullOrEmpty(entryFifteenTwo.Text) ? 0 : int.Parse(entryFifteenTwo.Text));

                // Similarly for Column Three
                int columnThree = (string.IsNullOrEmpty(entryOneThree.Text) ? 0 : int.Parse(entryOneThree.Text)) +
                                  (string.IsNullOrEmpty(entryTwoThree.Text) ? 0 : int.Parse(entryTwoThree.Text)) +
                                  (string.IsNullOrEmpty(entryThreeThree.Text) ? 0 : int.Parse(entryThreeThree.Text)) +
                                  (string.IsNullOrEmpty(entryFourThree.Text) ? 0 : int.Parse(entryFourThree.Text)) +
                                  (string.IsNullOrEmpty(entryFiveThree.Text) ? 0 : int.Parse(entryFiveThree.Text)) +
                                  (string.IsNullOrEmpty(entrySixThree.Text) ? 0 : int.Parse(entrySixThree.Text)) +
                                  (string.IsNullOrEmpty(entrySevenThree.Text) ? 0 : int.Parse(entrySevenThree.Text)) +
                                  (string.IsNullOrEmpty(entryEightThree.Text) ? 0 : int.Parse(entryEightThree.Text)) +
                                  (string.IsNullOrEmpty(entryNineThree.Text) ? 0 : int.Parse(entryNineThree.Text)) +
                                  (string.IsNullOrEmpty(entryTenThree.Text) ? 0 : int.Parse(entryTenThree.Text)) +
                                  (string.IsNullOrEmpty(entryElevenThree.Text) ? 0 : int.Parse(entryElevenThree.Text)) +
                                  (string.IsNullOrEmpty(entryTwelveThree.Text) ? 0 : int.Parse(entryTwelveThree.Text)) +
                                  (string.IsNullOrEmpty(entryThirteenThree.Text) ? 0 : int.Parse(entryThirteenThree.Text)) +
                                  (string.IsNullOrEmpty(entryFourteenThree.Text) ? 0 : int.Parse(entryFourteenThree.Text)) +
                                  (string.IsNullOrEmpty(entryFifteenThree.Text) ? 0 : int.Parse(entryFifteenThree.Text));

                // Similarly for Column Four and Column Five
                int columnFour = (string.IsNullOrEmpty(entryOneFour.Text) ? 0 : int.Parse(entryOneFour.Text)) +
                                 (string.IsNullOrEmpty(entryTwoFour.Text) ? 0 : int.Parse(entryTwoFour.Text)) +
                                 (string.IsNullOrEmpty(entryThreeFour.Text) ? 0 : int.Parse(entryThreeFour.Text)) +
                                 (string.IsNullOrEmpty(entryFourFour.Text) ? 0 : int.Parse(entryFourFour.Text)) +
                                 (string.IsNullOrEmpty(entryFiveFour.Text) ? 0 : int.Parse(entryFiveFour.Text)) +
                                 (string.IsNullOrEmpty(entrySixFour.Text) ? 0 : int.Parse(entrySixFour.Text)) +
                                 (string.IsNullOrEmpty(entrySevenFour.Text) ? 0 : int.Parse(entrySevenFour.Text)) +
                                 (string.IsNullOrEmpty(entryEightFour.Text) ? 0 : int.Parse(entryEightFour.Text)) +
                                 (string.IsNullOrEmpty(entryNineFour.Text) ? 0 : int.Parse(entryNineFour.Text)) +
                                 (string.IsNullOrEmpty(entryTenFour.Text) ? 0 : int.Parse(entryTenFour.Text)) +
                                 (string.IsNullOrEmpty(entryElevenFour.Text) ? 0 : int.Parse(entryElevenFour.Text)) +
                                 (string.IsNullOrEmpty(entryTwelveFour.Text) ? 0 : int.Parse(entryTwelveFour.Text)) +
                                 (string.IsNullOrEmpty(entryThirteenFour.Text) ? 0 : int.Parse(entryThirteenFour.Text)) +
                                 (string.IsNullOrEmpty(entryFourteenFour.Text) ? 0 : int.Parse(entryFourteenFour.Text)) +
                                 (string.IsNullOrEmpty(entryFifteenFour.Text) ? 0 : int.Parse(entryFifteenFour.Text));

                int columnFive = (string.IsNullOrEmpty(entryOneFive.Text) ? 0 : int.Parse(entryOneFive.Text)) +
                                 (string.IsNullOrEmpty(entryTwoFive.Text) ? 0 : int.Parse(entryTwoFive.Text)) +
                                 (string.IsNullOrEmpty(entryThreeFive.Text) ? 0 : int.Parse(entryThreeFive.Text)) +
                                 (string.IsNullOrEmpty(entryFourFive.Text) ? 0 : int.Parse(entryFourFive.Text)) +
                                 (string.IsNullOrEmpty(entryFiveFive.Text) ? 0 : int.Parse(entryFiveFive.Text)) +
                                 (string.IsNullOrEmpty(entrySixFive.Text) ? 0 : int.Parse(entrySixFive.Text)) +
                                 (string.IsNullOrEmpty(entrySevenFive.Text) ? 0 : int.Parse(entrySevenFive.Text)) +
                                 (string.IsNullOrEmpty(entryEightFive.Text) ? 0 : int.Parse(entryEightFive.Text)) +
                                 (string.IsNullOrEmpty(entryNineFive.Text) ? 0 : int.Parse(entryNineFive.Text)) +
                                 (string.IsNullOrEmpty(entryTenFive.Text) ? 0 : int.Parse(entryTenFive.Text)) +
                                 (string.IsNullOrEmpty(entryElevenFive.Text) ? 0 : int.Parse(entryElevenFive.Text)) +
                                 (string.IsNullOrEmpty(entryTwelveFive.Text) ? 0 : int.Parse(entryTwelveFive.Text)) +
                                 (string.IsNullOrEmpty(entryThirteenFive.Text) ? 0 : int.Parse(entryThirteenFive.Text)) +
                                 (string.IsNullOrEmpty(entryFourteenFive.Text) ? 0 : int.Parse(entryFourteenFive.Text)) +
                                 (string.IsNullOrEmpty(entryFifteenFive.Text) ? 0 : int.Parse(entryFifteenFive.Text));

                int columnSix = (string.IsNullOrEmpty(entryTwoOneOne.Text) ? 0 : int.Parse(entryTwoOneOne.Text)) + (string.IsNullOrEmpty(entryTwoTwoOne.Text) ? 0 : int.Parse(entryTwoTwoOne.Text)) + (string.IsNullOrEmpty(entryTwoThreeOne.Text) ? 0 : int.Parse(entryTwoThreeOne.Text)) + (string.IsNullOrEmpty(entryTwoFourOne.Text) ? 0 : int.Parse(entryTwoFourOne.Text)) + (string.IsNullOrEmpty(entryTwoFiveOne.Text) ? 0 : int.Parse(entryTwoFiveOne.Text)) + (string.IsNullOrEmpty(entryTwoSixOne.Text) ? 0 : int.Parse(entryTwoSixOne.Text));
                int columnSeven = (string.IsNullOrEmpty(entryTwoOneTwo.Text) ? 0 : int.Parse(entryTwoOneTwo.Text)) + (string.IsNullOrEmpty(entryTwoTwoTwo.Text) ? 0 : int.Parse(entryTwoTwoTwo.Text)) + (string.IsNullOrEmpty(entryTwoThreeTwo.Text) ? 0 : int.Parse(entryTwoThreeTwo.Text)) + (string.IsNullOrEmpty(entryTwoFourTwo.Text) ? 0 : int.Parse(entryTwoFourTwo.Text)) + (string.IsNullOrEmpty(entryTwoFiveTwo.Text) ? 0 : int.Parse(entryTwoFiveTwo.Text)) + (string.IsNullOrEmpty(entryTwoSixTwo.Text) ? 0 : int.Parse(entryTwoSixTwo.Text));
                int columnEight = (string.IsNullOrEmpty(entryTwoOneThree.Text) ? 0 : int.Parse(entryTwoOneThree.Text)) + (string.IsNullOrEmpty(entryTwoTwoThree.Text) ? 0 : int.Parse(entryTwoTwoThree.Text)) + (string.IsNullOrEmpty(entryTwoThreeThree.Text) ? 0 : int.Parse(entryTwoThreeThree.Text)) + (string.IsNullOrEmpty(entryTwoFourThree.Text) ? 0 : int.Parse(entryTwoFourThree.Text)) + (string.IsNullOrEmpty(entryTwoFiveThree.Text) ? 0 : int.Parse(entryTwoFiveThree.Text)) + (string.IsNullOrEmpty(entryTwoSixThree.Text) ? 0 : int.Parse(entryTwoSixThree.Text));
                int columnNine = (string.IsNullOrEmpty(entryTwoOneFour.Text) ? 0 : int.Parse(entryTwoOneFour.Text)) + (string.IsNullOrEmpty(entryTwoTwoFour.Text) ? 0 : int.Parse(entryTwoTwoFour.Text)) + (string.IsNullOrEmpty(entryTwoThreeFour.Text) ? 0 : int.Parse(entryTwoThreeFour.Text)) + (string.IsNullOrEmpty(entryTwoFourFour.Text) ? 0 : int.Parse(entryTwoFourFour.Text)) + (string.IsNullOrEmpty(entryTwoFiveFour.Text) ? 0 : int.Parse(entryTwoFiveFour.Text)) + (string.IsNullOrEmpty(entryTwoSixFour.Text) ? 0 : int.Parse(entryTwoSixFour.Text));
                int columnTen = (string.IsNullOrEmpty(entryTwoOneFive.Text) ? 0 : int.Parse(entryTwoOneFive.Text)) + (string.IsNullOrEmpty(entryTwoTwoFive.Text) ? 0 : int.Parse(entryTwoTwoFive.Text)) + (string.IsNullOrEmpty(entryTwoThreeFive.Text) ? 0 : int.Parse(entryTwoThreeFive.Text)) + (string.IsNullOrEmpty(entryTwoFourFive.Text) ? 0 : int.Parse(entryTwoFourFive.Text)) + (string.IsNullOrEmpty(entryTwoFiveFive.Text) ? 0 : int.Parse(entryTwoFiveFive.Text)) + (string.IsNullOrEmpty(entryTwoSixFive.Text) ? 0 : int.Parse(entryTwoSixFive.Text));
                playerOneScore.Text = columnOne.ToString();
                playerTwoScore.Text = columnTwo.ToString();
                playerThreeScore.Text = columnThree.ToString();
                playerFourScore.Text = columnFour.ToString();
                playerFiveScore.Text = columnFive.ToString();
                playerSixScore.Text = columnSix.ToString();
                playerSevenScore.Text = columnSeven.ToString();
                playerEightScore.Text = columnEight.ToString();
                playerNineScore.Text = columnNine.ToString();
                playerTenScore.Text = columnTen.ToString();
            }
            catch (Exception)
            {
                playerOneScore.Text = "ERROR";
                playerTwoScore.Text = "ERROR";
                playerThreeScore.Text = "ERROR";
                playerFourScore.Text = "ERROR";
                playerFiveScore.Text = "ERROR";
                playerSixScore.Text = "ERROR";
                playerSevenScore.Text = "ERROR";
                playerEightScore.Text = "ERROR";
                playerNineScore.Text = "ERROR";
                playerTenScore.Text = "ERROR";
            }

            // Update the label values



        }

        private void addPlayerOne(object sender, EventArgs e)
        {
            if (buttonOne.Text == "-")
            {
                buttonOne.Text = "+";
                buttonTwo.IsVisible = false;
                playerOne.IsVisible = false;
                playerOneScore.IsVisible = false;
                entryOneOne.IsVisible = false;
                entryTwoOne.IsVisible = false;
                entryThreeOne.IsVisible = false;
                entryFourOne.IsVisible = false;
                entryFiveOne.IsVisible = false;
                entrySixOne.IsVisible = false;
                entrySevenOne.IsVisible = false;
                entryEightOne.IsVisible = false;
                entryNineOne.IsVisible = false;
                entryTenOne.IsVisible = false;
                entryElevenOne.IsVisible = false;
                entryTwelveOne.IsVisible = false;
                if (screenBig)
                {
                    entryThirteenOne.IsVisible = false;
                    entryFourteenOne.IsVisible = false;
                    entryFifteenOne.IsVisible = false;
                }
            }
            else if (buttonOne.Text == "+")
            {
                buttonOne.Text = "-";
                buttonTwo.IsVisible = true;
                playerOne.IsVisible = true;
                playerOneScore.IsVisible = true;
                entryOneOne.IsVisible = true;
                entryTwoOne.IsVisible = true;
                entryThreeOne.IsVisible = true;
                entryFourOne.IsVisible = true;
                entryFiveOne.IsVisible = true;
                entrySixOne.IsVisible = true;
                entrySevenOne.IsVisible = true;
                entryEightOne.IsVisible = true;
                entryNineOne.IsVisible = true;
                entryTenOne.IsVisible = true;
                entryElevenOne.IsVisible = true;
                entryTwelveOne.IsVisible = true;
                if (screenBig)
                {
                    entryThirteenOne.IsVisible = true;
                    entryFourteenOne.IsVisible = true;
                    entryFifteenOne.IsVisible = true;
                }
            }
        }


        private void addPlayerTwo(object sender, EventArgs e)
        {
            if (buttonTwo.Text == "-")
            {
                buttonOne.IsEnabled = true;
                buttonTwo.Text = "+";
                buttonThree.IsVisible = false;
                playerTwo.IsVisible = false;
                playerTwoScore.IsVisible = false;
                entryOneTwo.IsVisible = false;
                entryTwoTwo.IsVisible = false;
                entryThreeTwo.IsVisible = false;
                entryFourTwo.IsVisible = false;
                entryFiveTwo.IsVisible = false;
                entrySixTwo.IsVisible = false;
                entrySevenTwo.IsVisible = false;
                entryEightTwo.IsVisible = false;
                entryNineTwo.IsVisible = false;
                entryTenTwo.IsVisible = false;
                entryElevenTwo.IsVisible = false;
                entryTwelveTwo.IsVisible = false;
                if (screenBig)
                {
                    entryThirteenTwo.IsVisible = false;
                    entryFourteenTwo.IsVisible = false;
                    entryFifteenTwo.IsVisible = false;
                }
            }
            else if (buttonTwo.Text == "+")
            {
                buttonOne.IsEnabled = false;
                buttonTwo.Text = "-";
                buttonThree.IsVisible = true;
                playerTwo.IsVisible = true;
                playerTwoScore.IsVisible = true;
                entryOneTwo.IsVisible = true;
                entryTwoTwo.IsVisible = true;
                entryThreeTwo.IsVisible = true;
                entryFourTwo.IsVisible = true;
                entryFiveTwo.IsVisible = true;
                entrySixTwo.IsVisible = true;
                entrySevenTwo.IsVisible = true;
                entryEightTwo.IsVisible = true;
                entryNineTwo.IsVisible = true;
                entryTenTwo.IsVisible = true;
                entryElevenTwo.IsVisible = true;
                entryTwelveTwo.IsVisible = true;
                if (screenBig)
                {
                    entryThirteenTwo.IsVisible = true;
                    entryFourteenTwo.IsVisible = true;
                    entryFifteenTwo.IsVisible = true;
                }
            }
        }


        private void addPlayerThree(object sender, EventArgs e)
        {
            if (buttonThree.Text == "-")
            {
                buttonTwo.IsEnabled = true;
                buttonThree.Text = "+";
                buttonFour.IsVisible = false;
                playerThree.IsVisible = false;
                playerThreeScore.IsVisible = false;
                entryOneThree.IsVisible = false;
                entryTwoThree.IsVisible = false;
                entryThreeThree.IsVisible = false;
                entryFourThree.IsVisible = false;
                entryFiveThree.IsVisible = false;
                entrySixThree.IsVisible = false;
                entrySevenThree.IsVisible = false;
                entryEightThree.IsVisible = false;
                entryNineThree.IsVisible = false;
                entryTenThree.IsVisible = false;
                entryElevenThree.IsVisible = false;
                entryTwelveThree.IsVisible = false;
                if (screenBig)
                {
                    entryThirteenThree.IsVisible = false;
                    entryFourteenThree.IsVisible = false;
                    entryFifteenThree.IsVisible = false;
                }
            }
            else if (buttonThree.Text == "+")
            {
                buttonTwo.IsEnabled = false;
                buttonThree.Text = "-";
                playerThree.IsVisible = true;
                buttonFour.IsVisible = true;
                playerThreeScore.IsVisible = true;
                entryOneThree.IsVisible = true;
                entryTwoThree.IsVisible = true;
                entryThreeThree.IsVisible = true;
                entryFourThree.IsVisible = true;
                entryFiveThree.IsVisible = true;
                entrySixThree.IsVisible = true;
                entrySevenThree.IsVisible = true;
                entryEightThree.IsVisible = true;
                entryNineThree.IsVisible = true;
                entryTenThree.IsVisible = true;
                entryElevenThree.IsVisible = true;
                entryTwelveThree.IsVisible = true;
                if (screenBig)
                {
                    entryThirteenThree.IsVisible = true;
                    entryFourteenThree.IsVisible = true;
                    entryFifteenThree.IsVisible = true;
                }
            }
        }

        private void addPlayerFour(object sender, EventArgs e)
        {
            if (buttonFour.Text == "-")
            {
                buttonThree.IsEnabled = true;
                buttonFour.Text = "+";
                playerFour.IsVisible = true;
                buttonFive.IsVisible = false;
                playerFour.IsVisible = false;
                playerFourScore.IsVisible = false;
                entryOneFour.IsVisible = false;
                entryTwoFour.IsVisible = false;
                entryThreeFour.IsVisible = false;
                entryFourFour.IsVisible = false;
                entryFiveFour.IsVisible = false;
                entrySixFour.IsVisible = false;
                entrySevenFour.IsVisible = false;
                entryEightFour.IsVisible = false;
                entryNineFour.IsVisible = false;
                entryTenFour.IsVisible = false;
                entryElevenFour.IsVisible = false;
                entryTwelveFour.IsVisible = false;
                if (screenBig)
                {
                    entryThirteenFour.IsVisible = false;
                    entryFourteenFour.IsVisible = false;
                    entryFifteenFour.IsVisible = false;
                }
            }
            else if (buttonFour.Text == "+")
            {
                buttonThree.IsEnabled = false;
                buttonFour.Text = "-";
                buttonFive.IsVisible = true;
                playerFour.IsVisible = true;
                playerFourScore.IsVisible = true;
                entryOneFour.IsVisible = true;
                entryTwoFour.IsVisible = true;
                entryThreeFour.IsVisible = true;
                entryFourFour.IsVisible = true;
                entryFiveFour.IsVisible = true;
                entrySixFour.IsVisible = true;
                entrySevenFour.IsVisible = true;
                entryEightFour.IsVisible = true;
                entryNineFour.IsVisible = true;
                entryTenFour.IsVisible = true;
                entryElevenFour.IsVisible = true;
                entryTwelveFour.IsVisible = true;
                if (screenBig)
                {
                    entryThirteenFour.IsVisible = true;
                    entryFourteenFour.IsVisible = true;
                    entryFifteenFour.IsVisible = true;
                }
            }
        }

        private void addPlayerFive(object sender, EventArgs e)
        {
            if (buttonFive.Text == "-")
            {
                buttonFour.IsEnabled = true;
                buttonFive.Text = "+";
                playerFive.IsVisible = false;
                standardTitle.IsVisible = true;
                extendedTitle.IsVisible = false;
                playerFiveScore.IsVisible = false;
                entryOneFive.IsVisible = false;
                entryTwoFive.IsVisible = false;
                entryThreeFive.IsVisible = false;
                entryFourFive.IsVisible = false;
                entryFiveFive.IsVisible = false;
                entrySixFive.IsVisible = false;
                entrySevenFive.IsVisible = false;
                entryEightFive.IsVisible = false;
                entryNineFive.IsVisible = false;
                entryTenFive.IsVisible = false;
                entryElevenFive.IsVisible = false;
                entryTwelveFive.IsVisible = false;
                if (screenBig)
                {
                    entryThirteenFive.IsVisible = false;
                    entryFourteenFive.IsVisible = false;
                    entryFifteenFive.IsVisible = false;
                }
            }
            else if (buttonFive.Text == "+")
            {
                buttonFour.IsEnabled = false;
                buttonFive.Text = "-";
                playerFive.IsVisible = true;
                standardTitle.IsVisible = false;
                extendedTitle.IsVisible = true;
                playerFiveScore.IsVisible = true;
                entryOneFive.IsVisible = true;
                entryTwoFive.IsVisible = true;
                entryThreeFive.IsVisible = true;
                entryFourFive.IsVisible = true;
                entryFiveFive.IsVisible = true;
                entrySixFive.IsVisible = true;
                entrySevenFive.IsVisible = true;
                entryEightFive.IsVisible = true;
                entryNineFive.IsVisible = true;
                entryTenFive.IsVisible = true;
                entryElevenFive.IsVisible = true;
                entryTwelveFive.IsVisible = true;
                if (screenBig)
                {
                    entryThirteenFive.IsVisible = true;
                    entryFourteenFive.IsVisible = true;
                    entryFifteenFive.IsVisible = true;
                }
            }
        }
        bool screenBig = false;
        private void titleTapped(object sender, EventArgs e)
        {
            if (screenBig)
            {
                File.WriteAllText(Path.Combine(FileSystem.AppDataDirectory, "screenBig.txt"), "false");
                screenBig = false;
            }
            else
            {
                File.WriteAllText(Path.Combine(FileSystem.AppDataDirectory, "screenBig.txt"), "true");
                screenBig = true;
            }
            Application.Current.Quit();
        }

        private void Settings_Clicked(object sender, EventArgs e)
        {
            mainGrid.IsVisible = false;
            firstTime.IsVisible = true;
            if (screenBig)
            {
                optionToggle.IsToggled = true;
            }
            else
            {
                optionToggle.IsToggled = false;
            }
        }
        bool aRP = false;
        private void addRemovePlayers_Clicked(object sender, EventArgs e)
        {
            shiftUp();
            if (aRP)
            {
                aRP = false;
                secondaryEntryGrid.IsVisible = false;
                buttonFive.IsEnabled = true;
                if (screenBig)
                {
                    entrySevenOne.IsVisible = true;
                    entryEightOne.IsVisible = true;
                    entryNineOne.IsVisible = true;
                    entryTenOne.IsVisible = true;
                    entryElevenOne.IsVisible = true;
                    entryTwelveOne.IsVisible = true;
                    entryThirteenOne.IsVisible = true;
                    entryFourteenOne.IsVisible = true;
                    entryFifteenOne.IsVisible = true;
                    entryNineTwo.IsVisible = true;
                    entrySevenTwo.IsVisible = true;
                    entryEightTwo.IsVisible = true;
                    entryTenTwo.IsVisible = true;
                    entryElevenTwo.IsVisible = true;
                    entryTwelveTwo.IsVisible = true;
                    entryThirteenTwo.IsVisible = true;
                    entryFourteenTwo.IsVisible = true;
                    entryFifteenTwo.IsVisible = true;
                    entrySevenThree.IsVisible = true;
                    entryEightThree.IsVisible = true;
                    entryNineThree.IsVisible = true;
                    entryTenThree.IsVisible = true;
                    entryElevenThree.IsVisible = true;
                    entryTwelveThree.IsVisible = true;
                    entryThirteenThree.IsVisible = true;
                    entryFourteenThree.IsVisible = true;
                    entryFifteenThree.IsVisible = true;
                    entrySevenFour.IsVisible = true;
                    entryEightFour.IsVisible = true;
                    entryNineFour.IsVisible = true;
                    entryTenFour.IsVisible = true;
                    entryElevenFour.IsVisible = true;
                    entryTwelveFour.IsVisible = true;
                    entryThirteenFour.IsVisible = true;
                    entryFourteenFour.IsVisible = true;
                    entryFifteenFour.IsVisible = true;
                    entrySevenFive.IsVisible = true;
                    entryEightFive.IsVisible = true;
                    entryNineFive.IsVisible = true;
                    entryTenFive.IsVisible = true;
                    entryElevenFive.IsVisible = true;
                    entryTwelveFive.IsVisible = true;
                    entryThirteenFive.IsVisible = true;
                    entryFourteenFive.IsVisible = true;
                    entryFifteenFive.IsVisible = true;
                }
                else
                {
                    entrySevenOne.IsVisible = true;
                    entrySevenTwo.IsVisible = true;
                    entrySevenThree.IsVisible = true;
                    entrySevenFour.IsVisible = true;
                    entrySevenFive.IsVisible = true;

                    entryEightOne.IsVisible = true;
                    entryEightTwo.IsVisible = true;
                    entryEightThree.IsVisible = true;
                    entryEightFour.IsVisible = true;
                    entryEightFive.IsVisible = true;

                    entryNineOne.IsVisible = true;
                    entryNineTwo.IsVisible = true;
                    entryNineThree.IsVisible = true;
                    entryNineFour.IsVisible = true;
                    entryNineFive.IsVisible = true;

                    entryTenOne.IsVisible = true;
                    entryTenTwo.IsVisible = true;
                    entryTenThree.IsVisible = true;
                    entryTenFour.IsVisible = true;
                    entryTenFive.IsVisible = true;

                    entryElevenOne.IsVisible = true;
                    entryElevenTwo.IsVisible = true;
                    entryElevenThree.IsVisible = true;
                    entryElevenFour.IsVisible = true;
                    entryElevenFive.IsVisible = true;

                    entryTwelveOne.IsVisible = true;
                    entryTwelveTwo.IsVisible = true;
                    entryTwelveThree.IsVisible = true;
                    entryTwelveFour.IsVisible = true;
                    entryTwelveFive.IsVisible = true;
                }
            }
            else
            {
                aRP = true;
                buttonFive.IsEnabled = false;
                secondaryEntryGrid.IsVisible = true;
                if (screenBig)
                {
                    entrySevenOne.IsVisible = false;
                    entryEightOne.IsVisible = false;
                    entryNineOne.IsVisible = false;
                    entryTenOne.IsVisible = false;
                    entryElevenOne.IsVisible = false;
                    entryTwelveOne.IsVisible = false;
                    entryThirteenOne.IsVisible = false;
                    entryFourteenOne.IsVisible = false;
                    entryFifteenOne.IsVisible = false;
                    entryNineTwo.IsVisible = false;
                    entrySevenTwo.IsVisible = false;
                    entryEightTwo.IsVisible = false;
                    entryTenTwo.IsVisible = false;
                    entryElevenTwo.IsVisible = false;
                    entryTwelveTwo.IsVisible = false;
                    entryThirteenTwo.IsVisible = false;
                    entryFourteenTwo.IsVisible = false;
                    entryFifteenTwo.IsVisible = false;
                    entrySevenThree.IsVisible = false;
                    entryEightThree.IsVisible = false;
                    entryNineThree.IsVisible = false;
                    entryTenThree.IsVisible = false;
                    entryElevenThree.IsVisible = false;
                    entryTwelveThree.IsVisible = false;
                    entryThirteenThree.IsVisible = false;
                    entryFourteenThree.IsVisible = false;
                    entryFifteenThree.IsVisible = false;
                    entrySevenFour.IsVisible = false;
                    entryEightFour.IsVisible = false;
                    entryNineFour.IsVisible = false;
                    entryTenFour.IsVisible = false;
                    entryElevenFour.IsVisible = false;
                    entryTwelveFour.IsVisible = false;
                    entryThirteenFour.IsVisible = false;
                    entryFourteenFour.IsVisible = false;
                    entryFifteenFour.IsVisible = false;
                    entrySevenFive.IsVisible = false;
                    entryEightFive.IsVisible = false;
                    entryNineFive.IsVisible = false;
                    entryTenFive.IsVisible = false;
                    entryElevenFive.IsVisible = false;
                    entryTwelveFive.IsVisible = false;
                    entryThirteenFive.IsVisible = false;
                    entryFourteenFive.IsVisible = false;
                    entryFifteenFive.IsVisible = false;
                }
                else
                {
                    entrySevenOne.IsVisible = false;
                    entrySevenTwo.IsVisible = false;
                    entrySevenThree.IsVisible = false;
                    entrySevenFour.IsVisible = false;
                    entrySevenFive.IsVisible = false;

                    entryEightOne.IsVisible = false;
                    entryEightTwo.IsVisible = false;
                    entryEightThree.IsVisible = false;
                    entryEightFour.IsVisible = false;
                    entryEightFive.IsVisible = false;

                    entryNineOne.IsVisible = false;
                    entryNineTwo.IsVisible = false;
                    entryNineThree.IsVisible = false;
                    entryNineFour.IsVisible = false;
                    entryNineFive.IsVisible = false;

                    entryTenOne.IsVisible = false;
                    entryTenTwo.IsVisible = false;
                    entryTenThree.IsVisible = false;
                    entryTenFour.IsVisible = false;
                    entryTenFive.IsVisible = false;

                    entryElevenOne.IsVisible = false;
                    entryElevenTwo.IsVisible = false;
                    entryElevenThree.IsVisible = false;
                    entryElevenFour.IsVisible = false;
                    entryElevenFive.IsVisible = false;

                    entryTwelveOne.IsVisible = false;
                    entryTwelveTwo.IsVisible = false;
                    entryTwelveThree.IsVisible = false;
                    entryTwelveFour.IsVisible = false;
                    entryTwelveFive.IsVisible = false;
                }
            }
        }

        private void addPlayerSix(object sender, EventArgs e)
        {
            if (buttonSix.Text == "-")
            {
                buttonSix.Text = "+";
                buttonSeven.IsVisible = false;
                playerSix.IsVisible = false;
                playerSixScore.IsVisible = false;
                entryTwoOneOne.IsVisible = false;
                entryTwoTwoOne.IsVisible = false;
                entryTwoThreeOne.IsVisible = false;
                entryTwoFourOne.IsVisible = false;
                entryTwoFiveOne.IsVisible = false;
                entryTwoSixOne.IsVisible = false;
            }
            else if (buttonSix.Text == "+")
            {
                buttonSix.Text = "-";
                buttonSeven.IsVisible = true;
                playerSix.IsVisible = true;
                playerSixScore.IsVisible = true;
                entryTwoOneOne.IsVisible = true;
                entryTwoTwoOne.IsVisible = true;
                entryTwoThreeOne.IsVisible = true;
                entryTwoFourOne.IsVisible = true;
                entryTwoFiveOne.IsVisible = true;
                entryTwoSixOne.IsVisible = true;
            }
        }

        private void addPlayerSeven(object sender, EventArgs e)
        {
            if (buttonSeven.Text == "-")
            {
                buttonSeven.Text = "+";
                buttonSix.IsEnabled = true;
                buttonEight.IsVisible = false;
                playerSeven.IsVisible = false;
                playerSevenScore.IsVisible = false;
                entryTwoOneTwo.IsVisible = false;
                entryTwoTwoTwo.IsVisible = false;
                entryTwoThreeTwo.IsVisible = false;
                entryTwoFourTwo.IsVisible = false;
                entryTwoFiveTwo.IsVisible = false;
                entryTwoSixTwo.IsVisible = false;
            }
            else if (buttonSeven.Text == "+")
            {
                buttonSeven.Text = "-";
                buttonSix.IsEnabled = false;
                buttonEight.IsVisible = true;
                playerSeven.IsVisible = true;
                playerSevenScore.IsVisible = true;
                entryTwoOneTwo.IsVisible = true;
                entryTwoTwoTwo.IsVisible = true;
                entryTwoThreeTwo.IsVisible = true;
                entryTwoFourTwo.IsVisible = true;
                entryTwoFiveTwo.IsVisible = true;
                entryTwoSixTwo.IsVisible = true;
            }
        }

        private void addPlayerEight(object sender, EventArgs e)
        {
            if (buttonEight.Text == "-")
            {
                buttonEight.Text = "+";
                buttonSeven.IsEnabled = true;
                buttonNine.IsVisible = false;
                playerEight.IsVisible = false;
                playerEightScore.IsVisible = false;
                entryTwoOneThree.IsVisible = false;
                entryTwoTwoThree.IsVisible = false;
                entryTwoThreeThree.IsVisible = false;
                entryTwoFourThree.IsVisible = false;
                entryTwoFiveThree.IsVisible = false;
                entryTwoSixThree.IsVisible = false;
            }
            else if (buttonEight.Text == "+")
            {
                buttonEight.Text = "-";
                buttonSeven.IsEnabled = false;
                buttonNine.IsVisible = true;
                playerEight.IsVisible = true;
                playerEightScore.IsVisible = true;
                entryTwoOneThree.IsVisible = true;
                entryTwoTwoThree.IsVisible = true;
                entryTwoThreeThree.IsVisible = true;
                entryTwoFourThree.IsVisible = true;
                entryTwoFiveThree.IsVisible = true;
                entryTwoSixThree.IsVisible = true;
            }
        }

        private void addPlayerNine(object sender, EventArgs e)
        {
            if (buttonNine.Text == "-")
            {
                buttonNine.Text = "+";
                buttonEight.IsEnabled = true;
                buttonTen.IsVisible = false;
                playerNine.IsVisible = false;
                playerNineScore.IsVisible = false;
                entryTwoOneFour.IsVisible = false;
                entryTwoTwoFour.IsVisible = false;
                entryTwoThreeFour.IsVisible = false;
                entryTwoFourFour.IsVisible = false;
                entryTwoFiveFour.IsVisible = false;
                entryTwoSixFour.IsVisible = false;
            }
            else if (buttonNine.Text == "+")
            {
                buttonNine.Text = "-";
                buttonEight.IsEnabled = false;
                buttonTen.IsVisible = true;
                playerNine.IsVisible = true;
                playerNineScore.IsVisible = true;
                entryTwoOneFour.IsVisible = true;
                entryTwoTwoFour.IsVisible = true;
                entryTwoThreeFour.IsVisible = true;
                entryTwoFourFour.IsVisible = true;
                entryTwoFiveFour.IsVisible = true;
                entryTwoSixFour.IsVisible = true;
            }
        }

        private void addPlayerTen(object sender, EventArgs e)
        {
            if (buttonTen.Text == "-")
            {
                buttonTen.Text = "+";
                buttonNine.IsEnabled = true;
                playerTen.IsVisible = false;
                playerTenScore.IsVisible = false;
                entryTwoOneFive.IsVisible = false;
                entryTwoTwoFive.IsVisible = false;
                entryTwoThreeFive.IsVisible = false;
                entryTwoFourFive.IsVisible = false;
                entryTwoFiveFive.IsVisible = false;
                entryTwoSixFive.IsVisible = false;
            }
            else if (buttonTen.Text == "+")
            {
                buttonTen.Text = "-";
                buttonNine.IsEnabled = false;
                playerTen.IsVisible = true;
                playerTenScore.IsVisible = true;
                entryTwoOneFive.IsVisible = true;
                entryTwoTwoFive.IsVisible = true;
                entryTwoThreeFive.IsVisible = true;
                entryTwoFourFive.IsVisible = true;
                entryTwoFiveFive.IsVisible = true;
                entryTwoSixFive.IsVisible = true;
            }
        }
    }
}


