using System;
using System.Collections.Generic;

namespace DokumentacjaCS
{
    internal abstract class Expression
    {
        public abstract double Evaluate(Dictionary<string, object> vars);
    }
    internal class Constant : Expression
    {
        double _value;
        public Constant(double value) => _value = value;
        public override double Evaluate(Dictionary<string, object> vars)
        {
            return _value;
        }
    }
    internal class VariableReference : Expression
    {
        string _name;
        public VariableReference(string name) => _name = name;
        public override double Evaluate(Dictionary<string, object> vars)
        {
            object value = vars[_name] ?? throw new Exception($"unknown variable: {_name}");
            return Convert.ToDouble(value);
        }
    }
    internal class Operation : Expression
    {
        Expression _left;
        char _op;
        Expression _right;
        public Operation(Expression left, char op, Expression right)
        {
            _left = left;
            _op = op;
            _right = right;
        }

        public override double Evaluate(Dictionary<string, object> vars)
        {
            double x = _left.Evaluate(vars);
            double y = _right.Evaluate(vars);
            switch (_op)
            {
                case '+': return x + y;
                case '-': return x - y;
                case '*': return x * y;
                case '/': return x / y;
                default: throw new Exception("Unknown operator");
            }
        }
    }
}
