namespace swifty.Code.Syntaxt {
    internal static class SyntaxRules {
        internal static int GetBinaryOperatorPrecendence(this SyntaxKind kind) {
            switch(kind) {
                case SyntaxKind.TypeCastToken:          return 7;
                case SyntaxKind.OrToken:                return 6;
                case SyntaxKind.AndToken:               return 6;
                case SyntaxKind.XorToken:               return 6;
                case SyntaxKind.DivideToken:            return 5;
                case SyntaxKind.StarToken:              return 5;
                case SyntaxKind.PlusToken:              return 4;
                case SyntaxKind.MinusToken:             return 4;
                case SyntaxKind.EqualToken:             return 3;
                case SyntaxKind.NotEqualToken:          return 3;
                case SyntaxKind.LessThanToken:          return 3;
                case SyntaxKind.LessThanEqualToken:     return 3;
                case SyntaxKind.GreaterThanToken:       return 3;
                case SyntaxKind.GreaterThanEqualToken:  return 3;
                case SyntaxKind.LogicalAndToken:        return 2;
                case SyntaxKind.LogicalOrToken:         return 1;
                default:                                return 0;
            }
        }
        // All Unary Operators should have similar precedences and 
        // higher than every binary operator precedence so they dont get
        //  misclassified as a binary operator.
        internal static int GetUnaryOperatorPrecedence(this SyntaxKind kind) {
            switch(kind) {
                case SyntaxKind.NotToken:               return 8;
                case SyntaxKind.BitwiseNegationToken:   return 8;
                case SyntaxKind.PlusToken:              return 8;
                case SyntaxKind.MinusToken:             return 8;
                default:                                return 0;
            }
        }

        internal static SyntaxKind GetKeywordKind(string text) {
            switch(text) {
                case "True": return SyntaxKind.TrueKeyword;
                case "False": return SyntaxKind.FalseKeyword;
                case "int": return SyntaxKind.IntKeyword;
                case "bool": return SyntaxKind.BoolKeyword;
                case "const": return SyntaxKind.ConstKeyword;
                case "if": return SyntaxKind.IfKeyword;
                case "else": return SyntaxKind.ElseKeyword;
                case "while": return SyntaxKind.WhileKeyword;
                case "for": return SyntaxKind.ForKeyword;
                case "to": return SyntaxKind.ToKeyword;
                default: return SyntaxKind.IdentifierToken;
            }
        }
    }
}