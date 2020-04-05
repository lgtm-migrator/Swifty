using System;
using swifty.Code.Syntaxt;
using swifty.Code.Annotation;
namespace swifty.Code {
    internal class Evaluator {
        private readonly AnnotatedExpression _root;
        public Evaluator(AnnotatedExpression root) {
            _root = root;
        }
        public object Evaluate() {
            return EvaluateExpression(_root);
        }
        private object EvaluateExpression(AnnotatedExpression root) {
            if (root is AnnotatedLiteralExpression n) {
                return n.Value;
            }
            if (root is AnnotatedUnaryExpression u) {
                int operand = (int)EvaluateExpression(u.Operand);
                switch (u.OperatorKind) {
                    case AnnotatedUnaryOperatorKind.Identity: return operand;
                    case AnnotatedUnaryOperatorKind.Negation: return -operand;
                    default: throw new Exception($"Unexpected Unary expression {u.OperatorKind}");
                }
            }
            if (root is AnnotatedBinaryExpression b) {
                int left = (int)EvaluateExpression(b.Left);
                int right = (int)EvaluateExpression(b.Right);

                switch(b.OperatorKind) {
                    case AnnotatedBinaryOperatorKind.Addition: return left + right;
                    case AnnotatedBinaryOperatorKind.Subtraction: return left - right;
                    case AnnotatedBinaryOperatorKind.Multiplication: return left * right;
                    case AnnotatedBinaryOperatorKind.Division: {
                        if (right == 0) {
                            throw new Exception("ERROR: Division by Zero");
                        }
                        return left / right;
                    }
                    default: throw new Exception($"Unexpected binary operator {b.OperatorKind}");
                }
            }
            throw new Exception($"Unexpected node {root.Kind}");
        }
    }
}