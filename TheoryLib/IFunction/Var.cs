namespace TheoryLib.IFunction {

   internal interface Var<in Z, in Y, in X, in W, out V> : Var<Y , X , W , V> { }

   internal interface Var<in Z, in Y, in X, out W> : Var<Y , X , W> { }

   internal interface Var<in Z, in Y, out X> : Var<Y , X> { }

   internal interface Var<in Z, out Y> : Var<Y> { }

   internal interface Var<out Z> : Var { }

   internal interface Var { };
}