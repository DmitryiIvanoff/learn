package JavaCore.laba1_2.Part3____;

public class Sum implements Function {
    @Override
    public long evaluate(double[] args) {
        return 0;
    }

    public static double getSum(double[] array, int pow){
        double sum = 0;
        for (double d: array) {
            sum += Math.pow(d, pow);
        }
        return sum;
    }
}
