namespace swifty.Code.Syntaxt {
    internal static class SyntaxRules {
        internal static int GetBinaryOperatorPrecendence(this SyntaxKind kind) {
            switch(kind) {
                case SyntaxKind.PlusToken:      return 1;
                case SyntaxKind.MinusToken:     return 1;
                case SyntaxKind.StarToken:      return 2;
                case SyntaxKind.DivideToken:    return 3;
                default: return 0;
            }
        }
        internal static int GetUnaryOperatorPrecedence(this SyntaxKind kind) {
            switch(kind) {
                case SyntaxKind.PlusToken:      return 4;
                case SyntaxKind.MinusToken:     return 4;
                default: return 0;
            }
        }

        internal static SyntaxKind GetKeywordKind(string text) {
            switch(text) {
                case "true": return SyntaxKind.TrueKeyword;
                case "false": return SyntaxKind.FalseKeyword;
                default: return SyntaxKind.IdentifierToken;
            }
        }
    }
}