# Rolly Poly (2011)

An unfinished two-player property-trading board game, written in VB.NET (Windows Forms, Visual Studio 2008) as a university team project in late 2011.

Shared as a record of a student team project. No licence is granted.

## What the code does

Everything below is read from the code in this repository. Messages and labels in the game are in Korean.

- **Start menu** (`start.vb`): "play" opens the board, "creater" opens the credits screen, "exit" closes the menu.
- **Board** (`Monopoly.vb`): 40 squares around the edge of the window. Most are cities around the world and in Korea; the rest are special squares: start, desert island, donation, donation box, space station, and golden key (chance) squares. Hovering over a square shows its name. Each player starts with 5,000,000.
- **Turns**: the "roll dice" button rolls two dice (1 to 6 each, shown as pictures) and the token walks square by square on a timer. Doubles give the same player another turn. Passing the start square pays 200,000.
- **Buying**: landing on a city nobody owns opens a buy dialog (`call.vb`). A city costs 20,000 plus 20,000 times its square number, and bought squares are marked in the owner's colour.
- **Building**: landing on your own city offers a house (100,000), building (200,000) or hotel (300,000), up to three per city, and raises the toll for that city.
- **Tolls**: landing on the other player's city charges the toll, unless you hold a free-pass card and choose to use it.
- **Golden keys**: a random card from a list, for example a free pass, a desert-island escape ticket, a property tax per city, a building maintenance fee, a move to Seoul, the desert island, the donation box or the space station, 2,000,000 from the bank, a 50,000 fine, or selling your most expensive city to the bank at half price.
- **Special squares**: the desert island holds you for two turns unless you use an escape ticket or roll doubles. The donation square takes 200,000 into a shared pot and the donation box square pays out the whole pot. The space station charges 400,000 (paid to the owner of square 33 if there is one) and then lets you click any square to move there.
- **Game over and ranking**: when a player's money falls to zero or below, the winner's money and number of cities are appended to `rank.txt` with a name the winner types in, when the result beats an entry already in the file or the file is missing or has room. The Ranking menu opens a form (`rank.vb`) that lists up to ten entries from `rank.txt`.

### Unfinished parts

- `Form3` (a winner and loser screen with "play again" and "exit" buttons) has no code, and nothing opens it.
- The Exit and Help menu items have no handlers; only Ranking does.
- Clicking the board background runs leftover test code that shows a building marker on square 5.
- Some rules have bugs, for example the money check when player 2 buys a city reads player 1's balance, and the golden key draw never picks the last of the 13 cards.

## Team and Dawn's part

This was a team project of three students in a university Visual Basic course. Window titles in an earlier copy of the project credit Dawn with the ranking form (`rank.vb` here) and the buy dialog (`call.vb` here), and list Dawn as one of two assisting coders on the main board form. Those titles are the only authorship record; there is no version history.

## Toolchain and building today

- VB.NET, Windows Forms, .NET Framework 3.5. Solution `WindowsApplication1.sln` (Visual Studio 2008 format) with one project, `WindowsApplication1/WindowsApplication1.vbproj`. The program's assembly, root namespace and exe are named `RollyPoly`.
- A current Visual Studio on Windows (the free Community edition is enough) can open the solution and upgrade it. If the .NET Framework 3.5 targeting files are not installed, retarget the project to .NET Framework 4.8. It is Windows only.
- All source files are UTF-8, most with a byte order mark; the original project was already saved that way, so no conversion was needed.
- **It will not build as published.** `My Project/Resources.resx` still refers to 36 picture files in a `WindowsApplication1/Resources/` folder that is not included, so the resource step fails. Supplying your own pictures under those names, or removing those entries, gets past it.

## What was removed for this release

| Removed | Why |
|---|---|
| The `Resources/` folder: country flags, photos from the web, dice and building pictures | Third-party images. |
| Pictures embedded in three `.resx` files (credits background, winner screen background, one board square) | Third-party images. The image entries were deleted from the `.resx` files; text entries were kept. |
| The team's picture folders, fan-art character drawings and a Photoshop file | Third-party images and fan art of real people. |
| Student ID numbers and names on the credits screen | Team members' personal data. The labels now read "Team member". |
| The team name in the assembly company, copyright and trademark fields | Team identification. The fields are empty now. |
| The original name of the assembly, root namespace, product and exe | It was the name of a commercial board game, a trademark. Renamed to `RollyPoly`. |
| A zip of the project with `bin/` and `obj/` build output, the `.suo` file and `rank.txt` | Build output, per-user IDE state, and a score file with players' names. |

## It does not run as published

The pictures are gone. Besides the build failing at the resource step, the board squares, dice, tokens and the credits and winner screens were all drawn with those pictures, so even a build with the resource entries removed would show an empty board.
