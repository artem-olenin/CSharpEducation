namespace Homework2.TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* 
             * Домашнее задание 2
             * Игра «Крестики-Нолики» (TicTacToe).
             * Игрок против игрока.
             * Отрисовка поля 3*3 в консоли. ВЫПОЛНЕНО
             * Считывание хода игрока. ВЫПОЛНЕНО
             * Проверка корректности хода. (на 1-9 ВЫПОЛНЕНО, на уже сделанный ход, другая комбинация)
             * Проверка победной комбинации хода. (ВЫПОЛНЕНО)
             * Проверка на ничью. (ВЫПОЛНЕНО)
             * Дополнительно:
             * Подсветка ходов. (это как???? такое тоже умеем)
             * Игра должна проходить и завершаться без ошибок. Все действия пользователя должны быть корректны.
             * 
             * Отправляйте ссылку на репозиторий
            */

            Console.WriteLine("Программа игры Крестики - Нолики:");
            Console.WriteLine("Играют 2 игрока.");

            // заполнение и отрисовка игрового поля
            char[][] Matrix = new char[3][];
            Matrix[0] = ['7', '8', '9'];
            Matrix[1] = ['4', '5', '6'];
            Matrix[2] = ['1', '2', '3'];

            for (int i = 0; i < Matrix.Length; i++)
            {
                Console.WriteLine("-------");
                Console.Write("|");
                for (int j = 0; j < Matrix.Length; j++)
                {
                    Console.Write(Matrix[i][j] + "|");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------");
            Console.WriteLine();

            char toGo = '$'; //произвольный символ перед началом хода игрока, как избежать его и нужно ли заморачиваться
            int step = 1; //счетчик ходов и перехода хода (нечетный/четный)
            char[] WasMove = new char[10]; //массив для запоминания и сверки уже сделанных ходов
            bool chek = false; //переменная для проверки условия на уже вводимое значение

            do //цикл выполнения хода игроками
            {
                Console.WriteLine("ход номер " + step); //потом удалить
                if (step % 2 == 0)
                {
                    Console.Write("Ход 2го игрока: ");
                }
                else Console.Write("Ход 1го игрока: ");

                //цикл проверки введенного значения на соответствие игровому полю (1-9)
                do
                {
                    toGo = Convert.ToChar(Console.ReadLine()); //забираю выбор хода игроком
                    chek = MethodChekMove(toGo, WasMove, chek);
                } while (chek); //что то не так отрабатывает...
                
                WasMove[step] = toGo; //записываю в массив выполненных ходов
                toGo = MethodToGoPlayer(Matrix, toGo, step); //записываю в выбранное поле ход игрока Х или О
                 
                if (step >= 9) //упс, игра дошла до 9го хода + никто не выиграл = ничья!
                {
                    Console.WriteLine("Игра окончена - ничья!");
                    return; //возращаемя
                }    
                step++;

            } while (!MethodWinner(Matrix, toGo)); //проверка методом на победителя (от обратного с !)

            Console.WriteLine("Ура, вы победили!");
            Console.WriteLine("Это была серьезная борьба и вы достойно справились! Молодец, я так не умею!");
        }

        private static bool MethodChekMove(char toGo, char[] WasMove, bool chek) //метод проверки хода: 1-9; сделанных ходов
        {
            if (toGo != '1' & toGo != '2' & toGo != '3' & toGo != '4' & toGo != '5' & toGo != '6' & toGo != '7' & toGo != '8' & toGo != '9') //сложно выглядит, но пока так
            {
                Console.Write("Некорректный ввод, введите значение игрового поля 1-9: ");
                chek = true; //совпадение найдено
            }
            for (int i = 0; i < WasMove.Length; i++) //не останавливается счетчик хода, опять 
            {
                if (toGo.Equals(WasMove[i]))
                {
                    Console.Write("Такой ход уже сделан, выберите другое поле: ");
                    chek = true; //совпадение найдено
                }
            }
            return chek;
        }

        private static char MethodToGoPlayer(char[][] Matrix, char toGo, int step) //метод выполнения хода игроком
        {
            char onePlayer = 'X';
            char twoPlayer = 'O';
            Console.WriteLine();
            for (int i = 0; i < Matrix.Length; i++)
            {
                Console.WriteLine("-------");
                Console.Write("|");
                for (int j = 0; j < Matrix.Length; j++)
                {
                    if (Matrix[i][j].Equals(toGo))
                    {
                        //проверка счетчика шагов на четный/нечетный и присваимваем ход нужному игроку
                        if (step % 2 == 0)
                        {
                            toGo = twoPlayer; //присваимваем ход 2му игорку
                        }
                        else
                        {
                            toGo = onePlayer; //иначе присваимваем ход 1му игорку
                        }
                        Matrix[i][j] = toGo;
                    }
                    Console.Write(Matrix[i][j] + "|");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------");
            Console.WriteLine();
            return toGo;
        }

        private static bool MethodWinner(char[][] Matrix, char toGo)
        {
            //проверка строк и столбцов
            for (int i = 0; i < Matrix.Length; i++)
            {
                if (((Matrix[i][0] == toGo) && (Matrix[i][1] == toGo) && (Matrix[i][2] == toGo)) || ((Matrix[0][i] == toGo) && (Matrix[1][i] == toGo) && (Matrix[2][i] == toGo)))
                {
                    return true;
                }
            }
            //проверка диагоналей
            if (((Matrix[0][0] == toGo) && (Matrix[1][1] == toGo) && (Matrix[2][2] == toGo)) || ((Matrix[0][2] == toGo) && (Matrix[1][1] == toGo) && (Matrix[2][0] == toGo)))
            {
                return true;
            }
            return false;
        }
    }
}
