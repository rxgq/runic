public abstract class ValueType {
    public string? Type { get; set; }
    public object? Value { get; set; }
}

public class UndefinedType : ValueType {

    public UndefinedType() {
        Type = "undefined";
        Value = "undefined";
    }
}

public class NumericType : ValueType {

    public NumericType(float val) {
        Type = "number";
        Value = val;
    }
}