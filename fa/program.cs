using System;
using System.Collections.Generic;

namespace fans
{
    public class State
    {
        public string Name;
        public Dictionary<char, State> Transitions;
        public bool IsAcceptState;
    }

    public class FA1
    {
        public static State first = new State()
        {
            Name = "first",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State second = new State()
        {
            Name = "second",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State third = new State()
        {
            Name = "third",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State pos = new State()
        {
            Name = "pos",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };
        public State neg = new State()
        {
            Name = "neg",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = first;

        public FA1()
        {
            first.Transitions['0'] = second;
            first.Transitions['1'] = third;
            second.Transitions['0'] = neg;
            second.Transitions['1'] = pos;
            third.Transitions['0'] = pos;
            third.Transitions['1'] = third;
            pos.Transitions['0'] = neg;
            pos.Transitions['1'] = pos;
        }

        public bool? Run(IEnumerable<char> str)
        {
            State current = InitialState;
            foreach (var ch in str) // цикл по всем символам 
            {
                current = current.Transitions[ch]; // меняем состояние на то, в которое у нас переход
                if (current == null)              // если его нет, возвращаем признак ошибки
                    return null;
                // иначе переходим к следующему
            }
            return current.IsAcceptState;         // результат true если в конце финальное состояние 
        }
    }

    public class FA2
    {
        public static State first = new State()
        {
            Name = "first",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State second = new State()
        {
            Name = "second",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State third = new State()
        {
            Name = "third",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State pos = new State()
        {
            Name = "pos",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = first;

        public FA2()
        {
            first.Transitions['0'] = second;
            first.Transitions['1'] = third;
            second.Transitions['0'] = first;
            second.Transitions['1'] = pos;
            third.Transitions['0'] = pos;
            third.Transitions['1'] = first;
            pos.Transitions['0'] = third;
            pos.Transitions['1'] = second;
        }

        public bool? Run(IEnumerable<char> str)
        {
            State current = InitialState;
            foreach (var ch in str) // цикл по всем символам 
            {
                current = current.Transitions[ch]; // меняем состояние на то, в которое у нас переход
                if (current == null)              // если его нет, возвращаем признак ошибки
                    return null;
                // иначе переходим к следующему
            }
            return current.IsAcceptState;         // результат true если в конце финальное состояние 
        }
    }

    public class FA3
    {
        public static State first = new State()
        {
            Name = "first",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State second = new State()
        {
            Name = "second",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State pos = new State()
        {
            Name = "pos",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = first;

        public FA3()
        {
            first.Transitions['0'] = first;
            first.Transitions['1'] = second;
            second.Transitions['0'] = first;
            second.Transitions['1'] = pos;
            pos.Transitions['0'] = pos;
            pos.Transitions['1'] = pos;
        }

        public bool? Run(IEnumerable<char> str)
        {
            State current = InitialState;
            foreach (var ch in str) // цикл по всем символам 
            {
                current = current.Transitions[ch]; // меняем состояние на то, в которое у нас переход
                if (current == null)              // если его нет, возвращаем признак ошибки
                    return null;
                // иначе переходим к следующему
            }
            return current.IsAcceptState;         // результат true если в конце финальное состояние 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            String s = "01111";
            FA1 fa1 = new FA1();
            bool? result1 = fa1.Run(s);
            Console.WriteLine(result1);
            FA2 fa2 = new FA2();
            bool? result2 = fa2.Run(s);
            Console.WriteLine(result2);
            FA3 fa3 = new FA3();
            bool? result3 = fa3.Run(s);
            Console.WriteLine(result3);
        }
    }
}
