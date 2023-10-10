using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RockPaperScissors
{
  internal class Program
  {

    static void Main(string[] args)
    {
      int playerScore = 0;
      int computerScore = 0;
      Random random = new Random();
      while (true)
      {
        string playerMove;
        Console.WriteLine($"You: {playerScore}\tComputer: {computerScore}");
        while (true)
        {
          Console.Write("Enter your move: ");
          playerMove = Console.ReadLine().ToUpper();
          if (ValidatePlayerMove(playerMove))
          {
            break;
          }
          Console.WriteLine("You can only enter: Rock(R), Paper(P) or Scissors(S). Try again :)");
        };

        string computerMove = GetComputerMove(random.Next(3));
        string result = CompareMove(playerMove, computerMove);
        IncreaseScore(result, ref playerScore, ref computerScore);
        Console.WriteLine($"Computer played {computerMove} you played {playerMove}, you {result}");

        Thread.Sleep(2000);
        Console.Clear();
      };
    }
    public static bool ValidatePlayerMove(string playerMove)
    {
      if (playerMove == Move.ROCK.ToString() || playerMove == Move.R.ToString() || playerMove == Move.PAPER.ToString() || playerMove == Move.P.ToString() || playerMove == Move.SCISSORS.ToString() || playerMove == Move.S.ToString())
      {
        return true;
      }
      return false;
    }
    public static string GetComputerMove(int randomNum)
    {
      if (randomNum == 0)
      {
        return Move.ROCK.ToString();
      }
      else if (randomNum == 1)
      {
        return Move.PAPER.ToString();
      }
      else
      {
        return Move.SCISSORS.ToString();
      }
    }
    public static string CompareMove(string playerMove, string computerMove)
    {
      string rock, paper, scissors, r, p, s;
      rock = Move.ROCK.ToString();
      paper = Move.PAPER.ToString();
      scissors = Move.SCISSORS.ToString();
      r = Move.R.ToString();
      p = Move.P.ToString();
      s = Move.S.ToString();

      if ((computerMove == rock && (playerMove == scissors || playerMove == s)) || (computerMove == paper && (playerMove == rock || playerMove == r)) || computerMove == scissors && (playerMove == paper || playerMove == p))
      {
        return Outcome.LOSE.ToString();
      }
      else if ((computerMove == rock && (playerMove == paper || playerMove == p)) || (computerMove == paper && (playerMove == scissors || playerMove == s)) || computerMove == scissors && (playerMove == rock || playerMove == r))
      {
        return Outcome.WIN.ToString();
      }
      else
      {
        return Outcome.DRAW.ToString();
      }
    }
    public static void IncreaseScore(string result, ref int playerScore, ref int computerScore)
    {
      if (result == Outcome.WIN.ToString())
      {
        playerScore++;
      }
      else if (result == Outcome.LOSE.ToString())
      {
        computerScore++;
      }
    }
    public static String GetFinalResult(int userScore, int computerScore)
    {
      if (userScore > computerScore)
      {
        return Outcome.WIN.ToString();
      }
      else if (userScore < computerScore)
      {
        return Outcome.LOSE.ToString();
      }
      else
      {
        return Outcome.DRAW.ToString();
      }
    }
  }
  enum Move : byte
  {
    ROCK,
    PAPER,
    SCISSORS,
    R,
    P,
    S
  }
  enum Outcome : byte
  {
    WIN,
    LOSE,
    DRAW
  }
}
