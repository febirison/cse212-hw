/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using Microsoft.VisualBasic.FileIO;
using System;
using System.Linq;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // ignore header row
        while (!reader.EndOfData) {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            if (int.TryParse(fields[8], out int points)) {
                if (players.ContainsKey(playerId)) {
                    players[playerId] += points; // Add to existing total
                } else {
                    players[playerId] = points; // Initialize new player
                }
            }
        }

        // Get top 10 players sorted by points (descending)
        var topPlayers = players.OrderByDescending(p => p.Value)
                               .Take(10)
                               .Select(p => $"{p.Key}: {p.Value}")
                               .ToArray();

        Console.WriteLine("Top 10 Players by Total Points:");
        foreach (var player in topPlayers) {
            Console.WriteLine(player);
        }
    }
}