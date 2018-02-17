package JavaCore.laba3_4;

public class CalculateIntegralOfSin implements Function {

    @Override
    public long evaluate(double lowMark, double highMark, int flow) throws TrigonometricException {

            double step = (highMark - lowMark) / (2 * flow);
            double fx1 = 0, fx2 = 0;

            for (int i = 1; i <= flow; i++){
                int z = 2 * i - 1;
                fx1 += Math.sin((lowMark + z * step));
            }

            for (int i = 1; i <= flow - 1; i++){
                int z = 2 * i;
                fx2 += Math.sin((lowMark + z * step));
            }

            return (long) ((step / 3) * (Math.sin(lowMark) + 4 * fx1 + 2 * fx2 + Math.sin((lowMark + 2 * flow * step))));
        }

}
