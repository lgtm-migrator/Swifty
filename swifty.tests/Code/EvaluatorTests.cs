using Xunit;
using System.Collections.Generic;
using swifty.Code;
using swifty.Code.Syntaxt;

namespace swifty.tests.Code.Text {
    public class EvaluatorTest {

        [Theory]
        [InlineData("1",1)]
        [InlineData("True",true)]
        [InlineData("const bool var:=True", true)]
        [InlineData("False",false)]
        [InlineData("const int a:= 10", 10)]
        [InlineData("{int res:=0\nfor int i:=0 to 10 {\nres:=res+i\n}\n}", 45)]
        [InlineData("const int d := 100 # this is a single line comment!", 100)]
        [InlineData("{int res:=0#kello\nfor int i:=0 to 11 {\nres:=res+i #hello\n}#dello\n}", 55)]
        [InlineData("1=>bool && 10=>bool", true)]
        [InlineData("True=>int + 100", 101)]
        [InlineData("{!((True=>int-1)=>bool)=>int+5}", 6)]
        [InlineData("10&1", 0)]
        [InlineData("11&1", 1)]
        [InlineData("15|13", 15)]
        [InlineData("True|True", true)]
        [InlineData("False&True", false)]
        [InlineData("False^True", true)]
        [InlineData("True^True", false)]
        [InlineData("False^100=>bool", true)]
       public void Evaluator_Computes_Correct_Value(string text, object expectedValue) {
           var syntaxTree = SyntaxTree.Parse(text);
           var compiler = new Compiler(syntaxTree);
           var variables = new Dictionary<VariableSymbol,object>();
           var res = compiler.EvaluationResult(variables);

           Assert.Empty(res.Diagnostics);
           Assert.Equal(expectedValue, res.Value);
       }

        [Theory]
        [InlineData("const a := 10", 1)]
        [InlineData("const", 4)]
        [InlineData("int", 3)]
        [InlineData("const int", 3)]
        [InlineData("const int a", 2)]
        [InlineData("const int a :=", 1)]
        [InlineData("{int res:=0\nfor i:=0 to 10 {\nres:=res+i\n}\n}", 1)]
        [InlineData("{)}",1)]
        [InlineData("{}}", 1)]
        [InlineData("const int a := false", 1)]
        [InlineData("{const int a := 10\na := 5}", 1)]
        [InlineData("int => bool", 3)]
        [InlineData("hello => int", 1)]
        [InlineData("int => hello", 5)]
        [InlineData("1^true", 1)]
       public void Evaluator_Reports_Errors(string text, object expectedValue) {
           var syntaxTree = SyntaxTree.Parse(text);
           var compiler = new Compiler(syntaxTree);
           var variables = new Dictionary<VariableSymbol,object>();
           var res = compiler.EvaluationResult(variables);

           Assert.NotEmpty(res.Diagnostics);
           Assert.Equal(expectedValue, res.Diagnostics.Count);
       }
    }
}