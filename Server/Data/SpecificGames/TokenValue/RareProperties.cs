namespace Server.Data.Classes;

public class RareProperties : TokenValue {
    public override int Value(Token token)
    {
        Func<int,int,int>[] calculator = {a,b,c,d,e,f,g,h};
        Random r = new Random();
        int left = token.Left.Value;
        int right = token.Right.Value;
        int ramdom = r.Next(0,calculator.Length - 1);
        return calculator[ramdom](right,left);

    }
    private int a(int right, int left){
        return (int)Math.Abs(Math.Pow(right,3) - Math.Pow(left, 2));
    }
    private int b(int right, int left){
        return (2 + right + left)/2;
    }
    private int c(int right, int left){
        return (int)Math.Abs((Math.Cos(left)-Math.Sin(right))*10);
    }
    private int d(int right, int left){
        return Math.Abs((right + left)*(right-left));
    }
    private int e(int right, int left){
        return (int)((Math.Sqrt(right) + Math.Log2(left + 1))*5);
    }
    private int f(int right, int left){
        return 0;
    }
    private int g(int right, int left){
        return 1000;
    }
    private int h(int right, int left){
        return (int)Math.Abs(Math.PI*(Math.Pow(right,2)-Math.Sqrt(left+10)));
    }
}