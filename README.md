# Cloth of Gold
By Adam Murray and Sean Murray

## Description:
This is my game project "Cloth of Gold" using Unity and written in C#. Named after the "cloth of gold" snail whos shell pigment pattern resembles the output of Stephen Wolframs "Rule 30" cellular automata. The premiss of the game is essentially a two-player checkers-like stratagy game in which the goal is to out-survive or destroy your opponent. At the beginning of each round, each play places or removes a number of their units from their side of the board. Once both players have locked in their choices, 1000 iterations of the various cellular automata algorithms play out which quickly becomes too complex to make many meaningful predictions. The core mechanics of the game utilize various cellular automata algorithms (i.e. Conway's Game of Life and Termites), various noise algorithms (i.e. Perlin Noise and Open Simplex Noise), and supervised learning alogirthm.

## Links:
Trello board: https://trello.com/b/HGbKfQSE/cloth-of-gold

## Current Status:
- Scavanging previous version for useful code.
- Starting new version in Unity.
- Working on settting up array system of shape (BOARD_WIDTH * BOARD_HEIGHT * 4) (X, Y, Z) for holding the info for the ground tile, the enviornmental prop, the tile status effect (i.e. on fire, can reproduce, etc.), and the player unit.
- Working on getCellStatus() to return values from Z column in array.
- Working on setCellAlive() to set if the cell has a unit on it or not.
