using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            cell[] board2 = new cell[256];

            for (int i = 0; i < board2.Length; ++i)
            {
                board2[i] = new cell();
                board2[i].life = 0;
                board2[i].color = "#FF0000";
            }
            /*
            foreach (cell i in board2)
            {
                Console.WriteLine(i.life);
                Console.WriteLine(i.color);
            }
            */

            board2[245].life = 1;

            string jsonString;
            jsonString = JsonSerializer.Serialize(board2);
            Console.WriteLine(jsonString);


            cell[] board = new cell[256];

            for (int i = 0; i < board2.Length; ++i)
            {
                board[i] = new cell();
            }

            int count = 0;

            using (JsonDocument document = JsonDocument.Parse(jsonString))
            {
                JsonElement root = document.RootElement;
                //JsonElement studentsElement = root.GetProperty("Students");
                foreach (JsonElement cell in root.EnumerateArray())
                {
                    cell.TryGetProperty("life", out JsonElement lifeElement);
                    board[count].life = lifeElement.GetInt32();
                    //Console.WriteLine(lifeElement.ToString());
                    cell.TryGetProperty("color", out JsonElement colorElement);
                    board[count].color = colorElement.ToString();
                    //Console.WriteLine(colorElement.ToString());
                    count++;
                }
            }

            foreach (cell i in board)
            {
                Console.WriteLine(i.life);
                Console.WriteLine(i.color);
            }


        }
    }
    class cell
    {
        public int life { get; set; }
        public string color { get; set; }
    }




}
