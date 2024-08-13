namespace judas;

public enum ExprType {
    VariableDeclaratorExpr,
    BinaryExpr,
    LogicalExpr,
    IdentifierExpr,
    UndefinedExpr,
    NumericExpr,
    StringExpr,
}

public class Program {
    public List<Expression> Body { get; set; } = [];
}

public abstract class Expression(ExprType kind) {
    public ExprType Kind { get; set; } = kind;
}

public class VariableDeclarator(string identifier, string literal, Expression init) : Expression(ExprType.VariableDeclaratorExpr) {
    public string Identifier { get; set; } = identifier;
    public string Literal { get; set; } = literal;
    public Expression Init { get; set; } = init;

    public override string ToString()
        => $"[{Identifier} {Literal}: {Init}]";
}

public class BinaryExpression (Expression left, Expression right, Token op) : Expression(ExprType.BinaryExpr) {
    public Expression Left { get; set; } = left;
    public Expression Right { get; set; } = right;
    public Token Operator { get; set; } = op;

    public override string ToString()
        => $"({Left} {Operator.Value} {Right})";
}

public class LogicalExpression (Expression left, Expression right, Token op) : Expression(ExprType.LogicalExpr) {
    public Expression Left { get; set; } = left;
    public Expression Right { get; set; } = right;
    public Token Operator { get; set; } = op;

    public override string ToString()
        => $"({Left} {Operator} {Right})";
}

public class IdentifierExpression (string symbol) : Expression(ExprType.IdentifierExpr) {
    public string Symbol { get; set; } = symbol;

    public override string ToString()
        => $"[IDENT: {Symbol}]";
}

public class UndefinedExpression(string symbol) : Expression(ExprType.UndefinedExpr) {
    public string Symbol { get; set; } = symbol;

    public override string ToString()
        => $"[UNDEF: {Symbol}]";
}

public class NumericExpression(float value) : Expression(ExprType.NumericExpr) {
    public float Value { get; set; } = value;

    public override string ToString()
        => Value.ToString();
}

public class StringExpression(string value) : Expression(ExprType.StringExpr) {
    public string Value { get; set; } = value;
    
    public override string ToString()
        => $"String: [{Value}]";
}